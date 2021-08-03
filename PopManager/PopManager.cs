using DynamicData;
using DynamicData.Kernel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tais
{
    public class PopManager : IObservableCache<IPop, IPopDef>
    {
        private SourceCache<IPop, IPopDef> all;


        public PopManager(IDictionary<string, int> pops, IEnumerable<IPopDef> popDefs)
        {
            all = new SourceCache<IPop, IPopDef>(x=>x.def);

            all.AddOrUpdate(popDefs.Select(def => Activator.CreateInstance(GetPopType(def.type), pops[def.type], def) as IPop));
        }

        private Type GetPopType(string type)
        {
            switch (type)
            {
                case "haoqiang":
                    return typeof(PopHaoq);
                case "minhu":
                    return typeof(PopMinh);
                case "yinhu":
                    return typeof(PopYinh);
                case "zeikou":
                    return typeof(PopZeik);
                default:
                    throw new NotImplementedException();
            }
        }

        public int Count => ((IObservableCache<IPop, IPopDef>)all).Count;

        public IEnumerable<IPop> Items => ((IObservableCache<IPop, IPopDef>)all).Items;

        public IEnumerable<IPopDef> Keys => ((IObservableCache<IPop, IPopDef>)all).Keys;

        public IEnumerable<KeyValuePair<IPopDef, IPop>> KeyValues => ((IObservableCache<IPop, IPopDef>)all).KeyValues;

        public IObservable<int> CountChanged => ((IConnectableCache<IPop, IPopDef>)all).CountChanged;

        public IObservable<IChangeSet<IPop, IPopDef>> Connect(Func<IPop, bool> predicate = null)
        {
            return ((IConnectableCache<IPop, IPopDef>)all).Connect(predicate);
        }

        public void Dispose()
        {
            ((IDisposable)all).Dispose();
        }

        public Optional<IPop> Lookup(IPopDef key)
        {
            return ((IObservableCache<IPop, IPopDef>)all).Lookup(key);
        }

        public IObservable<IChangeSet<IPop, IPopDef>> Preview(Func<IPop, bool> predicate = null)
        {
            return ((IConnectableCache<IPop, IPopDef>)all).Preview(predicate);
        }

        public IObservable<Change<IPop, IPopDef>> Watch(IPopDef key)
        {
            return ((IConnectableCache<IPop, IPopDef>)all).Watch(key);
        }
    }
}
