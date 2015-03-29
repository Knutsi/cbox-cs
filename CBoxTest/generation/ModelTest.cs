using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using cbox.generation;

namespace CBoxTest
{
    [TestClass]
    public class ModelTest
    {
        bool event_compadded_fired = false;
        bool event_compremoved_fired = false;

        [TestMethod]
        public void ModelSubmodelsTest()
        {
            // creat model and events:
            var model = new Model(true);
            model.ComponentAdded += model_ComponentAdded;
            model.ComponentRemoved += model_ComponentRemoved;

            Assert.AreEqual(0, model.Submodels.Count);
            Assert.IsTrue(!event_compadded_fired && !event_compremoved_fired);

            // add a component:
            var A = new NodeCollection();
            model.AddComponent(A);

            Assert.AreEqual(1, model.Submodels.Count);
            Assert.IsTrue(event_compadded_fired && !event_compremoved_fired);

            model.RemoveComponent(A);
            Assert.AreEqual(0, model.Submodels.Count);
            Assert.IsTrue(event_compadded_fired && event_compremoved_fired);
        }

        void model_ComponentAdded(NodeCollection collection)
        {
            event_compadded_fired = true;
        }


        void model_ComponentRemoved(NodeCollection collection)
        {
            event_compremoved_fired = true;
        }

    }
}
