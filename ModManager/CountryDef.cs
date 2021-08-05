using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Tais
{
    internal class CountryDef : ICountryDef
    {
        public string path { get; set; }
        public string id { get; set; }
        public string name { get; set; }

        public IDictionary<string, IPopInit> pops { get; set; }

        public static CountryDef Load(string path)
        {
            Logger.INFO("analyze file: " + path);

            var def = JsonConvert.DeserializeObject<CountryDef>(File.ReadAllText(path), new PopInitConverter());

            def.path = path;

            return def;
        }
        public CountryDef()
        {
        }
    }

    public class PopInitConverter : CustomCreationConverter<IPopInit>
    {
        public override IPopInit Create(Type objectType)
        {
            return new PopInit();
        }
    }

    internal class PopInit : IPopInit
    {
        public int num { get; set; }
        public int? farm { get; set; }
    }
}