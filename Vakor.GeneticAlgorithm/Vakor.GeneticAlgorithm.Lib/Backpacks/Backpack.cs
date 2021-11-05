using System;
using System.Collections.Generic;
using System.Linq;
using Vakor.GeneticAlgorithm.Lib.Items;

namespace Vakor.GeneticAlgorithm.Lib.Backpacks
{
    public class Backpack : IBackpack
    {
        public double MaxCapacity { get;}
        public double UsedCapacity => _items.Sum(i => i.Capacity);
        public List<IItem> BackpackItems => _items;
        public double ItemsValue => _items.Sum(i => i.Value);


        private readonly List<IItem> _items = new();
        
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
            MaxCapacity = capacity;
        }
    }
}