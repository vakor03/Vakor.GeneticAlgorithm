using System.Collections.Generic;
using Vakor.GeneticAlgorithm.Lib.Individuals;

namespace Vakor.GeneticAlgorithm.Lib.Populations
{
    public class Population : IPopulation
    {
        public int PopulationSize => _populationSize;
        public List<IIndividual> Individuals { get; }
        public IIndividual Fittest { get; }
        public IIndividual RandomAmongFitness { get; }
        public int GetLeastFittestIndex { get; }

        private int _populationSize;
        public void FormStartPopulation(int populationLength)
        {
            _populationSize = PopulationSize;
        }

        public void AddToPopulation(IIndividual individual)
        {
            throw new System.NotImplementedException();
        }
    }
}