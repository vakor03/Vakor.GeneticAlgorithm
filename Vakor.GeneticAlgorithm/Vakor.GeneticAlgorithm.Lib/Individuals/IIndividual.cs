namespace Vakor.GeneticAlgorithm.Lib.Individuals
{
    public interface IIndividual
    {
        int GeneLength { get; }
        bool[] Genes { get;}
        double Fitness { get; set; }

        IIndividual Mutate(double mutatePossibility);
        IIndividual[] Crossover(IIndividual secondParent, double crossoverPoint);

    }
}