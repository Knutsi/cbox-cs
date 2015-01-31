using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbox.model
{
    public class Ontology
    {
        List<Test> Tests;
        List<Action> Actions;

        public static Ontology LoadFromFile(string path)
        {
            throw new Exception("Not implemented");
        }

        public void SaveToFile(string path)
        {
            throw new Exception("Not implemented");
        }
    }
}
