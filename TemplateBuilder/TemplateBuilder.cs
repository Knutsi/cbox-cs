using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml;
using System.Xml.Xsl;


using System.IO;

namespace TemplateBuilder
{
    public partial class TemplateBuilder : Form
    {
        public TemplateBuilder()
        {
            InitializeComponent();

            xsltInput.TextChanged += (object s, EventArgs a) =>
            {
                Render();
            };

            xmlInput.TextChanged += (object s, EventArgs a) =>
            {
                Render();
            };

            Render();
        }

        public void Render()
        {
            try
            {
                // load the transform object and 
                var transform = new XslTransform();
                var xsl_stream = new StringReader(xsltInput.Text);
                var xsl_reader = XmlReader.Create(xsl_stream);
                transform.Load(xsl_reader);

                // load XML:
                var xml_doc = new XmlDocument();
                xml_doc.LoadXml(xmlInput.Text);

                var output = "";
                using (var writer = new StringWriter())
                {
                    transform.Transform(xml_doc.CreateNavigator(), null, writer);
                    output = writer.ToString();
                }

                renderOutput.DocumentText = output;
            }
            catch (Exception exp)
            {
                renderOutput.DocumentText = exp.ToString();
            }
        }
    }
}
