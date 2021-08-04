
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx.Triggers;
using UnityEngine;

static class Externtion
{
    public static void EndWith(this IDisposable disposable, MonoBehaviour mono)
    {
        mono.gameObject.OnDestroyAsObservable().Subscribe(x =>
        {
            disposable.Dispose();
        });
    }
}
