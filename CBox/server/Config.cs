using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.server
{
    public class Config : XMLSerializable<Config>
    {
        public Dictionary<string, string> Mimetypes = new Dictionary<string, string>()
        {
            { ".html", "text/html" },
            { ".htm", "text/html" },
            { ".js", "text/javascript" },
            { ".css", "text/css" },
            { ".json", "application/json" },
        };

        public string SystemPath { get; set; }
        public string DocumentRoot { get; set; }
        
    }
}
