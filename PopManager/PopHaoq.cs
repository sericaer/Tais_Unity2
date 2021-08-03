using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tais
{
    class PopHaoq : IPop
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public double num { get; set; }

        public double farm { get; set; }

        public double consume { get; set; }

        public IPopDef def { get; set; }

        public PopHaoq(int num, IPopDef def)
        {
            this.def = def;
            this.num = num;
        }

    }
}
