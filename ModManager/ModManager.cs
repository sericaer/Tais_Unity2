using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tais
{
    public class ModManager
    {
        public IEnumerable<IPopDef> popDefs => mods.SelectMany(x => x.popDefs);
        public IEnumerable<ICountryDef> countryDefs => mods.SelectMany(x => x.countryDefs);

        private List<Mod> mods;

        public ModManager(string path)
        {
            Logger.INFO("load mods start");
            
            mods = Directory.EnumerateDirectories(path).Select(x => new Mod(x)).ToList();

            Logger.INFO("load mods finish");
        }
    }
}
