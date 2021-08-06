using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Tais
{
    internal class Mod
    {
        public string path { get; private set; }

        public IEnumerable<IPopDef> popDefs;

        public IEnumerable<ICountryDef> countryDefs;

        public Mod(string path)
        {
            Logger.INFO("load mod: " + path);

            this.path = path;

            LoadPopDef(path + "/pops");
            LoadCountryDef(path + "/countries");
        }

        private void LoadCountryDef(string path)
        {
            countryDefs = Directory.EnumerateFiles(path, "*.json").Select(x => CountryDef.Load(x)).ToList();
        }

        private void LoadPopDef(string path)
        {
            popDefs = Directory.EnumerateFiles(path, "*.json").Select(x => PopDef.Load(x)).ToList();
        }
    }
}