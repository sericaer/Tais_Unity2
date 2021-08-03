using System.ComponentModel;

namespace Tais
{
    internal class PopMinh : IPop
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public double num { get; set; }

        public double farm { get; set; }

        public double consume { get; set; }

        public IPopDef def { get; set; }

        public PopMinh(int num)
        {
            this.num = num;
        }

    }
}