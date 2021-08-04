using System;

namespace Tais
{
    public class Facade
    {
        public static RunData runData;
        public static ModManager modManager;

        public static void LoadMods()
        {
            modManager = new ModManager();
        }

        public static void BuildRunData()
        {
            runData = new RunData(
                (modManager.popDefs, 
                 modManager.countryDefs)
                );
        }
    }
}
