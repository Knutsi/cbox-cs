using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using cbox.system;

namespace CBoxTest.system
{
    [TestClass]
    public class CBoxSystemTest
    {

        [TestMethod]
        public void LoadSystemDirect()
        {
            var cbs = new CBoxSystem("test_system");
            ValidateSystem(cbs);
        }


        [TestMethod]
        public void LoadSystemByModelPath()
        {
            var cbs = CBoxSystem.FromModelPath(@"test_system\Models\Model 1");
            ValidateSystem(cbs);
        }


        private void ValidateSystem(CBoxSystem cbs)
        {
            Assert.AreEqual(cbs.Models.Count, 2);
            Assert.AreEqual(cbs.Components.Count, 2);
        }
    }
}
