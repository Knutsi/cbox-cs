using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.IO;

using cbox.model;

namespace cbox.generation
{

    public delegate void ComponentAddedEvent(NodeCollection collection);
    public delegate void ComponentRemovedEvent(NodeCollection collection);

    public class Model : IdentProvider
    {
        public event ComponentAddedEvent ComponentAdded;
        public event ComponentRemovedEvent ComponentRemoved;

        public string Ident { get; set; }

        public List<NodeCollection> Components { get; set; }


        public Model() : this(false)
        {
            
        }

        public Model(bool generate_default)
        {
            Components = new List<NodeCollection>();

            if(generate_default)
            {
                var comp = new NodeCollection() { Ident = "_Root", IsRoot = true };
                Components.Add(comp);

            }
        }


        /// <summary>
        /// The root component is the component that gets executed first when the model is 
        /// run.
        /// </summary>
        [XmlIgnore]
        public NodeCollection RootComponent { 
            get
            {
                return (from comp in this.Components
                        where comp.IsRoot == true
                        select comp).First();
            }
        }


        public void AddComponent(NodeCollection comp)
        {
            // check that component is not alreay here:
            if (Components.Contains(comp))
                throw new Exception("Adding component that already exists in model");

            // add component, and make it know it's relations:
            this.Components.Add(comp);
            comp.ParentModel = this;

            // fire event:
            if (ComponentAdded != null)
                ComponentAdded(comp);
        }


        public void RemoveComponent(NodeCollection comp)
        {
            // we cannot remove root:
            if (comp.IsRoot)
                throw new Exception("Cannot remove root component");

            this.Components.Remove(comp);
            comp.ParentModel = null;

            // fire event:
            if (ComponentRemoved != null)
                ComponentRemoved(comp);
        }


        public string ToXML()
        {
            // save all handlers:
            foreach (var col in Components)
                foreach (var node in col.Nodes)
                    node.Handler.SaveData();

            // prepare to serialize:
            var serializer = new XmlSerializer(this.GetType());

            var writer = new StringWriter();
            serializer.Serialize(writer, this);
            return writer.ToString();
        }


        /// <summary>
        /// Loads the model from XML.
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static Model FromXML(string xml)
        {
            using (var reader = new StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(Model));
                var model = (Model)serializer.Deserialize(reader);

                // we now need to update references to the model in the components and nodes:
                model.UpdateInternalReferences();

                // invalidate to rebuild problem sets etc.:
                model.Invalidate();

                return model;
            }
        }

        /// <summary>
        /// Ensures all components have this model set as their parent.
        /// </summary>
        private void UpdateInternalReferences()
        {
            foreach (var comp in this.Components)
            {
                comp.ParentModel = this;
                comp.UpdateInternalReferences();
            }  
        }

        /// <summary>
        /// Causes invalidation of all components.
        /// </summary>
        public void Invalidate()
        {
            foreach (var comp in Components)
                comp.Invalidate();
        }

        public NodeCollection GetNodeCollection(string ident)
        {
            foreach (var ncol in this.Components)
                if (ncol.Ident == ident)
                    return ncol;

            return null;
        }

        public Case RandomCase
        {
            get
            {
                var rand = new Random();
                var paths = RootComponent.BuildPaths;

                if (paths != null)
                {
                    var path = paths[rand.Next(paths.Count)];
                    return RootComponent.Execute(path).Case;
                }
                else
                    return null;

            }
        }
    }
}
