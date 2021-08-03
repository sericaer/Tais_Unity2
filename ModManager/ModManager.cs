using System;
using System.Collections.Generic;

namespace Tais
{
    public class ModManager
    {
        public IEnumerable<IPopDef> popDefs;
        public IEnumerable<ICountryDef> countryDefs;

        public ModManager()
        {
            countryDefs = new List<ICountryDef>()
            {
                new CountryDef("1", "jixian1"),
                new CountryDef("2", "jixian2"),
                new CountryDef("3", "jixian3"),
                new CountryDef("4", "jixian4"),
                new CountryDef("5", "jixian5"),
            };

            popDefs = new List<IPopDef>()
            {
                new PopDef(){ type = "haoqiang"},
                new PopDef(){ type = "minhu"},
                new PopDef(){ type = "yinhu"},
                new PopDef(){ type = "zeikou" }
            };
        }
    }
}
