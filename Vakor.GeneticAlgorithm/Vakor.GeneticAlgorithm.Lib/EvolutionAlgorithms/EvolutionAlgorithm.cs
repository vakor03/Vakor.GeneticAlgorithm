using System;
using System.Collections.Generic;
using System.Linq;
using Vakor.GeneticAlgorithm.Lib.Backpacks;
using Vakor.GeneticAlgorithm.Lib.Configurations;
using Vakor.GeneticAlgorithm.Lib.Individuals;
using Vakor.GeneticAlgorithm.Lib.Items;
using Vakor.GeneticAlgorithm.Lib.Populations;

namespace Vakor.GeneticAlgorithm.Lib.EvolutionAlgorithms
{
    public class EvolutionAlgorithm : IEvolutionAlgorithm
    {
        private IPopulation _population;
        private Configuration _configuration = new();
        private List<IIndividual> _offsprings = new();
        private IItem[] _allItems;
        private IBackpack _backpack;

        public IBackpack SolveBackpackTask(int maxBackpackCap, IEnumerable<IItem> items)
        {
            
            _allItems = items as IItem[] ?? items.ToArray();
            _configuration.ItemsCount = _allItems.Count();
            _backpack = new Backpack(maxBackpackCap);
            _population.FormStartPopulation(_allItems.Length);
            for (int i = 0; i < _configuration.AlgorithmIterationCount; i++)
            {
                IIndividual[] parents = ChooseParents();
                
                for (int j = 0; j < parents.Length / 2; j++)
                {
                    _offsprings.AddRange(parents[j * 2].Crossover(parents[j * 2 + 1], _configuration.CrossoverPoint));
                }

                MutateOffSprings();
                RemoveAllDeadOffsprings();
                UpdateOffspringsFitness();
                AddOffspringsToPopulation();
            }
            _backpack.FillBackpack(_allItems, _population.Fittest.Genes);
            return _backpack;
        }

        private void MutateOffSprings()
        {
            foreach (var individual in _offsprings)
            {
                individual.Mutate(_configuration.MutationsPossibility);
            }
        }

        private void UpdateOffspringsFitness()
        {
            foreach (var individual in _offsprings)
            {
                individual.UpdateFitness(CalculateIndividualFitness(individual));
            }
        }
        private IIndividual[] ChooseParents()
        {
            IIndividual firstParent = _population.Fittest;
            IIndividual secondParent = _population.RandomAmongFitness;

            return new[] {firstParent, secondParent};
        }


        private void RemoveAllDeadOffsprings()
        {
            _offsprings = _offsprings.Where(o => CalculateIndividualCapacity(o) <= _backpack.Capacity).ToList();
        }

        private double CalculateIndividualCapacity(IIndividual individual)
        {
            double individualCapacity = 0;
            for (int i = 0; i < individual.GeneLength; i++)
            {
                individualCapacity += (individual.Genes[i] ? 1 : 0) * _allItems[i].Capacity;
            }

            return individualCapacity;
        }
        
        private double CalculateIndividualFitness(IIndividual individual)
        {
            double individualFitness = 0;
            for (int i = 0; i < individual.GeneLength; i++)
            {
                individualFitness += (individual.Genes[i] ? 1 : 0) * _allItems[i].Value;
            }

            return individualFitness;
        }

        private void AddOffspringsToPopulation()
        {
            foreach (var individual in _offsprings)
            {
                _population.AddToPopulation(individual);
            }
            _offsprings.Clear();
        }
    }
}