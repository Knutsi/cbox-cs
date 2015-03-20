using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.IO;

namespace cbox.generation
{
    public class Model : IdentProvider
    {
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
            this.Components.Add(comp);
            comp.ParentModel = this;
        }


        public void RemoveComponent(NodeCollection comp)
        {
            this.Components.Remove(comp);
            comp.ParentModel = null;
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
    }
}
