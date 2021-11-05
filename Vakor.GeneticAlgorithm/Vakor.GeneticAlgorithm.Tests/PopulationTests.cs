using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vakor.GeneticAlgorithm.Lib.Individuals;
using Vakor.GeneticAlgorithm.Lib.Populations;

namespace Vakor.GeneticAlgorithm.Tests
{
    [TestClass]
    public class PopulationTests
    {
        private IPopulation _population;
        [TestInitialize]
        public void TestInitialize()
        {
            _population = new Population();
            _population.FormStartPopulation(3);

            _population.Individuals[0].Fitness = 12;
            _population.Individuals[1].Fitness = 22.3;
            _population.Individuals[2].Fitness = 0;
        }
        
        [TestMethod]
        public void FittestIndividualTest()
        {
            Assert.AreEqual(_population.Individuals[1], _population.Fittest);
        }

        [TestMethod]
        public void RandomIndividualTest()
        {
            Assert.AreNotEqual(_population.Individuals[1], _population.Random);
        }

        [TestMethod]
        public void LeastFittestIndividualTest()
        {
            Assert.AreEqual(2, _population.LeastFittestIndex);
        }

        [TestMethod]
        public void AddToPopulationTest()
        {
            _population.AddToPopulation(new Individual(new[] {true, true, true}) {Fitness = 11});

            Assert.AreEqual(11, _population.Individuals[_population.LeastFittestIndex].Fitness);
        }

        [TestMethod]
        public void FormStartPopulationTest()
        {
            IPopulation population = new Population();
            population.FormStartPopulation(3);

            Assert.AreEqual(3, population.PopulationSize);
            Assert.AreEqual(true, population.Individuals[0].Genes.SequenceEqual(new[] {true, false, false}));
            Assert.AreEqual(true, population.Individuals[1].Genes.SequenceEqual(new[] {false, true, false}));
            Assert.AreEqual(true, population.Individuals[2].Genes.SequenceEqual(new[] {false, false, true}));
        }

        
    }
}