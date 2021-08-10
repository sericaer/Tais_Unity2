using DynamicData;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tais
{
    public interface ICountry : INotifyPropertyChanged
    {
        string id { get; }

        string name { get; }

        int popNum { get; }

        int farm { get; }

        double? cropGrown { get; }

        IObservableCache<IPop, IPopDef> popMgr { get; }

        void DayInc((int y, int m, int d) date);

        IDictionary<string, double> CalcTaxDetail(TAX_LEVEL level);

        IEnumerable<IProductRegister> CollectTax(TAX_LEVEL level);
    }
}