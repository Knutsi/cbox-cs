using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace cbox.generation
{

    /// <summary>
    /// The component library holds descriptions of the sub-models that can be included
    /// into other models. 
    /// 
    /// The library is a directory of serialized Component objects that can be included 
    /// into other models to promote code reusability. Each component is identified by 
    /// it's filename.  
    /// 
    /// When modeling, Include nodes will look in the ComponentLibrary provided by the
    /// execution context, and run them.  The results will be included in the model
    /// being executed. 
    /// </summary>
    public class ComponentLibrary
    {
        /// <summary>
        /// Path to the directory holding the component library. 
        /// </summary>
        public string DirectoryPath { get; set; }

        /// <summary>
        /// The sub-models that can be included.
        /// </summary>
        public List<Model> Models = new List<Model>();

        public List<string> ModelIdents { 
            get
            {
                var list = new List<string>();
                foreach (var model in Models)
                    list.Add(model.Ident);

                return list;
            }
        }

        /// <summary>
        /// Walks through the library directory and loads all components stored there
        /// and caches the information needed for inclusion.
        /// </summary>
        public void BuildIndex()
        {

        }

        public Model GetModel(string ident)
        {
            foreach (var model in this.Models)
                if (model.Ident == ident)
                    return model;

            return null;
        }
    }
}
