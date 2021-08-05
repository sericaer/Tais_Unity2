using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tais
{
    public interface IDate : INotifyPropertyChanged
    {
        int total { get; }
        (int y, int m, int d) value { get; }

        void Inc();
    }

}
