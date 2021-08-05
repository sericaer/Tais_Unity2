using System;

namespace Tais
{
    public class Facade
    {
        public static RunData runData;
        public static ModManager modManager;

        public static IDate date => runData.date;

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
