using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml.Serialization;

namespace cbox
{
    public class XMLSerializable<T> where T : new()
    {
        public string ToXML()
        {
            var writer = new StringWriter();
            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(writer, this);

            return writer.ToString();
        }

        public static T FromXML(string xml)
        {
            if (xml != null && xml != String.Empty)
            {
                using (var reader = new StringReader(xml))
                {
                    var deser = new XmlSerializer(typeof(T));
                    var data = (T)deser.Deserialize(reader);

                    return data;
                }
            }
            else
                return new T();
        }
    }
}
