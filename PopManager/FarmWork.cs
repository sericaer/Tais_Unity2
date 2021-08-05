using System;
using System.ComponentModel;
using ReactiveMarbles.PropertyChanged;

namespace Tais
{
    internal class FarmWork : IFarmWork
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public double farm { get; set; }
        public double per_farm => farm / popNum;

        private double popNum { get; set; }
        private Action<double> produce { get; set; }

        public FarmWork(int farm, IPop pop, Action<double> produce)
        {
            this.farm = farm;
            this.produce = produce;
            pop.WhenPropertyValueChanges(x => x.num).Subscribe(x => popNum = x);
        }

        public void Havest(double grownPercent)
        {
            var good = farm * grownPercent / 100;
            produce?.Invoke(good);
        }
    }
}