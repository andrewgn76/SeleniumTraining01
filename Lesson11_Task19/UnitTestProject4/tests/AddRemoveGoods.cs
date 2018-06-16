using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitTestProject4_L11
{
    [TestFixture]
    public class GoodsInBasket : TestBase
    {
        [Test]
        public void AddRemoveGoods()
        {
            //app.Login("admin", "admin");        // логин в приложение

            for (int j = 1; j <= 3; j++) { app.AddOneGoodToBasket(j); } // вызвать три раза (по условию сценария)
   
            for (int j = 1; j <= 3; j++)
            {
                if (app.IsBasketEmpty()) { break; } else { app.RemoveOneGoodFromBasket(); } // проверка нужна, т.к. по одному нажатию кнопки может быть удалено 2 товара
            }    

           bool IsEmpty =  app.IsBasketEmpty();                // true если корзика уже пустая и false если нет
           Console.Write(" IsEmpty=" + IsEmpty.ToString() + ";");   // отладка

            //app.Logout();
        }
    }
}
