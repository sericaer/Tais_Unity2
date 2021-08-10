using DynamicData;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tais
{
    public class Product : IProduct
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public double count { get; set; }

        public ISourceList<IProductRegister> registerList { get; set; }

        public Product()
        {
            registerList = new SourceList<IProductRegister>();

            registerList.Connect().OnItemAdded(x =>
            {
                count += x.count;
            }).Subscribe();
        }

        public void Add(IEnumerable<IProductRegister> registers)
        {
            registerList.Edit(inner =>
            {
                inner.AddRange(registers);
            });
        }
    }
}
