using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cbox.generation;

namespace ModelEditor.forms
{
    public partial class IssuesView : UserControl
    {
        public IssuesView()
        {
            InitializeComponent();

            Program.ModelLoaded += () =>
            {
                this.Model = Program.CurrentModel;
            };

        }

        public Model Model
        {
            get
            {
                return _Model;
            }

            set
            {



                // unwire old events:
                if(Model != null)
                    foreach (var comp in Model.Components)
                        comp.Invalidated -= Reload;

                // set new model:
                _Model = value;
                if (value == null)
                    return;
                
                // wire events for all node components:
                if(Model.Components != null)
                    foreach (var comp in Model.Components)
                        comp.Invalidated += Reload;

                Reload();
                
            }   
        }

        private Model _Model;


        private void Reload()
        {
            StringBuilder html = new StringBuilder("<html><body>");

            // render a HTML output for each component:
            foreach (var comp in Model.Components)
            {
                if (comp.Issues == null)
                    continue;

                html.AppendFormat("<h3>{0}</h3>", comp.Ident);

                foreach (var issue in comp.Issues)
                    html.Append(RenderIssue(issue));

            }

            html.Append("</body></html>");

            htmlView.DocumentText = html.ToString();
        }

        private string RenderIssue(IssueReportEntry issue)
        {
            var css_attribute = "style='font-family: arial, sans-serif; margin-bottom: 5px; padding-bottom: 5px; font-size:smaller; border-bottom: 1px dotted gray;'";

            // message for nodes:
            if (issue.Node != null)
            {

                return string.Format(
                    "<div {4}>Node: '{3}':{0}<br /><a style='font-size:smaller' href=\"\">uri://{1}/{2}/{3}</a></div>", 
                    issue.Message, 
                    issue.SourceCollection.Ident, 
                    issue.ObjectIdent,
                    issue.Node.Title,
                    css_attribute);
            }
            else
            {
                return string.Format("<div {1}><strong>{0}</strong></div>", issue.Message, css_attribute);
            }
        }
       
        
    }
}
