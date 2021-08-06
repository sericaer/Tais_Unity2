using DynamicData;
using DynamicData.Aggregation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using ReactiveMarbles.PropertyChanged;
using System.Linq;
using PropertyChanged;


namespace Tais
{
    internal class Country : ICountry
    {
#pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;

        public IObservableCache<IPop, IPopDef> popMgr { get; set; }

        public string id => def.id;

        public string name => def.name;

        public double? cropGrown { get; set; }

        public int popNum { get; set; }

        public int farm { get; set; }

        public ICountryDef def { get; set; }

        private Crop crop;

        public Country(ICountryDef countryDef, IEnumerable<IPopDef> popDefs)
        {
            def = countryDef;

            crop = new Crop();

            popMgr = new PopManager(countryDef.pops, popDefs);

            popMgr.Connect().WhenPropertyChanged(x => x.num)
                .ToObservableChangeSet()
                .Sum(x => (int)x.Value)
                .Subscribe(x => popNum = x);

            popMgr.Connect().Transform(x=>x.farmWork).Filter(x=>x == null)
                .WhenPropertyChanged(x => x.farm)
                .ToObservableChangeSet()
                .Sum(x => (int)x.Value)
                .Subscribe(x => farm = x);

            crop.WhenPropertyValueChanges(x => x.growPercent)
                .Subscribe(x => cropGrown = x);

            crop.WhenHavest = (grownPercent) =>
            {
                foreach(var farmWork in popMgr.Items.Select(x => x.farmWork).OfType<IFarmWork>())
                {
                    farmWork.Havest(grownPercent);
                }
            };
        }

        public void DayInc((int y, int m, int d) date)
        {
            crop.DayInc(date);

            foreach(var pop in popMgr.Items)
            {
                pop.DayInc(date);
            }
        }

        public IDictionary<string, double> CalcTaxDetail(int level)
        {
            return popMgr.Items.Where(x=>x.collectTax!= null)
                .ToDictionary(p => p.def.type, p => p.collectTax.DoCollect(level));
        }
    }
}