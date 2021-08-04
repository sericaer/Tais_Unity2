using System.Collections.Generic;

namespace Tais
{
    public class RunData
    {
        public CountryManager countyMgr;

        public RunData(
            (IEnumerable<IPopDef> popDefs,
            IEnumerable<ICountryDef> countryDefs) Def 
            )
        {
            countyMgr = new CountryManager();

            countyMgr.Build(Def.countryDefs, Def.popDefs);
        }
    }
}