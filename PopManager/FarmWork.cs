using System;
using System.ComponentModel;
using ReactiveMarbles.PropertyChanged;

namespace Tais
{
    internal class FarmWork : IFarmWork
    {
#pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;

        public double farm { get; set; }
        public double per_farm => farm / popNum;

        private double popNum { get; set; }
        private Action<double> produce { get; set; }

        public static int CalcDaySpanToNextHavert((int y, int m, int d) date)
        {
            int nextHavestDay = 0;
            var dis_m = GlobalVar.grown_date_range.end.m - date.m;
            if (dis_m > 0)
            {
                nextHavestDay += dis_m * 30;
            }
            else
            {
                nextHavestDay += (12 + dis_m) * 30;
            }

            var dis_d = GlobalVar.grown_date_range.end.d - date.d;
            if (dis_d > 0)
            {
                nextHavestDay += dis_d;
            }
            else
            {
                nextHavestDay += dis_d + 30;
            }

            return nextHavestDay;
        }

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