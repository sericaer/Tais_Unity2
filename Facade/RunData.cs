using ReactiveMarbles.PropertyChanged;

using System;
using System.Collections.Generic;

namespace Tais
{
    public class RunData
    {
        public CountryManager countyMgr;
        public ProductManager productMgr;

        public IDate date;

        public RunData(
            (IEnumerable<IPopDef> popDefs,
            IEnumerable<ICountryDef> countryDefs) Def 
            )
        {

            date = new Date();
            countyMgr = new CountryManager();
            productMgr = new ProductManager();

            countyMgr.Build(Def.countryDefs, Def.popDefs);

            date.WhenPropertyValueChanges(x => x.value).Subscribe(dateValue =>
            {
                GlobalVar.date = dateValue;
                countyMgr.DayInc(dateValue);
            });
        }

        public void DayInc()
        {
            date.Inc();
        }
    }
}