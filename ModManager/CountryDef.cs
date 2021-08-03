using System.Collections.Generic;

namespace Tais
{
    internal class CountryDef : ICountryDef
    {
        public string id { get; set; }
        public string name { get; set; }

        public IDictionary<string, int> pops { get; set; }

        public CountryDef(string id, string name)
        {
            this.id = id;
            this.name = name;
            this.pops = new Dictionary<string, int>()
            {
                { "haoqiang", 1000},
                { "minhu", 50000},
                { "yinhu", 20000},
                { "zeikou", 1000}
            };
        }
    }
}