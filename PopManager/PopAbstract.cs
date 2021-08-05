using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tais
{
    class PopAbstract : IPop
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public double num { get; set; }

        public double consume { get; set; }

        public double good { get; set; }

        public IPopDef def { get; set; }

        public IFarmWork farmWork { get; set; }

        public double per_good => good / num;

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
            }
        }
    }
}
