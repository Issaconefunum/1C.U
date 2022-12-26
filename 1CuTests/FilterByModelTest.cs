using System;
using System.Collections.Generic;
using _1C.U;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _1cuTests
{
    [TestClass]
    public class FilterByModelTest
    {
        [TestMethod]
        public void EmptyQuery()
        {
            var query = "";
            var inventoryItems = new List<InventoryItem>() { new InventoryItem() { Model = "PC" }, new InventoryItem() { Model = "rc" } };

            var result = Filter.FilterByModel(query, inventoryItems);

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void OrdinaryQuery()
        {
            var query = "PC";
            var inventoryItems = new List<InventoryItem>() { new InventoryItem() { Model = "PC" }, new InventoryItem() { Model = "rc" } };

            var result = Filter.FilterByModel(query, inventoryItems);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("PC", result[0].Model);
        }

        [TestMethod]
        public void NothingFound()
        {
            var query = "PC";
            var inventoryItems = new List<InventoryItem>() { new InventoryItem() { Model = "pC" }, new InventoryItem() { Model = "rc" } };

            var result = Filter.FilterByModel(query, inventoryItems);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void VeryLongQuery()
        {
            var query = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
            var inventoryItems = new List<InventoryItem>() { new InventoryItem() { Model = "pC" }, new InventoryItem() { Model = "rc" } };

            var result = Filter.FilterByModel(query, inventoryItems);

            Assert.AreEqual(null, result);
        }
    }
}
