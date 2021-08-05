using DynamicData;
using DynamicData.Aggregation;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tais
{
    internal class Country : ICountry
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IObservableCache<IPop, IPopDef> popMgr { get; set; }

        public string id => def.id;

        public string name => def.name;

        public int popNum { get; set; }

        public int farm { get; set; }

        public ICountryDef def { get; set; }

        public Country(ICountryDef countryDef, IEnumerable<IPopDef> popDefs)
        {
            def = countryDef;

            popMgr = new PopManager(countryDef.pops, popDefs);

            popMgr.Connect().WhenPropertyChanged(x => x.num)
                .ToObservableChangeSet()
                .Sum(x => (int)x.Value)
                .Subscribe(x => popNum = x);

            popMgr.Connect().WhenPropertyChanged(x => x.farm)
                .ToObservableChangeSet()
                .Sum(x => (int)x.Value)
                .Subscribe(x => farm = x);
        }

        public void DayInc((int y, int m, int d) date)
        {
            
        }
    }
}