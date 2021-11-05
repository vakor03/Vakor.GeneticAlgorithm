using System.Collections.Generic;
using Vakor.GeneticAlgorithm.Lib.Individuals;

namespace Vakor.GeneticAlgorithm.Lib.Populations
{
    public interface IPopulation
    {
        int PopulationSize { get; }
        IIndividual[] Individuals { get; }
        IIndividual Fittest { get; }
        IIndividual Random { get; }
        int LeastFittestIndex { get; }
        
        void FormStartPopulation(int populationLength);
        void AddToPopulation(IIndividual individual);
    }
}