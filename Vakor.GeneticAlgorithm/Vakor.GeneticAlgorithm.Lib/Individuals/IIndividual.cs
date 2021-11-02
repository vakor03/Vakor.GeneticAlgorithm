namespace Vakor.GeneticAlgorithm.Lib.Individuals
{
    public interface IIndividual
    {
        public int GeneLength { get; }
        public bool[] Genes { get;}
        public double Fitness { get; }
    }
}