using System.ComponentModel;

namespace Tais
{
    internal class PopZeik : IPop
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public double num { get; set; }

        public double farm { get; set; }

        public double consume { get; set; }

        public IPopDef def { get; set; }

        public PopZeik(int num)
        {
            this.num = num;
        }

    }
}