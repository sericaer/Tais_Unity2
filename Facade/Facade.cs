using System;

namespace Tais
{
    public class Facade
    {
        public static RunData runData;
        public static ModManager modManager;
        
        public static void InitLog(Action<string> logAction)
        {
            Logger.Init(logAction);
        }

        public static void LoadMods(string path)
        {
            modManager = new ModManager(path);
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
