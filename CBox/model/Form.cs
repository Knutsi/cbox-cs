using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using System.Xml.Serialization;

namespace cbox.model
{
    public class Form
    {
        public int Ident { get; set; }
        public string HeadColor { get; set; }
        public string Title { get; set; }

        public BindingList<Headline> Headlines { get; set; }

        public Form()
        {
            Headlines = new BindingList<Headline>();
            Title = "Untitled form";
        }

        public void AddHeadline(string title)
        {
            var headline = new Headline();
            headline.Title = title;

            this.Headlines.Add(headline);
        }

        public void RemoveHeadline(Headline headline)
        {
            this.Headlines.Remove(headline);
        }
    }
}
