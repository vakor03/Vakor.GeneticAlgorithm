using System;
using System.Collections.Generic;
using Vakor.GeneticAlgorithm.Lib.EvolutionAlgorithms;
using Vakor.GeneticAlgorithm.Lib.Items;

namespace Vakor.GeneticAlgorithm.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IEvolutionAlgorithm evolutionAlgorithm = new EvolutionAlgorithm();
            List<IItem> items = FormInitialItems(100);

            for (int i = 0; i < 100; i++)
            {
                int generation = i * 5;
                var backpack = evolutionAlgorithm.SolveBackpackTask(250, items, generation);
                Console.WriteLine(
                    $"Generation {generation}; Used capacity:{backpack.UsedCapacity}; Value:{backpack.ItemsValue}");
            }
        }

        private static List<IItem> FormInitialItems(int itemsCount)
        {
            Random random = new Random();
            List<IItem> items = new List<IItem>();
            for (int i = 0; i < itemsCount; i++)
            {
                IItem item = new Item
                {
                    Capacity = random.Next(1, 25),
                    Value = random.Next(2, 30)
                };
                items.Add(item);
            }

            return items;
        }
    }
}