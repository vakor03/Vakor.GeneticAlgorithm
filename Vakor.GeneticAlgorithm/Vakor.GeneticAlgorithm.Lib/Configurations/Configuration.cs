namespace Vakor.GeneticAlgorithm.Lib.Configurations
{
    public class Configuration
    {
        public int GenerationCount { get; set; } = 1000;
        public double MutationsPossibility { get; set; } = .05;
        public double CrossoverPoint { get; set; } = .3;
    }
}