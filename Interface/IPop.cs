using System;
using System.ComponentModel;

namespace Tais
{
    public interface IPop : INotifyPropertyChanged
    {
        IPopDef def { get; }

        double num { get; set; }

        double good { get; set; }

        double per_good { get; }

        double consume { get; }

        IFarmWork farmWork { get; }

        ICollectTax collectTax { get; }

        void DayInc((int y, int m, int d) date);
    }

    public interface IFarmWork : INotifyPropertyChanged
    {
        double farm { get; set; }

        double per_farm { get; }

        void Havest(double grownPercent);
    }

    public interface ICollectTax
    {
        double DoCollect(int level);
    }

    public enum CONSUME_LEVEL
    {
        [ConsumeRage(int.MinValue, 10)]
        CONSUME_LEVEL1,

        [ConsumeRage(10, 30)]
        CONSUME_LEVEL2,

        [ConsumeRage(30, 50)]
        CONSUME_LEVEL3,


        [ConsumeRage(50, 70)]
        CONSUME_LEVEL4,


        [ConsumeRage(70, 90)]
        CONSUME_LEVEL5,


        [ConsumeRage(90, 120)]
        CONSUME_LEVEL6,


        [ConsumeRage(120, int.MaxValue)]
        CONSUME_LEVEL7
    }

    public class ConsumeRage : Attribute
    {
        int min;
        int max;

        public ConsumeRage(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
    }
}