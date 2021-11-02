using System;
using System.Collections.Generic;
using Vakor.GeneticAlgorithm.Lib.Items;

namespace Vakor.GeneticAlgorithm.Lib.Backpacks
{
    public class Backpack : IBackpack
    {
        public int Capacity { get;}
        public List<IItem> BackpackItems => _items;

        private List<IItem> _items = new();

        public void FillBackpack(IItem[] allItems, bool[] genes)
        {
            if (allItems.Length!= genes.Length)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < genes.Length; i++)
            {
                if (genes[i])
                {
                    _items.Add(allItems[i]);
                }
            }
        }

        public Backpack(int capacity)
        {
            Capacity = capacity;
        }
    }
}