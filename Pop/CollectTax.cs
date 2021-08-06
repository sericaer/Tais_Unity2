namespace Tais
{
    internal class CollectTax : ICollectTax
    {
        public int popNum { get; set; }

        public double DoCollect(int level)
        {
            return popNum * level;
        }
    }
}