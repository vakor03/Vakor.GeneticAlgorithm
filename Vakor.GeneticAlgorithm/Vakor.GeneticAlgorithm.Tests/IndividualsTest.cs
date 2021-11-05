using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vakor.GeneticAlgorithm.Lib.Individuals;

namespace Vakor.GeneticAlgorithm.Tests
{
    [TestClass]
    public class IndividualsTest
    {
        [TestMethod]
        public void UpdateFitnessTest()
        {
            IIndividual individual = new Individual(new[] {true, false, false, false});

            Assert.AreEqual(0, individual.Fitness);

            individual.Fitness = (12);
            Assert.AreEqual(12, individual.Fitness);
        }

        [TestMethod]
        public void MutateTest()
        {
            IIndividual individual = new Individual(new[] {true, false});
            individual.Mutate(1);

            Assert.AreEqual(false, individual.Genes[0]);
            Assert.AreEqual(true, individual.Genes[1]);
        }

        [TestMethod]
        public void CrossoverTest()
        {
            bool[] secondGenes = {false, true, false, false, true};
            bool[] firstGenes = {true, false, false, false, false};
            IIndividual individual = new Individual(firstGenes);
            var offsprings = individual.Crossover(new Individual(secondGenes), .19);

            Assert.AreEqual(true, offsprings[1].Genes.SequenceEqual(new[] {false, false, false, false, false}));
            Assert.AreEqual(true, offsprings[0].Genes.SequenceEqual(new[] {true, true, false, false, true}));
        }

        [TestMethod]
        public void CrossoverDifferentGeneLengthTest()
        {
            bool[] secondGenes = {false, true, false, false, true};
            bool[] firstGenes = {true, false, false, false};
            IIndividual individual = new Individual(firstGenes);
            Assert.ThrowsException<ArgumentException>(()=>individual.Crossover(new Individual(secondGenes), .19));
        }
    }
}