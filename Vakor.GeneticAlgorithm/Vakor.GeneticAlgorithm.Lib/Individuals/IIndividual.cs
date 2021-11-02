namespace Vakor.GeneticAlgorithm.Lib.Individuals
{
    public interface IIndividual
    {
        int GeneLength { get; }
        bool[] Genes { get;}
        double Fitness { get; }

        void UpdateFitness(double newFitness);
        void Mutate(double mutatePossibility);
        IIndividual[] Crossover(IIndividual secondParent, double crossoverPoint);

    }
}