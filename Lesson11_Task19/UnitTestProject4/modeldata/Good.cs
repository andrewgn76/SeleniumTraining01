using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject4_L11
{
    public class Good                       // заготовка для заполнения описания новыз товаров. Экземпляры создаются и используются в DataProviders
    {
        public string ShortName { get; internal set; }
        public string Description { get; internal set; }
        public string PriceUSD { get; internal set; }
        public string PriceEUR { get; internal set; }
        public string ImagePath { get; internal set; }
        public string Discount { get; internal set; }
        
    }
}
