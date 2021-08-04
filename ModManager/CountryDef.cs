using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Tais
{
    internal class CountryDef : ICountryDef
    {
        public string path { get; set; }
        public string id { get; set; }
        public string name { get; set; }

        public IDictionary<string, int> pops { get; set; }

        public static CountryDef Load(string path)
        {
            Logger.INFO("analyze file: " + path);

            var def = JsonConvert.DeserializeObject<CountryDef>(File.ReadAllText(path));

            def.path = path;

            return def;
        }
        public CountryDef()
        {
        }
    }
}