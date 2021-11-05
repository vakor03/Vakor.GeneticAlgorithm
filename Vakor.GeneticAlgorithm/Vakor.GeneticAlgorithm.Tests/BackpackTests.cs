using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vakor.GeneticAlgorithm.Lib.Backpacks;
using Vakor.GeneticAlgorithm.Lib.Items;

namespace Vakor.GeneticAlgorithm.Tests
{
    [TestClass]
    public class BackpackTests
    {
        [TestMethod]
        public void FillBackpackExceptionTest()
        {
            Backpack backpack = new Backpack(25);
            Assert.ThrowsException<ArgumentException>(()=>backpack.FillBackpack(new IItem[20], new bool[15]));
        }
        
        [TestMethod]
        public void FillBackpackTest()
        {
            Backpack backpack = new Backpack(25);
            var firstItem = new Item {Capacity = 2, Value = 4};
            backpack.FillBackpack(new[] {firstItem, new Item {Capacity = 3, Value = 3}},
                new[] {true, false});
            Assert.AreEqual(2,backpack.UsedCapacity);
            Assert.AreEqual(1, backpack.BackpackItems.Count);
            Assert.AreEqual(firstItem, backpack.BackpackItems[0]);
        }
    }
}