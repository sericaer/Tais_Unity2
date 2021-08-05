using System;
using System.ComponentModel;

namespace Tais
{
    public class Date : IDate
    {
#pragma warning disable 0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067

        private int _total { get; set; }

        public int total => _total;

        public int year { get { return _total / 360 + 1; } set { _total = (value - 1) * 360 + (month - 1) * 30 + day - 1; } }


        public int month { get { return (_total % 360) / 30 + 1; } set { _total = (year - 1) * 360 + (value - 1) * 30 + day - 1; } }


        public int day { get { return _total % 30 + 1; } set { _total = (year - 1) * 360 + (month - 1) * 30 + value - 1; } }

        public (int y, int m, int d) value => (year, month, day);


        public Date() 
        {
            year = 1;
            month = 1;
            day = 1;

        }

        public void Inc()
        {
            _total++;
        }
    }
}
