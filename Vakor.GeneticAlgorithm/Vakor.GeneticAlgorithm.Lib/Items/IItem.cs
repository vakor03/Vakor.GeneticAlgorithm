namespace Vakor.GeneticAlgorithm.Lib.Items
{
    public interface IItem
    {
        public string Name { get; set; }
        public double Capacity { get; set; }
        public double Value { get; set; }
    }
}