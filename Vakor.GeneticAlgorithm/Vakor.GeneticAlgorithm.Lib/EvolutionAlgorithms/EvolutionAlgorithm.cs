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
        private readonly IPopulation _population = new Population();
        private readonly Configuration _configuration = new();
        private List<IIndividual> _offsprings = new();
        private IItem[] _allItems;
        private IBackpack _backpack;

        public IBackpack SolveBackpackTask(int maxBackpackCap, IEnumerable<IItem> items, int generationCount)
        {
            _allItems = items as IItem[] ?? items.OrderByDescending(item => item.Value / item.Capacity).ToArray();
            _backpack = new Backpack(maxBackpackCap);
            _configuration.GenerationCount = generationCount;
            FormStartPopulation();

            for (int i = 0; i < _configuration.GenerationCount; i++)
            {
                FormNewGeneration();
            }

            _backpack.FillBackpack(_allItems, _population.Fittest.Genes);
            return _backpack;
        }

        private void FormStartPopulation()
        {
            _population.FormStartPopulation(_allItems.Length);
            foreach (var individual in _population.Individuals)
            {
                individual.Fitness = CalculateIndividualFitness(individual);
            }
        }

        private void FormNewGeneration()
        {
            IIndividual[] parents = ChooseParents();
            _offsprings.AddRange(parents[0].Crossover(parents[1], _configuration.CrossoverPoint));

            MutateOffSprings();
            LocalBetterFunction();
            UpdateOffspringsFitness();
            AddOffspringsToPopulation();
        }

        private void MutateOffSprings()
        {
            for (int i = 0; i < _offsprings.Count; i++)
            {
                IIndividual mutatedOffspring = _offsprings[i].Mutate(_configuration.MutationsPossibility);
                if (OffspringIsAlive(mutatedOffspring))
                {
                    _offsprings[i] = mutatedOffspring;
                }
            }
        }

        private void LocalBetterFunction()
        {
            foreach (var individual in _offsprings)
            {
                int indexer = 0;
                while (indexer < individual.GeneLength - 1 && individual.Genes[indexer])
                {
                    indexer++;
                }

                individual.Genes[indexer] = true;
            }
        }

        private void UpdateOffspringsFitness()
        {
            foreach (var individual in _offsprings)
            {
                individual.Fitness = CalculateIndividualFitness(individual);
            }
        }

        private IIndividual[] ChooseParents()
        {
            return new[] {_population.Fittest, _population.Random};
        }

        private bool OffspringIsAlive(IIndividual offspring)
        {
            return CalculateIndividualCapacity(offspring) <= _backpack.MaxCapacity;
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
            RemoveAllDeadOffsprings();
            foreach (var individual in _offsprings.Where(os =>
                _population.Individuals.Count(ind => ind.Genes.SequenceEqual(os.Genes)) == 0))

            {
                _population.AddToPopulation(individual);
            }

            _offsprings.Clear();
        }

        private void RemoveAllDeadOffsprings()
        {
            _offsprings = _offsprings.Where(OffspringIsAlive).ToList();
        }
    }
}