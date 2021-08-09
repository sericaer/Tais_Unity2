using System;

namespace Tais
{
    internal class CollectTax : ICollectTax
    {
        public int popNum { get; set; }

        public Action<double> doCollect;

        public double CalcTax(TAX_LEVEL level)
        {
            double factor = 0.0;
            switch(level)
            {
                case TAX_LEVEL.Level1:
                    factor = 0.1;
                    break;
                case TAX_LEVEL.Level2:
                    factor = 0.5;
                    break;
                case TAX_LEVEL.Level3:
                    factor = 1;
                    break;
                case TAX_LEVEL.Level4:
                    factor = 1.5;
                    break;
                case TAX_LEVEL.Level5:
                    factor = 1.8;
                    break;
            }

            return popNum * factor * 10;
        }
        public void DoCollect(TAX_LEVEL level)
        {
            doCollect?.Invoke(CalcTax(level));
        }
    }
}