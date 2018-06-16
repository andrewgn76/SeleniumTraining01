using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject4_L11
{
    public class Application
    {
        private IWebDriver driver;

        private GoodMainPage goodMainPage;      
        private GoodPage goodPage;
        private BasketPage basketPage;
        private LoginPage loginPage;

        public Application()    // конструктор класса
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);  // установка времени неявного ожидания 5 сек

            goodMainPage = new GoodMainPage(driver);
            goodPage = new GoodPage(driver);
            basketPage = new BasketPage(driver);
            loginPage = new LoginPage(driver);

        }

        public void AddOneGoodToBasket(int j)        // добавляет первый попавшийся товар в корзину. j - порядковый номер добавления товара
        {
            goodMainPage.Open();            // открываем страницу товара 
            goodMainPage.ChooseAGood();     // выбираем первый попавшийся товар
            goodPage.AddToBasket(j);         // добавляем товар в корзину

        }

        public void RemoveOneGoodFromBasket()   // удаляет один товар из корзины
        {
            basketPage.Open();
            basketPage.RemoveGood();
        }

        public bool IsBasketEmpty()         // проверка, пустая ли корзинка товаров
        {
            return basketPage.IsBasketEmpty();
        }

        public void Login(string lname, string lpassword)       // процедура логина в приложение
        {
            loginPage.Open();
            loginPage.Login(lname, lpassword);
        }

        public void Logout()        // процедура логаута из приложения
        {
            loginPage.Logout();
        }

        public void Quit()
        {
            driver.Quit();
        }
        

    }
}
