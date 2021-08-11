using System;
using System.Reactive.Linq;
using System.ComponentModel;
using ReactiveMarbles.PropertyChanged;

namespace Tais
{
    internal class FarmWork : IFarmWork
    {
#pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;
        public IPop pop { get; set; }

        public double farm { get; set; }

        public double per_farm { get; set; }

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

        public FarmWork(int farm, IPop pop)
        {
            this.farm = farm;

            Observable.CombineLatest(
                pop.WhenPropertyValueChanges(x => x.num),
                this.WhenPropertyValueChanges(x => x.farm),
                (popNum, farmCount) =>
                {
                    return farmCount / popNum;
                }).Subscribe(x=>per_farm = x);
        }

        public void Havest(double grownPercent)
        {
            var good = farm * grownPercent * 5 / 100;
            pop.good += good;
        }
    }
}