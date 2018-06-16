using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject4_L11
{
    internal class LoginPage: Page  // вспомогательный класс для работы с страницей логина
    {
        public LoginPage(IWebDriver driver) : base(driver)   // конструктор класса
        {
            PageFactory.InitElements(driver, this);
        }

        public void Open()      // открытие станицы логина
        {
            Console.Write(" LoginPage.Open has entered;");   // отладка
            driver.Url = "http://localhost/litecart/admin/login.php"; // открытие админской консоли веб-магазина и логин в него:
            Console.Write(" LoginPage.Open  has completed;");   // отладка

        }

        public void Login(string ln, string lp)      // процедура логина
        {
            Console.Write(" LoginPage.Login has entered;");   // отладка
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            Console.Write(" LoginPage.Login  has completed;");   // отладка
        }

        public void Logout()      // процедура логаута
        {
            Console.Write(" LoginPage.Logout has entered;");   // отладка

            driver.FindElement(By.ClassName("fa")).Click(); //  Logout:
            
            Console.Write(" LoginPage.Logout has completed;");   // отладка
        }


    }
}
