using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace cbox.generation.nodetype
{
    public class BaseHandlerData
    {
        public List<OutputSocket> OutputSockets = new List<OutputSocket>();

        public string ToXML()
        {
            var writer = new StringWriter();
            var serializer = new XmlSerializer(typeof(BaseHandlerData));
            serializer.Serialize(writer, this);

            return writer.ToString();
        }

        public static BaseHandlerData FromXML(string xml)
        {
            using (var reader = new StringReader(xml))
            {
                var deser = new XmlSerializer(typeof(BaseHandlerData));
                var data = (BaseHandlerData)deser.Deserialize(reader);

                return data;
            }
        }

        public BaseHandlerData()
        {
            // default to one output socket:
            //OutputSockets.Add(new OutputSocket());
        }
    }
}
