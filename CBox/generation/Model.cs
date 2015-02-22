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
        public int Ident { get; set; }

        public List<Component> Components { get; set; }


        public Model() : this(false)
        {
            
        }

        public Model(bool generate_default)
        {
            Components = new List<Component>();

            if(generate_default)
            {
                var comp = new Component() { IsRoot = true };
                Components.Add(comp);
                    
            }
        }


        /// <summary>
        /// The root component is the component that gets executed first when the model is 
        /// run.
        /// </summary>
        [XmlIgnore]
        public Component RootComponent { 
            get
            {
                return (from comp in this.Components
                        where comp.IsRoot == true
                        select comp).First();
            }
        }


        public void AddComponent(Component comp)
        {
            this.Components.Add(comp);
            comp.ParentModel = this;
        }


        public void RemoveComponent(Component comp)
        {
            this.Components.Remove(comp);
            comp.ParentModel = null;
        }


        public string ToXML()
        {
            // prepare to serialize:
            var serializer = new XmlSerializer(this.GetType());

            /* Create a StreamWriter to write with. First create a FileStream
            object, and create the StreamWriter specifying an Encoding to use. */
            using (MemoryStream ms = new MemoryStream())
            {
                using (TextWriter writer = new StreamWriter(ms, new UTF8Encoding()))
                {
                    // Serialize using the XmlTextWriter.
                    serializer.Serialize(writer, this);

                    ms.Position = 0;
                    StreamReader reader = new StreamReader(ms);
                    return reader.ReadToEnd();
                }
            }
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
    }
}
