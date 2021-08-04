using System;
using System.Collections.Generic;
using System.Text;

namespace Tais
{
    public interface ICountryDef
    {
        string path { get; }
        string id { get; }
        string name { get; }

        IDictionary<string, IPopInit> pops { get; }
    }


    public interface IPopInit
    {
        int num { get;}

        int farm { get;}
    }
}
