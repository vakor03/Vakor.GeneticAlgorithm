using System.Collections.Generic;
using Vakor.GeneticAlgorithm.Lib.Items;

namespace Vakor.GeneticAlgorithm.Lib.Backpacks
{
    public interface IBackpack
    {
        double MaxCapacity { get;}
        public double UsedCapacity { get; }
        List<IItem> BackpackItems { get; }
        double ItemsValue { get; }

        void FillBackpack(IItem[] allItems, bool[] genes);

    }
}