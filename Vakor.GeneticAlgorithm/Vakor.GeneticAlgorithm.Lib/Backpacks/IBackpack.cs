using System.Collections.Generic;
using Vakor.GeneticAlgorithm.Lib.Items;

namespace Vakor.GeneticAlgorithm.Lib.Backpacks
{
    public interface IBackpack
    {
        int Capacity { get;}
        List<IItem> BackpackItems { get; } 

        void FillBackpack(IItem[] allItems, bool[] genes);

    }
}