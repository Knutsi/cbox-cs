using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using cbox.model;

namespace CBoxTest
{
    [TestClass]
    public class OntologyTest
    {
        [TestMethod]
        public void LoadFromFile()
        {
            
        }

        [TestMethod]
        public void SaveToFile()
        {
            var ontology = new Ontology();
            string filepath = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".csv";
            ontology.SaveToFile(filepath);
        }
    }
}
