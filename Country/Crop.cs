using System;
using System.ComponentModel;

namespace Tais
{
    public class Crop : INotifyPropertyChanged
    {
#pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;

        public double grownSpeed => 0.5;
        public double? growPercent { get; set; }

        public Action<double> WhenHavest;

        internal void DayInc((int y, int m, int d) date)
        {
            if (growPercent != null)
            {
                growPercent += grownSpeed;
            }

            if (date.m == GlobalVar.grown_date_range.begin.m && date.d == GlobalVar.grown_date_range.begin.d)
            {
                growPercent = 0;
            }
            if (date.m == GlobalVar.grown_date_range.end.m && date.d == GlobalVar.grown_date_range.end.d)
            {
                WhenHavest?.Invoke(growPercent.Value);

                growPercent = null;
            }
        }
    }
}