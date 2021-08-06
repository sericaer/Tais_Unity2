using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveMarbles.PropertyChanged;

namespace Tais
{
    class PopAbstract : IPop
    {
#pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;

        public static double MinConsume = 0.01;
        public static double MaxConsume = 1.0;

        public double num { get; set; }

        public double consume { get; set; }

        public double good { get; set; }

        public IPopDef def { get; set; }

        public IFarmWork farmWork { get; set; }

        public double per_good => good / num;

        public (int y, int m, int d) currData { get; set; }
        
        public PopAbstract(IPopInit initData, IPopDef def)
        {
            this.def = def;
            this.num = initData.num;

            if(initData.farm != null)
            {
                farmWork = new FarmWork(initData.farm.Value, this, (x) =>
                {
                    good += x;
                });

                Observable.CombineLatest(this.WhenPropertyValueChanges(x => x.per_good),
                    this.WhenPropertyValueChanges(x => x.currData).Where(x=>x.y != 0),
                    (perGood, currData) =>
                    {
                        int nextHavestDay = FarmWork.CalcDaySpanToNextHavert(currData);
                        var calc = per_good / (nextHavestDay + 10);
                        if (calc < MinConsume)
                        {
                            return MinConsume;
                        }
                        if (calc > MaxConsume)
                        {
                            return MinConsume;
                        }

                        return calc;

                    }).Subscribe(x => consume = x);
            }
        }

        public void DayInc((int y, int m, int d) date)
        {
            currData = date;
        }
    }
}
