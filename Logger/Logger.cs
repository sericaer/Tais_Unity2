using System;

namespace Tais
{
    public static class Logger
    {
        private static Action<string> log;

        public static void Init(Action<string> logAction)
        {
            log = logAction;
        }

        public static void INFO(string str)
        {
            log?.Invoke(str);
        }
    }
}
