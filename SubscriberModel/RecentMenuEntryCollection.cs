using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntologyEditor
{
    public class RecentMenuEntryCollection: List<RecentMenuEntry>
    {
        public void Add(string filepath)
        {
            if(!this.ContainsPath(filepath))
            {
                var entry = new RecentMenuEntry()
                {
                    Name = filepath,
                    FilePath = filepath
                };

                this.Add(entry);
                Console.WriteLine(String.Format("Added {0} to recents", entry.FilePath));
            }
            
        }

        public bool ContainsPath(string filepath)
        {
            foreach (var entry in this)
                if (entry.FilePath == filepath)
                    return true;

            return false;
        }
    }
}
