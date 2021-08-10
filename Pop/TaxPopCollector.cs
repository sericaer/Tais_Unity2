using ReactiveMarbles.PropertyChanged;
using System;
using System.ComponentModel;
using System.Reactive.Linq;

namespace Tais
{
    internal class TaxPopCollector : ITaxPopCollector
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public TAX_LEVEL level { get; set; }

        public IPop pop { get; private set; }

        public double expectTax { get ; private set; }

        public TaxPopCollector(IPop pop)
        {
            this.pop = pop;
            this.level = TAX_LEVEL.Level1;

            Observable.CombineLatest(
                pop.WhenPropertyValueChanges(x => x.num),
                this.WhenPropertyValueChanges(x => x.level),
                (popNum, taxLevel) =>
                {
                    return CalcTaxFactor(taxLevel) * popNum;
                }).Subscribe(x => expectTax = x);
        }

        private double CalcTaxFactor(TAX_LEVEL level)
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

            return factor * 10;
        }

        public IProductRegister DoCollect()
        {
            pop.good -= expectTax;

            return new TaxPopRegister()
            {
                count = expectTax,
                date = GlobalVar.date,
                productor = this
            };
        }
    }

    public class TaxPopRegister : IProductRegister
    {
        public double count { get; set; }
        public (int y, int m, int d) date { get; set; }
        public IProductor productor { get; set; }
    }
}