﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using cbox.generation;
using cbox.generation.nodetype;

namespace CBoxTest
{
    [TestClass]
    public class BranchNodeTest
    {
        [TestMethod]
        public void PossibleSocketsTest()
        {
            var b_node = new Node("Branch node", Branch.TYPE_IDENT);

            // do we have the default setup?
            Assert.AreEqual(2, b_node.OutputSockets.Count);
        }

        [TestMethod]
        public void BranchAllTest()
        {
            var b_node = new Node("Branch node", Branch.TYPE_IDENT);
            var data = (BranchData)b_node.HandlerData;

            // make node "ALL":
            data.Mode = BranchMode.ALL;

            // add a new socket:
            data.AddPossibleSocket(new BranchDataSocketEntry("C"));

            // update handler data:
            b_node.HandlerData = data;

            Assert.AreEqual(3, b_node.OutputSockets.Count);
            Assert.AreEqual(OutputSocketType.GUARANTEED, b_node.OutputSockets[2].Type);
        }

        [TestMethod]
        public void BranchMaybeTest()
        {
            var b_node = new Node("Branch node", Branch.TYPE_IDENT);
            var data = (BranchData)b_node.HandlerData;

            // make node "ALL":
            data.Mode = BranchMode.MAYBE;

            // add a new socket - shoud now be 3 in total:
            data.AddPossibleSocket(new BranchDataSocketEntry("C"));

            b_node.HandlerData = data;  // triggers update

            Assert.AreEqual(3, b_node.OutputSockets.Count);

            /* Sockets B and C should now be marked as "possible" */
            Assert.AreEqual(OutputSocketType.GUARANTEED, b_node.OutputSockets[0].Type);
            Assert.AreEqual(OutputSocketType.POSSIBLE, b_node.OutputSockets[1].Type);
            Assert.AreEqual(OutputSocketType.POSSIBLE, b_node.OutputSockets[2].Type);

            // we should now have three possible out comes, and A should be in all:
            // {A,B}, {A,C}, {A,B,C}
            Assert.AreEqual(4, b_node.PossibleOutputCombos.Count);
        }

        [TestMethod]
        public void BranchNOffTest()
        {
            var b_node = new Node("Branch node", Branch.TYPE_IDENT);
            var data = (BranchData)b_node.HandlerData;

            // make node "ALL":
            data.Mode = BranchMode.NOFF;
            

            // add two new sockets:
            data.AddPossibleSocket(new BranchDataSocketEntry("C"));
            data.AddPossibleSocket(new BranchDataSocketEntry("D"));
            //b_node.UpdateInternals();
            b_node.HandlerData = data;  // triggers update

            /* Sockets B and C should now be marked as "possible" */
            Assert.AreEqual(OutputSocketType.GUARANTEED, b_node.OutputSockets[0].Type);
            Assert.AreEqual(OutputSocketType.POSSIBLE, b_node.OutputSockets[1].Type);
            Assert.AreEqual(OutputSocketType.POSSIBLE, b_node.OutputSockets[2].Type);
            Assert.AreEqual(OutputSocketType.POSSIBLE, b_node.OutputSockets[3].Type);

            // we have three outputs, and will first limit to n = 1:
            // Valid subsets are: {A}, {B}, {C}, {D}:
            data.N = 1;
            Assert.AreEqual(4, b_node.PossibleOutputCombos.Count);

            // n = 2:
            // Valid subsets: {A,B} {A,C} {A,D} {B,C}, {B,D}, {C,D}:
            data.N = 2;
            Assert.AreEqual(6, b_node.PossibleOutputCombos.Count);
            foreach (var set in b_node.PossibleOutputCombos)
                Assert.AreEqual(2, set.Count);

            // n = 3:
            // Valid subsets: {A,B,C}, {A,B,D}, {A,C,D}, {B,C,D}
            data.N = 3;
            Assert.AreEqual(4, b_node.PossibleOutputCombos.Count);
            foreach (var set in b_node.PossibleOutputCombos)
                Assert.AreEqual(3, set.Count);

            // n = 4
            // Valid subsets: {A.B,C,D} (same as 'all' mode):
            data.N = 4;
            Assert.AreEqual(1, b_node.PossibleOutputCombos.Count);
            foreach (var set in b_node.PossibleOutputCombos)
                Assert.AreEqual(4, set.Count);
        }
    }
}
