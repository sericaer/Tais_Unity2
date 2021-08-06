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

        public ICollectTax collectTax { get; set; }

        public double per_good => good / num;

        public (int y, int m, int d) currData { get; set; }

        public PopAbstract(IPopInit initData, IPopDef def, ICollectTax collectTax)
        {
            this.def = def;
            this.num = initData.num;
            this.collectTax = collectTax;

            if(collectTax is CollectTax @comCollectText)
            {
                this.WhenPropertyValueChanges(x => x.num)
                    .Subscribe(popNum => comCollectText.popNum = (int)popNum);
            }

            if (initData.farm != null)
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
                        var calc = per_good / (nextHavestDay + 30);
                        if (calc < MinConsume)
                        {
                            return MinConsume;
                        }
                        if (calc > MaxConsume)
                        {
                            return MaxConsume;
                        }

                        return calc;

                    }).Subscribe(x => consume = x);
            }
        }

        public void DayInc((int y, int m, int d) date)
        {
            currData = date;

            if(good > 0)
            {
                good -= consume * num;
            }
        }
    }
}
