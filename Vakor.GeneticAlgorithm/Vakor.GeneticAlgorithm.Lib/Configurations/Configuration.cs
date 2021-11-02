namespace Vakor.GeneticAlgorithm.Lib.Configurations
{
    public class Configuration
    {
        public int AlgorithmIterationCount { get; set; } = 1000;
        public double MutationsPossibility { get; set; } = .05;
        public double CrossoverPoint { get; set; } = .3;
        public int ItemsCount { get; set; }
    }
}