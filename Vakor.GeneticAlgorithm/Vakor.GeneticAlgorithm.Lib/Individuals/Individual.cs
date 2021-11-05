using System;

namespace Vakor.GeneticAlgorithm.Lib.Individuals
{
    public class Individual : IIndividual
    {
        public int GeneLength { get; }
        public bool[] Genes { get; }
        public double Fitness { get; set; }

        public Individual(bool[] genes)
        {
            Genes = genes;
            GeneLength = genes.Length;
        }

        public IIndividual Mutate(double mutatePossibility)
        {
            Random random = new Random();
            bool[] mutatedGenes = new bool[GeneLength];
            Array.Copy(Genes, mutatedGenes, GeneLength);
            Individual mutatedIndividual = new Individual(mutatedGenes);
            if (random.NextDouble() <= mutatePossibility)
            {
                int index1 = random.Next(GeneLength);
                int index2;
                do
                {
                    index2 = random.Next(GeneLength);
                } while (index2 == index1);

                mutatedIndividual.SwapGenes(index1, index2);
            }

            return mutatedIndividual;
        }

        private void SwapGenes(int index1, int index2)
        {
            (Genes[index1], Genes[index2]) = (Genes[index2], Genes[index1]);
        }

        public IIndividual[] Crossover(IIndividual secondParent, double crossoverPoint)
        {
            if (GeneLength != secondParent.GeneLength)
            {
                throw new ArgumentException();
            }

            int geneLength = GeneLength;

            IIndividual firstChild = new Individual(new bool[geneLength]);
            IIndividual secondChild = new Individual(new bool[geneLength]);

            for (int i = 0; i < geneLength; i++)
            {
                if ((double) i / geneLength <= crossoverPoint)
                {
                    firstChild.Genes[i] = Genes[i];
                    secondChild.Genes[i] = secondParent.Genes[i];
                }
                else
                {
                    firstChild.Genes[i] = secondParent.Genes[i];
                    secondChild.Genes[i] = Genes[i];
                }
            }

            return new[] {firstChild, secondChild};
        }
    }
}