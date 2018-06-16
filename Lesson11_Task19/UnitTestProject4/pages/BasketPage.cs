using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;       // нужно для работы c ExpectedConditions.StalenessOf

namespace UnitTestProject4_L11
{
    internal class BasketPage : Page   // класс для работы со страницей корзины(откуда происходит удаление),
    {
        public BasketPage(IWebDriver driver) : base(driver)   // конструктор класса
        {
            PageFactory.InitElements(driver, this);
        }
        public void Open()
        {
            //string locCheckOutLink = "#cart a.link[href='http://localhost/litecart/en/checkout']";
            //IWebElement we = driver.FindElement(By.CssSelector(locCheckOutLink));
            //we.Click();
            Console.Write(" BasketPage.Open has entered;");   // отладка
            driver.Url = "http://localhost/litecart/en/checkout";
            Console.Write(" BasketPage.Open has completed;");   // отладка
        }
        public void RemoveGood()
        {
            Console.Write(" BasketPage.RemoveGood has entered;");   // отладка

            string locRemoveButton = "#box-checkout-cart  ul > li:nth-child(1)  button[type=submit][name=remove_cart_item]"; // локатор кнопки Remove
            string locRowItem = "#order_confirmation-wrapper > table > tbody > tr:nth-child(2) > td:nth-child(1)"; // локатор 1-го элемент 1-й строки таблицы
   
            // 6) удалить все товары из корзины один за другим, после каждого удаления подождать, пока внизу обновится таблица

            // Важно - кнопка Remove при однократном нажатии может удалить  ДВА одинаковых товара, если они были в корзине. Тогда цикл свалится на j=3 c exception
            // Чтобы этого не происходило, проверяем, что кнопка Remove присуствует  - проверка в блока try|catch
            IWebElement weRowItem = driver.FindElement(By.CssSelector(locRowItem));
            try
            {
                IWebElement we = driver.FindElement(By.CssSelector(locRemoveButton));   // находим кнопку Remove
                we.Click(); // нажимаем ее
                            // сама кнопка исчезнет, на ее месте появится другая с точно таким же локатором. Нужно подождать, пока кнопка исчезнет, прежде чем повторять дейтвие
                            //wait.Until(ExpectedConditions.StalenessOf(we));  // ждем пока кнопка Remove исчезнет
                wait.Until(ExpectedConditions.StalenessOf(weRowItem)); // если первый элемент 1й колонки исчез, значит таблица обновилась
                                                                       // если под "обновлением таблицы" понимать что-то другое. то можно реализовать более сложную логику
            }
            catch (NoSuchElementException e) { };

            Console.Write(" BasketPage.RemoveGood has completed;");   // отладка

        }

        public bool IsBasketEmpty()     //проверка, пустая корзинка или нет если уже появилась надпись "There are no items in your cart."
        {
            string locNoItems = "#checkout-cart-wrapper p:nth-child(1) em";  // локатор элемента с надписью "There are no items in your cart."
            IWebElement we;
            try
            {
                    we = driver.FindElement(By.CssSelector(locNoItems));   // локатор элемента с надписью "There are no items in your cart."
            }
            catch (NoSuchElementException e) { return false; };    // если исключение вылетело, то считаем, что в корзине что-то есть

            // Проверяем, что появилась надпись  "There are no items in your cart." Если она появилась - тест пройден. Если нет - выбрасываем исключение

            we = driver.FindElement(By.CssSelector(locNoItems));
            string NoItemsText = we.GetAttribute("innerText");
            if ("There are no items in your cart." == NoItemsText) { return true; } else { return false; }
        }
    }
}
