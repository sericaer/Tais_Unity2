using System;
using System.Collections;
using System.Collections.Generic;

namespace Tais
{
    public class CountryManager : IEnumerable<ICountry>
    {
        private List<ICountry> all;

        public IEnumerator<ICountry> GetEnumerator()
        {
            return ((IEnumerable<ICountry>)all).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)all).GetEnumerator();
        }

        public void Build(IEnumerable<ICountryDef> countryDefs, IEnumerable<IPopDef> popDefs)
        {
            all = new List<ICountry>();
            
            foreach(var def in countryDefs)
            {
                all.Add(new Country(def, popDefs));
            }
        }


    }
}