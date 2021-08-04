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

        public double farm { get; set; }

        public double consume => per_farm * 100;

        public IPopDef def { get; set; }

        public double per_farm => farm / num;

        public PopAbstract(IPopInit initData, IPopDef def)
        {
            this.def = def;
            this.num = initData.num;
            this.farm = initData.farm;
        }
    }
}
