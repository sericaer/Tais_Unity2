using System.ComponentModel;

namespace Tais
{
    public interface IPop : INotifyPropertyChanged
    {
        IPopDef def { get; }

        double num { get; set; }

        double farm { get; set; }

        //double per_farm => num / farm;

        double consume { get; }
    }
}