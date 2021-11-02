using System.Collections.Generic;
using Vakor.GeneticAlgorithm.Lib.Backpacks;
using Vakor.GeneticAlgorithm.Lib.Items;

namespace Vakor.GeneticAlgorithm.Lib.EvolutionAlgorithms
{
    public interface IEvolutionAlgorithm
    {
        IBackpack SolveBackpackTask(int maxBackpackCap, IEnumerable<IItem> items);
    }
}