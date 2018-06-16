using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;           // для работы с select

namespace UnitTestProject4_L11
{
    class GoodPage : Page  // класс для работы со страницей товара(откуда происходит добавление товара в корзину), 
    {
        public GoodPage(IWebDriver driver) : base(driver)   // конструктор класса
        {
            PageFactory.InitElements(driver, this);
        }

        public void Open() { }      // реализуем, если потребуется отдельное открытие страницы

        public void AddToBasket(int j)       // добавление нового товара
        {
            Console.Write(" GoodPage.AddToBasket has entered;");   // отладка

            string locCartCount = "#cart span.quantity"; //локатор счетчика товаров в корзине. Запоминаем значение 
            IWebElement eCurr = driver.FindElement(By.CssSelector(locCartCount));
            string sCartCountPrev = eCurr.GetAttribute("innerText"); // запоминаем предыдущее значение. В тип int не переводим, т.к. отслеживаем только факт изменения
            Console.Write(" sCartCountPrev=" + sCartCountPrev + ";"); //  отладка

            // в корзину иногда попадает желтая Утка "Sale". Для нее требуется ввести в выпадающем списке значение, иначе невозможно ее добавить в корзину по клику
            string locSaleSelect = "#box-product  select[name='options[Size]']";
            try
            {
                IWebElement weSel = driver.FindElement(By.CssSelector(locSaleSelect));  // ищем элемент. Если не находим, вылетает исключение NoSuchElementException e
                SelectElement selSizeList = new SelectElement(weSel);     // Объект Select для работы со списком
                selSizeList.SelectByIndex(2);   // выбирает 2й элемент в списке
  
            }
            catch (NoSuchElementException e) { };   // если нет элемента, все хорошо, ничего заполнять не надо


            string locBtnAddToCart = "#box-product button[type=submit][name=add_cart_product]"; // локатор кнопки Add to Cart
            eCurr = driver.FindElement(By.CssSelector(locBtnAddToCart));
            eCurr.Click();
            Console.Write(" AddToCart clicked;"); //  отладка


            // 3) подождать, пока счётчик товаров в корзине обновится
            eCurr = driver.FindElement(By.CssSelector(locCartCount));
            string valCurr = eCurr.GetAttribute("innerText");
            Console.Write(" innerText=" + valCurr.ToString() + ";");  //  отладка

            bool wr = AuxFunctions.WaitForAttrValue(driver, locCartCount, "innerText", j.ToString(), 15); // процедура ждет до появления значения переданного атрибута или срабатывания таймауа
            Console.Write(" Waited to price refresh; wr=" + wr.ToString() + ";"); //  отладка

            eCurr = driver.FindElement(By.CssSelector(locCartCount));
            valCurr = eCurr.GetAttribute("innerText");
            Console.Write(" innerText=" + valCurr.ToString() + ";"); //  отладка


            //  AuxFunctions.pauseMY(3); // принудительная пауза на указанное количество секунд

            Console.Write(" GoodPage.AddToBasket has completed;");   // отладка


        }
    }
}
