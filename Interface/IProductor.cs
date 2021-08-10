using DynamicData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tais
{
    public interface IProduct : INotifyPropertyChanged
    {
        double count { get; set; }

        ISourceList<IProductRegister> registerList { get; set; }
    }

    public interface IProductRegister 
    {
        double count { get; set; }
        (int y, int m, int d) date { get; set; }
        IProductor productor { get; set; }
    }

    public interface IProductor : INotifyPropertyChanged
    {
    }

    public interface ITaxCollector : IProductor
    {
        double expectTax { get; }
        IProductRegister DoCollect();
    }

    public interface ITaxPopCollector : ITaxCollector
    {

    }
}
