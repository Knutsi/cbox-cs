using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Xml.Serialization;
using System.Web.Script.Serialization;

using cbox.model;
using cbox.generation;

namespace cbox.system
{
    public class InvalidCBoxSystemException : Exception
    {
        public InvalidCBoxSystemException(string msg)
            : base(msg)
        {

        }
    }

    /// <summary>
    /// Represents a collection of models, components and and ontology.  The files are associated through 
    /// a specific folder structure that this class can read and monitor.
    /// </summary>
    public class CBoxSystem
    {
        public const string MODEL_REL_ONTOLOGY_PATH = @"\..\Default.cbxont";
        public const string COMPONENT_DIR_NAME = "Components";
        public const string MODEL_DIR_NAME = "Models";
        public const string ONTOLOGY_NAME = "Default.cbxont";

        public string Path; // system's location

        public List<ModelReference> Models = new List<ModelReference>(); // all models in the system
        public List<ModelReference> Components = new List<ModelReference>(); // all components in the system

        public CBoxSystem(string path)
        {
            this.Path = path;

            ValidateDirectoryStructure();
            Load();

            Console.WriteLine("Loaded CBoxSystem '{0}'", this.Path);
        }

        /// <summary>
        /// Patht to the model directory.
        /// </summary>
        public string ModelDirPath
        {
            get
            {
                return System.IO.Path.Combine(this.Path, MODEL_DIR_NAME);
            }
        }

        /// <summary>
        /// Path to the component directory.
        /// </summary>
        public string ComponentDirPath
        {
            get
            {
                return System.IO.Path.Combine(this.Path, COMPONENT_DIR_NAME);
            }
        }

        /// <summary>
        /// Ontology path.
        /// </summary>
        public string OntologyPath
        {
            get
            {
                return System.IO.Path.Combine(this.Path, ONTOLOGY_NAME);
            }
        }


        /// <summary>
        /// Ensure the correct dirs and ontology are present.
        /// </summary>
        private void ValidateDirectoryStructure()
        {
            if (!Directory.Exists(ModelDirPath))
                throw new InvalidCBoxSystemException("ModelDirPath does not exist on filesystem");

            if (!Directory.Exists(ComponentDirPath))
                throw new InvalidCBoxSystemException("ComponentDirPath does not exist on filesystem");

            if (!File.Exists(OntologyPath))
                throw new InvalidCBoxSystemException("OntologyPath does not exist on filesystem");
        }


        /// <summary>
        /// Loads references for all models.
        /// </summary>
        private void Load()
        {
            Models = (from m in Directory.GetFiles(ModelDirPath)
                      select new ModelReference() { Path = m, Title = System.IO.Path.GetFileName(m) }).ToList();

            Components = (from m in Directory.GetFiles(ComponentDirPath)
                          select new ModelReference() { Path = m, Title = System.IO.Path.GetFileName(m) }).ToList();
        }


        /// <summary>
        /// Loads the system based on the path of a model inside it.  Useful if the user opens
        /// a model, and the system should also be loaded.
        /// </summary>
        /// <param name="model_path"></param>
        /// <returns></returns>
        static public CBoxSystem FromModelPath(string model_path)
        {
            var dir = Directory.GetParent(model_path);
            var root = dir.Parent.FullName;

            return new CBoxSystem(root);
        }

        /// <summary>
        /// Returns the model 
        /// </summary>
        /// <param name="ident"></param>
        /// <returns></returns>
        public Model GetComponent(string ident)
        {
            var model_ref = GetComponentReference(ident);
            if (model_ref == null)
                throw new Exception("Component with given ident not found");

            // check that the file exists:
            if (!File.Exists(model_ref.Path))
                throw new Exception("Component with given ident has a path that does not exist on filesystem");

            // load the model from file XML:
            var model = Model.FromXML(File.ReadAllText(model_ref.Path));

            return model;
        }


        /// <summary>
        /// Returns the model refererence object with current ident (without loading the model).
        /// </summary>
        /// <param name="ident"></param>
        /// <returns></returns>
        private ModelReference GetComponentReference(string ident)
        {
            return (from c in Components
                    where c.Ident == ident
                    select c).FirstOrDefault();
        }


    }
}
