using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ReactiveMarbles.PropertyChanged;

namespace Tais
{
    class PopHaoq : PopAbstract
    {
        public PopHaoq(IPopInit initData, IPopDef def) : base(initData, def)
        {
            taxCollector = new TaxPopCollector(this);
        }
    }
}
