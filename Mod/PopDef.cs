using Newtonsoft.Json;
using System;
using System.IO;

namespace Tais
{
    internal class PopDef : IPopDef
    {
        public string type { get; set; }

        internal static PopDef Load(string path)
        {
            Logger.INFO("analyze file: " + path);

            var def = new PopDef();

            def.type = Path.GetFileNameWithoutExtension(path);

            return def;
        }

        public PopDef()
        {

        }

    }
}