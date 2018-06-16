using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnitTestProject4_L11
{
    internal class DataProviders                    // класс - поставщик данных для тестов. Инкапсулирует генерацию данных для нового кастомера (не реализован, т.к. в Задании 19 этого не требуется)
    {
        public static IEnumerable ValidGoods
        {
            get
            {
                yield return new Good()
                {
                    ShortName = "MegaDuck",                 // здесь можно использовать уникальный номер по типу (long)(DateTime.Now - DateTime.MinValue).TotalMilliseconds
                    Description = "Excellent MegaDuck",
                    PriceUSD = "29",
                    PriceEUR = "22",
                    ImagePath = @"LocalPathToDownLoad",
                    Discount = "5"
                };
             
            }
        }
    }
}
