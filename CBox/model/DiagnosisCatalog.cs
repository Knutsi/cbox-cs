using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace cbox.model
{
    public class DiagnosisCatalog
    {
        public List<DiagnosisCatalogEntry> Entries = new List<DiagnosisCatalogEntry>();

        public static DiagnosisCatalog LoadICD10(string path)
        {
            var file = new FileInfo(path);
            if (!file.Exists)
                throw new Exception("File does not exist");

            // read lines:
            var lines = File.ReadAllLines(file.FullName);

            var catalog = new DiagnosisCatalog();
            catalog.Entries = (from l in lines select DiagnosisCatalogEntry.FromLineICD10(l)).ToList();

            return catalog;
        }

        public List<DiagnosisCatalogEntry> Search(string query)
        {
            if (query.Trim() == string.Empty)
                return new List<DiagnosisCatalogEntry>();

            // search (got to love linq):
            var results = from e in Entries
                          where e.Name.ToLower().Contains(query) || e.Code.ToLower().Contains(query)
                          select e;

            return results.ToList();
        }
    }
}
