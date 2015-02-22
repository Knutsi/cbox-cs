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
        public Component RootComponent { get; set; }

        public Model(bool generate_default = false)
        {
            Components = new List<Component>();

            if(generate_default)
            {
                var comp = new Component();
                Components.Add(comp);
                RootComponent = comp;
                    
            }
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
                return (Model)serializer.Deserialize(reader);
            }
        }
    }
}
