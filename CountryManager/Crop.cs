using System;
using System.ComponentModel;

namespace Tais
{
    public class Crop : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static ((int m, int d) begin, (int m, int d) end) grown_date_range = ((2, 1), (9, 1));
        public double grownSpeed => 0.5;
        public double? growPercent { get; set; }

        public Action<double> WhenHavest;

        internal void DayInc((int y, int m, int d) date)
        {
            if (growPercent != null)
            {
                growPercent += grownSpeed;
            }

            if (date.m == grown_date_range.begin.m && date.d == grown_date_range.begin.d)
            {
                growPercent = 0;
            }
            if (date.m == grown_date_range.end.m && date.d == grown_date_range.end.d)
            {
                WhenHavest?.Invoke(growPercent.Value);

                growPercent = null;
            }
        }
    }
}