using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace cbox.model
{
    public class TreatmentCatalog : List<TreatmentCatalogEntry>
    {
        public static TreatmentCatalog LoadJSON(string filepath)
        {
            var catalog = new TreatmentCatalog();

            // deserialize the file: 
            using (FileStream fs = File.OpenRead(filepath))
            {
                //Stream responseStream = e.Result;
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(List<TreatmentCatalogEntry>));
                var entries = (List<TreatmentCatalogEntry>)deserializer.ReadObject(fs);
                catalog.AddRange(entries);
            }

            // ensure no empty modifiers:
            foreach (var entry in catalog)
            {
                if (entry.Modifiers == null)
                    entry.Modifiers = new List<string>();
            }

            return catalog;
        }

        public List<TreatmentCatalogEntry> Search(string query, bool tradenames=false)
        {
            if (query.Trim() == string.Empty)
                return new List<TreatmentCatalogEntry>();

            // search (got to love linq):
            List<TreatmentCatalogEntry> results;

            if (tradenames)
                results = (from e in this where e.Title.ToLower().Contains(query) select e).ToList();
            else
                results = (from e in this where e.Title.ToLower().Contains(query) && e.Class != "drug" select e).ToList();


            return results.ToList();
        }
    }
}
