using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject4_L11
{
    internal class GoodMainPage : Page  // класc для работы с главной страницей(откуда выбирается товар)
    {
        public GoodMainPage(IWebDriver driver) : base(driver)   // конструктор класса
        {
            PageFactory.InitElements(driver, this);
        }

        public void Open()       // открытие страницы товара
        {
            Console.Write(" GoodMainPage.Open has entered;");   // отладка
            driver.Url = "http://localhost/litecart/en/";
            Console.Write(" GoodMainPage.Open has completed;");   // отладка
        }

        public void ChooseAGood()       // выбираем первый попавшийся товар
        {
            Console.Write(" GoodMainPage.ChooseAGood has entered;");   // отладка
            // 2а) открыть первый товар из списка
            string locFirstGood = "#box-most-popular ul li:nth-child(1) > a.link";       //локатор первого элемента
            IWebElement eCurr = driver.FindElement(By.CssSelector(locFirstGood));
            eCurr.Click();
            Console.Write(" GoodMainPage.ChooseAGood has completed;");   // отладка

        }
    }
}
