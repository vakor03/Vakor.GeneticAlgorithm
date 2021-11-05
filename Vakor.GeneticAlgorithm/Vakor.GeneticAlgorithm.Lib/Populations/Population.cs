using System;
using Vakor.GeneticAlgorithm.Lib.Individuals;

namespace Vakor.GeneticAlgorithm.Lib.Populations
{
    public class Population : IPopulation
    {
        public int PopulationSize => _individuals.Length;
        public IIndividual[] Individuals => _individuals;
        public IIndividual Fittest => _individuals[GetFittestIndex()];
        public IIndividual Random => _individuals[GetRandomAmongBestIndex()];
        public int LeastFittestIndex => GetLeastFittestIndex();
        
        private IIndividual[] _individuals;
        
        public void FormStartPopulation(int populationLength)
        {
            _individuals = new IIndividual[populationLength];
            for (int i = 0; i < populationLength; i++)
            {
                bool[] genes = new bool[populationLength];
                genes[i] = true;
                _individuals[i] = new Individual(genes);
            }
        }
        
        private int GetFittestIndex()
        {
            double bestFitness = 0;
            int bestFitnessId = -1;

            for (var i = 0; i < _individuals.Length; i++)
            {
                if (_individuals[i].Fitness > bestFitness)
                {
                    bestFitness = _individuals[i].Fitness;
                    bestFitnessId = i;
                }
            }

            if (bestFitnessId==-1)
            {
                throw new ArgumentException();
            }
            
            return bestFitnessId;
        }
        
        private int GetLeastFittestIndex()
        {
            double leastFitness = double.MaxValue;
            int leastFittestIndex = -1;

            for (var i = 0; i < _individuals.Length; i++)
            {
                if (_individuals[i].Fitness < leastFitness)
                {
                    leastFitness = _individuals[i].Fitness;
                    leastFittestIndex = i;
                }
            }

            if (leastFittestIndex==-1)
            {
                throw new ArgumentException();
            }
            
            return leastFittestIndex;
        }
        
        public void AddToPopulation(IIndividual individual)
        {
            if (individual.Fitness >= _individuals[GetLeastFittestIndex()].Fitness)
            {
                _individuals[GetLeastFittestIndex()] = individual;
            }
        }

        private int GetRandomAmongBestIndex()
        {
            Random random = new Random();
            int randomIndex;
            do
            {
                randomIndex = random.Next(PopulationSize);
            } while (randomIndex==GetFittestIndex());

            return randomIndex;
        }
    }
}