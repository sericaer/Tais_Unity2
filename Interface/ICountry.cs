using DynamicData;
using System.ComponentModel;

namespace Tais
{
    public interface ICountry : INotifyPropertyChanged
    {
        string id { get; }

        string name { get; }

        int popNum { get; }

        int farm { get; }

        IObservableCache<IPop, IPopDef> popMgr { get; }

        void DayInc((int y, int m, int d) date);
    }
}