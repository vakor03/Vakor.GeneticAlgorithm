using System.Collections.Generic;
using Vakor.GeneticAlgorithm.Lib.Individuals;

namespace Vakor.GeneticAlgorithm.Lib.Populations
{
    public interface IPopulation
    {
        int PopulationSize { get; }
        List<IIndividual> Individuals { get; }
        IIndividual Fittest { get; }
        IIndividual RandomAmongFitness { get; }
        int GetLeastFittestIndex { get; }
        
        void FormStartPopulation(int populationLength);
        void AddToPopulation(IIndividual individual);
    }
}