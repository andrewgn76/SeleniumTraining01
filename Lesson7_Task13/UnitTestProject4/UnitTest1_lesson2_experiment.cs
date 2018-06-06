using System;
using System.Globalization;
using System.IO; //для работы с файлами
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;                  // не было в тестовом примере
using OpenQA.Selenium.Support.UI;       // не было в тестовом примере
using OpenQA.Selenium.Chrome;           // не было в тестовом примере
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;          
using OpenQA.Selenium.Edge;
using NUnit;                            // не было в тестовом примере
using NUnit.Framework;                  // нужно для понимания аттрибутов [TextFixture]
using NUnit.Framework.Internal;         // не было в тестовом примере
using OpenQA.Selenium.Remote;           // понадобилось в L3 W5
using System.Collections.Generic;       // поннадобилось для использования списка List
using OpenQA.Selenium.Interactions;     // нужно для действий
using OpenQA.Selenium.Support.UI;       // нужно для работы с выпадающими списками

namespace UnitTestProject4_lesson2
{    
    [TestFixture]
    public class UnitTest1_lesson2
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Start()
        {
            //Console.Write("Point 1.1. has reached; ");   // отладка
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //Console.Write("Point 1.2. has reached; ");    // отладка
        }

        [Test]
        public void FirstTest()    //почему-то при запуске ничего не происходит (браузер не запускается - если не установлен NUnit3TestAdapter). Метод FirstTestRunAll() прекрасно работает
        {
            // Console.Write("Point 2.1. has reached; ");   // отладка
            driver.Url = "http://www.ya.ru/";
            driver.FindElement(By.Id("text")).SendKeys("webdriver");
            driver.FindElement(By.ClassName("button")).Click();
            wait.Until(ExpectedConditions.UrlContains("https://yandex.ru/search/?text=webdrive"));
            driver.Quit();

            //driver.Url = "http://www.google.com/";
            //driver.FindElement(By.Name("q")).SendKeys("webdriver");
            //driver.FindElement(By.Name("btnG")).Click();
            //wait.Until(ExpectedConditions.TitleIs("webdriver - поиск в Google"));

            // Console.Write("Point 2.2. has reached; ");   // отладка:
        }

        [TearDown]
        public void Stop()
        {
            // Console.Write("Point 3.1. has reached; ");   // отладка
            driver.Quit();
            driver = null;
            // Console.Write("Point 3.2. has reached; ");   // отладка
        }

    }
    

    [TestClass]
    public class UnitTest1_lesson2_RunAll
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [TestMethod]
        public void FirstTestRunAll()
        {
            // Console.Write("Point 5.1. has reached; "); //отладка
            driver = new ChromeDriver();
            driver.Url = "http://www.ya.ru/";
            driver.Quit();
            driver = null;
            //Console.Write("Point 5.1. has reached; "); //отладка
        }
    }

    [TestClass]
    public class UnitTest1_lesson2_RunAll_experiment
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [TestMethod]
        public void FirstTestRunAll_experiment()
        {
            //Console.Write("RunAll: Point 4.1. has reached; "); // отладка
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);  // установка 10 сек ожидания по умолчанию

            // пробный тест - открытие Яндекса и закрытие после отрисовки страницы поиска
            driver.Url = "http://www.ya.ru/";
            driver.FindElement(By.Id("text")).SendKeys("webdriver");
            driver.FindElement(By.ClassName("button")).Click();
            wait.Until(ExpectedConditions.UrlContains("https://yandex.ru/search/?text=webdrive"));
            driver.Quit();
            driver = null;
            //Console.Write("RunAll: Point 4.2. has reached; "); // отладка
        }
    }

    [TestClass]
    public class UnitTest1_lesson2_Task3_LoginScenario
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [TestMethod]
        public void Test_LoginLogout()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);  // установка 10 сек ожидания по умолчанию

            // пробный тест - открытие админской консоли веб-багазина и логин в него:
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            //  Logout:
            driver.FindElement(By.ClassName("fa")).Click();

            driver.Quit();
            driver = null;
        }
    }
}

namespace UnitTestProject4_lesson3
{
    [TestClass]
    public class UnitTest1_lesson3_experments
    {
        private IWebDriver driver;
        private IWebDriver driverCR;
        private IWebDriver driverFF;
        private IWebDriver driverEG;
        private WebDriverWait wait;

        [TestMethod]
        public void L3_experiments()
        {   // установка опций для запуска Chrome
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);  // это ОК, работает
            //driver = new FirefoxDriver();   // это ОК, работает в 64 bit. Если 32bit geckodriver -  не запускается System.InvalidOperationException: Expected browser binary location, but unable to find binary in default location, no 'moz:firefoxOptions.binary' capability provided, and no binary flag set on the command line (SessionNotCreated).
            //driver = new EdgeDriver();       // это ОК, работает
            //driver = new InternetExplorerDriver();  // это ОК, работает, но ТОРМОЗИТ

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);  // установка 10 сек ожидания по умолчанию
                                                                                 // печать настроек - для ознакомления
                                                                                 // Console.Write("ПАРАМЕТРЫ БРАУЗЕРА: ");
                                                                                 // Console.Write(driver.ToString); - не понял, откуда их вытащить. Нужен пример на C#
                                                                                 /// 



            // пробный тест - открытие админской консоли веб-багазина и логин в него:
 
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Name("username")).SendKeys("admin");

            IWebElement TextBoxLGN = driver.FindElement(By.Name("username"));

            Console.Write("Точка останова: ");   // Отладка

            driver.FindElement(By.Name("password")).SendKeys("admin");

            Console.Write("Точка останова пройдена: ");   // Отладка

            driver.FindElement(By.Name("login")).Click();
            // Logout:
            driver.FindElement(By.ClassName("fa")).Click();
            

            driver.Quit();
            driver = null;
        }
    }

    [TestFixture]
    public class UnitTest1_lesson3_Run4browsersAndLogin         // последовательный запуск 4-х брузеров, логин, затем логаут и закрытие браузера
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Start()
        {
            //Console.Write("Point 1.1. has reached; ");   // отладка
            //driver = new ChromeDriver();                // здесь не используется, объект создается в [Test]
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));  // обязательна предыдущая строка
            //Console.Write("Point 1.2. has reached; ");    // отладка
        }

        [Test]
        public void Test4Browsers()    // основной тест
        {   
            
            //Console.Write("Point 2.1. has reached; ");   // отладка
            Console.Write("Chrome test run; ");   // отладка
            driver = new ChromeDriver();
            LoginLogout();              // вызов простого теста в методе LoginLogout()
            KillBrowser();              // выход из браузера

            Console.Write("FireFox test run; ");   // отладка
            driver = new FirefoxDriver();
            LoginLogout();
            KillBrowser();

            Console.Write("Edge test run; ");   // отладка
            driver = new EdgeDriver();
            LoginLogout();
            KillBrowser();
            
            Console.Write("IE test run; ");   // отладка
            driver = new InternetExplorerDriver();  // этот браузер тормозит. Возможно из-за 64 bit
            LoginLogout();
            KillBrowser();
            Console.Write("All test completed; ");   // отладка

            //Console.Write("Point 2.2. has reached; ");   // отладка
        }

        public void LoginLogout()    //Вспомогательный метод - логин админом в тестовый магазин, затем логаут
        {
            //Console.Write("Point 4.1. has reached; ");   // отладка
            // открытие админской консоли веб-магазина и логин в него:
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            //  Logout:
            driver.FindElement(By.ClassName("fa")).Click();
            //Console.Write("Point 4.2. has reached; ");   // отладка
        }
        public void KillBrowser()    // выход из текущего браузера
        {
            driver.Quit();            
            driver = null;            
        }

        [TearDown]
        public void Stop()
        {
            //Console.Write("Point 3.1. has reached; ");   // отладка
            //driver.Quit();            //  отключено для экспериментов
            //driver = null;            //  отключено для экспериментов
            //Console.Write("Point 3.2. has reached; ");   // отладка
        }

    }

    [TestFixture]
    public class UnitTest1_lesson3_Task5         // учебное задание 5, запуск FireFox по "старой" схеме, без гекодрайвера
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Start()
        {
            //Console.Write("Point 1.1. has reached; ");   // отладка
            DesiredCapabilities caps = new DesiredCapabilities();
            // caps.SetCapability(FirefoxDriver.MARIONETTE, false);  // - не работает в Selenium 3 (?)
            //driver = new FirefoxDriver(caps);
            // driver = new FirefoxDriver(); 

            //driver = new FirefoxDriver(new FirefoxBinary("C:\\Program Files\\Mozilla Firefox\\firefox.exe"), new FirefoxProfile()); // пример запуска из конкретного места

            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));  // обязательна предыдущая строка
            //Console.Write("Point 1.2. has reached; ");    // отладка
        }

        [Test]
        public void StartFFByOldManner()    // основной тест
        {

            //Console.Write("Point 2.1. has reached; ");   // отладка
              
            LoginLogout();      // запуск тестового сценария
            //KillBrowser();
            //Console.Write("Point 2.2. has reached; ");   // отладка
        }

        public void LoginLogout()    //Вспомогательный метод - логин админом в тестовый магазин, затем логаут
        {
            //Console.Write("Point 4.1. has reached; ");   // отладка
            // открытие админской консоли веб-магазина и логин в него:
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            //  Logout:
            driver.FindElement(By.ClassName("fa")).Click();
            //Console.Write("Point 4.2. has reached; ");   // отладка
        }
        public void KillBrowser()    // выход из текущего браузера
        {
            driver.Quit();
            driver = null;
        }

        [TearDown]
        public void Stop()
        {
            //Console.Write("Point 3.1. has reached; ");   // отладка
            driver.Quit();            //  отключено для экспериментов
            driver = null;            //  отключено для экспериментов
            //Console.Write("Point 3.2. has reached; ");   // отладка
        }

    }
}

namespace UnitTestProject4_lesson4
{
    [TestFixture]
    public class UnitTest1_lesson4_Task7         // учебное задание 7, сценарий проходящий по всем разделам админки
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        [SetUp]
        public void Start()
        {
            Console.Write("Point 1.1. has reached; ");   // отладка
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));  // обязательна предыдущая строка
            Console.Write("Point 1.2. has reached; ");    // отладка
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);  // установка времени ожидания 5 сек
        }

        [Test]
        public void JumpByAllSections()    // основной тест
        {
            Console.Write("Point 2.1. has reached; ");   // отладка
            LoginShop();            // вход в магазин
            //ExecuteRoutineT7_simple();      // основные шаги тестового задания, hardcode
            ExecuteRoutineT7_with_loop();     // то же самое, только проверка сделана рационально в цикле
            LogoutShop();            // выход из магазина
            Console.Write("Point 2.2. has reached; ");   // отладка
        }

        public void ExecuteRoutineT7_simple()    // основной тест - ПРОСТО ХАРДКОД БЕЗ ЦИКЛОВ И ЛОВЛИ ИСКЛЮЧЕНИЙ (просто говнокод). Отработка CSS локаторов
        {   // Сделайте сценарий, который выполняет следующие действия в учебном приложении litecart.
            // 1) входит в панель администратора http://localhost/litecart/admin
            // 2) прокликивает последовательно все пункты меню слева, включая вложенные пункты
            // 3) для каждой страницы проверяет наличие заголовка(то есть элемента с тегом h1)
            Console.Write("Point 6.1. has reached; ");   // отладка
                                                         // находим все пункты меню слева:
                                                         // $$("ul#box-apps-menu li")      // так находится список из 17 элементов слева
                                                         // $$("[id='app-'] [class=selected]") - один из 17 который активный


            IList<IWebElement> MainMenuList;  //OK
            IWebElement SubMenuItem;
            string MenuLocator, SubmenuLocator;
            //Console.Write(MainMenuList.ToString()); //OK  отладка

            MenuLocator = "div [id='box-apps-menu'] [id='app-']";
            string MenuText;

            // ------ 1й пункт меню / 2 подпункта
            MainMenuList = driver.FindElements(By.CssSelector(MenuLocator)); // вызов нужно повторять каждый раз, т.к. после клика меняются id и получается StaleElementReferenceException  
                                                                             // $$("div [id='box-apps-menu'] [id='app-'] li:first-child")
            MenuText = MainMenuList[0].Text.ToString();
            MainMenuList[0].Click();        // Клик делает активным элемент меню 1.
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-template] [href ^='http://localhost/litecart/admin/?app=appearance&doc=template']"; //Меню 1.1:  (исключения не ловим)
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-logotype] [href ^='http://localhost/litecart/admin/?app=appearance&doc=logotype']";  //Меню 1.2:
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };


            // ------ 2й пункт меню / 8 подпунктов
            MainMenuList = driver.FindElements(By.CssSelector(MenuLocator));
            MenuText = MainMenuList[1].Text.ToString();
            MainMenuList[1].Click();
            SubmenuLocator = "li [id=doc-catalog] [href ^='http://localhost/litecart/admin/?app=catalog&doc=catalog']"; // Меню 2.1.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-product_groups] [href ^='http://localhost/litecart/admin/?app=catalog&doc=product_groups']"; //Меню 2.2.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-option_groups] [href ^='http://localhost/litecart/admin/?app=catalog&doc=option_groups']"; //Меню 2.3.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-manufacturers] [href ^='http://localhost/litecart/admin/?app=catalog&doc=manufacturers']"; //Меню 2.4.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-suppliers] [href ^='http://localhost/litecart/admin/?app=catalog&doc=suppliers']"; //Меню 2.5.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-delivery_statuses] [href ^='http://localhost/litecart/admin/?app=catalog&doc=delivery_statuses']"; //Меню 2.6.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-sold_out_statuses] [href ^='http://localhost/litecart/admin/?app=catalog&doc=sold_out_statuses']"; //Меню 2.7.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-quantity_units] [href ^='http://localhost/litecart/admin/?app=catalog&doc=quantity_units']"; //Меню 2.8.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-csv] [href ^='http://localhost/litecart/admin/?app=catalog&doc=csv']"; //Меню 2.9.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            // ------ 3й пункт меню / 0 подпунктов
            MainMenuList = driver.FindElements(By.CssSelector(MenuLocator));
            MenuText = MainMenuList[2].Text.ToString();
            MainMenuList[2].Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            // ------ 4й пункт меню / 0 подпунктов
            MainMenuList = driver.FindElements(By.CssSelector(MenuLocator));
            MenuText = MainMenuList[3].Text.ToString();
            MainMenuList[3].Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            // ------ 5й пункт меню / 3 подпункта
            MainMenuList = driver.FindElements(By.CssSelector(MenuLocator));
            MenuText = MainMenuList[4].Text.ToString();
            MainMenuList[4].Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-customers] [href ^='http://localhost/litecart/admin/?app=customers&doc=customers']"; // Меню 5.1.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-csv] [href ^='http://localhost/litecart/admin/?app=customers&doc=csv']"; //Меню 5.2.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-newsletter] [href ^='http://localhost/litecart/admin/?app=customers&doc=newsletter']"; //Меню 5.3.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            // ------ 6й пункт меню / 0 подпунктов
            MainMenuList = driver.FindElements(By.CssSelector(MenuLocator));
            MenuText = MainMenuList[5].Text.ToString();
            MainMenuList[5].Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            // ------ 7й пункт меню / 2 подпункта
            MainMenuList = driver.FindElements(By.CssSelector(MenuLocator));
            MenuText = MainMenuList[6].Text.ToString();
            MainMenuList[6].Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-languages] [href ^='http://localhost/litecart/admin/?app=languages&doc=languages']"; // Меню 7.1.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-storage_encoding] [href ^='http://localhost/litecart/admin/?app=languages&doc=storage_encoding']"; //Меню 7.2.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            // ------ 8й пункт меню / 7 подпунктов
            MainMenuList = driver.FindElements(By.CssSelector(MenuLocator));
            MenuText = MainMenuList[7].Text.ToString();
            MainMenuList[7].Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-jobs] [href ^='http://localhost/litecart/admin/?app=modules&doc=jobs']"; // Меню 8.1.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-customer] [href ^='http://localhost/litecart/admin/?app=modules&doc=customer']"; //Меню 8.2.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-shipping] [href ^='http://localhost/litecart/admin/?app=modules&doc=shipping']"; //Меню 8.3.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-payment] [href ^='http://localhost/litecart/admin/?app=modules&doc=payment']"; //Меню 8.4.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-order_total] [href ^='http://localhost/litecart/admin/?app=modules&doc=order_total']"; //Меню 8.5.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-order_success] [href ^='http://localhost/litecart/admin/?app=modules&doc=order_success']"; //Меню 8.6.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-order_action] [href ^='http://localhost/litecart/admin/?app=modules&doc=order_action']"; //Меню 8.7.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            // ------ 9й пункт меню / 2 подпункта
            MainMenuList = driver.FindElements(By.CssSelector(MenuLocator));
            MenuText = MainMenuList[8].Text.ToString();
            MainMenuList[8].Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-orders] [href ^='http://localhost/litecart/admin/?app=orders&doc=orders']"; // Меню 9.1.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-order_statuses] [href ^='http://localhost/litecart/admin/?app=orders&doc=order_statuses']"; //Меню 9.2.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            // ------ 10й пункт меню / 0 подпунктов
            MainMenuList = driver.FindElements(By.CssSelector(MenuLocator));
            MenuText = MainMenuList[9].Text.ToString();
            MainMenuList[9].Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            // ------ 11й пункт меню / 3 подпункта
            MainMenuList = driver.FindElements(By.CssSelector(MenuLocator));
            MenuText = MainMenuList[10].Text.ToString();
            MainMenuList[10].Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-monthly_sales] [href ^='http://localhost/litecart/admin/?app=reports&doc=monthly_sales']"; // Меню 11.1.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-most_sold_products] [href ^='http://localhost/litecart/admin/?app=reports&doc=most_sold_products']"; //Меню 11.2.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-most_shopping_customers] [href ^='http://localhost/litecart/admin/?app=reports&doc=most_shopping_customers']"; //Меню 11.3.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            // ------ 12й пункт меню / 8 подпунктов
            MainMenuList = driver.FindElements(By.CssSelector(MenuLocator));
            MenuText = MainMenuList[11].Text.ToString();
            MainMenuList[11].Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-store_info] [href ^='http://localhost/litecart/admin/?app=settings&doc=store_info']"; // Меню 12.1.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-defaults] [href ^='http://localhost/litecart/admin/?app=settings&doc=defaults']"; //Меню 12.2.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-general] [href ^='http://localhost/litecart/admin/?app=settings&doc=general']"; //Меню 12.3.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-listings] [href ^='http://localhost/litecart/admin/?app=settings&doc=listings']"; //Меню 12.4.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-images] [href ^='http://localhost/litecart/admin/?app=settings&doc=images']"; //Меню 12.5.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-checkout] [href ^='http://localhost/litecart/admin/?app=settings&doc=checkout']"; //Меню 12.6.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-advanced] [href ^='http://localhost/litecart/admin/?app=settings&doc=advanced']"; //Меню 12.7.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-security] [href ^='http://localhost/litecart/admin/?app=settings&doc=security']"; //Меню 12.8.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            // ------ 13й пункт меню / 0 подпунктов
            MainMenuList = driver.FindElements(By.CssSelector(MenuLocator));
            MenuText = MainMenuList[12].Text.ToString();
            MainMenuList[12].Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            // ------ 14й пункт меню / 2 подпункта
            MainMenuList = driver.FindElements(By.CssSelector(MenuLocator));
            MenuText = MainMenuList[13].Text.ToString();
            MainMenuList[13].Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-tax_classes] [href ^='http://localhost/litecart/admin/?app=tax&doc=tax_classes']"; // Меню 14.1.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-tax_rates] [href ^='http://localhost/litecart/admin/?app=tax&doc=tax_rates']"; //Меню 14.2.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            // ------ 15й пункт меню / 3 подпункта
            MainMenuList = driver.FindElements(By.CssSelector(MenuLocator));
            MenuText = MainMenuList[14].Text.ToString();
            MainMenuList[14].Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-search] [href ^='http://localhost/litecart/admin/?app=translations&doc=search']"; // Меню 15.1.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-scan] [href ^='http://localhost/litecart/admin/?app=translations&doc=scan']"; //Меню 15.2.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-csv] [href ^='http://localhost/litecart/admin/?app=translations&doc=csv']"; //Меню 15.3.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            // ------ 16й пункт меню / 0 подпунктов
            MainMenuList = driver.FindElements(By.CssSelector(MenuLocator));
            MenuText = MainMenuList[15].Text.ToString();
            MainMenuList[15].Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            // ------ 17й пункт меню / 1 подпункт
            MainMenuList = driver.FindElements(By.CssSelector(MenuLocator));
            MenuText = MainMenuList[16].Text.ToString();
            MainMenuList[16].Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };

            SubmenuLocator = "li [id=doc-vqmods] [href ^='http://localhost/litecart/admin/?app=vqmods&doc=vqmods']"; // Меню 17.1.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; "); } else { Console.Write(">" + MenuText + " H1-FAIL; "); };



            Console.Write("Point 6.2. has reached; ");   // отладка
        }

        public void ExecuteRoutineT7_with_loop()    // основной тест,проверки сделаны в цикле 
        {   // Сделайте сценарий, который выполняет следующие действия в учебном приложении litecart.
            // 1) входит в панель администратора http://localhost/litecart/admin
            // 2) прокликивает последовательно все пункты меню слева, включая вложенные пункты
            // 3) для каждой страницы проверяет наличие заголовка(то есть элемента с тегом h1)
            Console.Write("Point 6.1. has reached; ");   // отладка
                                                         // находим все пункты меню слева:
                                                         // $$("ul#box-apps-menu li")      // так находится список из 17 элементов слева
                                                         // $$("[id='app-'] [class=selected]") - один из 17 который активный


            //IWebElement OneMainMenuItem = driver.FindElement(By.CssSelector("ul#box-apps-menu li"));   // OK  отладка
            //Console.Write(OneMainMenuItem.ToString()); //OK отладка

            const string MenuListLocator = "[id='app-']";       // CSS запрос, выдающий список меню  (17 шт. в примере)
            const string SubMenuListLocator = "li [id^=doc-]";  // CSS запрос, выдающий список подменю

            IList<IWebElement> MainMenuList; // = driver.FindElements(By.CssSelector(MenuListLocator)); //OK
            IList<IWebElement> SubMenuList;  // = driver.FindElements(By.CssSelector(SubMenuListLocator)); //OK

            //Console.Write(MainMenuList.ToString()); //OK  отладка

            MainMenuList = driver.FindElements(By.CssSelector(MenuListLocator));
            int liNumber = MainMenuList.Count;      // вычисляем число элементов в списке (17 шт). Проверку на их наличие не делаем, т.к. учебное упражнение


            for (int i = 0; i < liNumber; i++)        // в цикле делаем активным каждый элемент
            {
                MainMenuList = driver.FindElements(By.CssSelector(MenuListLocator)); // вызов нужно повторять каждый раз, т.к. после клика меняются id и получается StaleElementReferenceException  
                // отладка:                                                                                                                                                           // отладка: 
                Console.Write(" MainMenu(" + i.ToString() + ") -> " + MainMenuList[i].Text.ToString() + "; ");
                MainMenuList[i].Click();        // Клик делает активным элемент меню. После этого теряется ссылка в MainMenuList и  получается StaleElementReferenceException  

                SubMenuList = driver.FindElements(By.CssSelector(SubMenuListLocator)); // находим список элементов подменю. От 0 до N 
                int liSubNumber = SubMenuList.Count;  // от 0 до N
                if (liSubNumber > 0)
                {
                    for (int j = 0; j < liSubNumber; j++)
                    {
                        SubMenuList = driver.FindElements(By.CssSelector(SubMenuListLocator));
                        // отладка:                                                                                                                                                           // отладка: 
                        Console.Write(" SubMenu(" + i.ToString() + "." + j.ToString() + ") -> " + SubMenuList[j].Text.ToString() + "; ");
                        SubMenuList[j].Click();
                        // вызов проверки загрузки страницы. Результаты проверки просто выводим на консоль
                        if (H1check()) { Console.Write("H1 check passed;"); }
                        else { Console.Write("H1 check failed;"); };
                    }
                }

            }

            Console.Write("Point 6.2. has reached; ");   // отладка
        }

        public Boolean H1check() //true если элемент H1 найден и false в обратном случае
        {
            string Locator = "h1";
            IList<IWebElement> H1checkerList = driver.FindElements(By.CssSelector(Locator));
            //Console.Write("H1> ");
            //Console.Write(H1checkerList.Count.ToString());
            //Console.Write("; ");
            if (H1checkerList.Count == 0) { return false; }
            else { return true; }

        }


        public void LoginShop()    //Вспомогательный метод - логин админом в тестовый магазин, затем логаут
        {
            Console.Write("Point 4.1. has reached; ");   // отладка
            // открытие админской консоли веб-магазина и логин в него:
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            Console.Write("Point 4.2. has reached; ");   // отладка
            Console.Write("Login sucessfull; ");   // отладка

        }

        public void LogoutShop()    //Вспомогательный метод - logout из магазина
        {
            Console.Write("Point 5.1. has reached; ");   // отладка
            //  Logout:
            driver.FindElement(By.ClassName("fa")).Click();
            Console.Write("Point 5.2. has reached; ");   // отладка
            Console.Write("Logout sucessfull; ");   // отладка
        }

        [TearDown]
        public void Stop()
        {
            Console.Write("Point 3.1. has reached; ");   // отладка
            driver.Quit();
            driver = null;
            Console.Write("Point 3.2. has reached; ");   // отладка
            Console.Write("Logout sucessfull; ");   // отладка
        }

    }

    [TestFixture]
    public class UnitTest1_lesson4_Task8         // учебное задание 8, сценарий проверки стикеров у товаров
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        [SetUp]
        public void Start()
        {
            Console.Write("Point 1.1. has reached; ");   // отладка
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));  // обязательна предыдущая строка
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);  // установка времени ожидания 5 сек
            Console.Write("Point 1.2. has reached; ");    // отладка
        }

        [Test]
        public void CheckGoodsStickers()    // основной тест
        {
            Console.Write("Point 2.1. has reached; ");   // отладка
            LoginShop();            // вход в магазин  (просто открытие страницы магазина)
            ExecuteRoutineT8();     // основные шаги тестового задания
            //LogoutShop();         // выход из магазина - в задании 8 не требуется
            Console.Write("Point 2.2. has reached; ");   // отладка
        }

        public void ExecuteRoutineT8()    // основной тест,проверки сделаны в цикле 
        {   // Сделайте сценарий, проверяющий наличие стикеров у всех товаров в учебном приложении litecart на главной странице. 
            // Стикеры -- это полоски в левом верхнем углу изображения товара, на которых написано New или Sale или что-нибудь другое. 
            // Сценарий должен проверять, что у каждого товара имеется ровно один стикер. 

            Console.Write("Point 6.1. has reached; ");

            //IWebElement OneMainMenuItem = driver.FindElement(By.CssSelector("ul#box-apps-menu li"));   // OK  отладка
            //Console.Write(OneMainMenuItem.ToString()); //OK отладка

            const string GoodsListLocator = "li a.link";       // CSS запрос, выдающий список товаров (11 шт. в тестовом примере)
            const string StickListLocator = "[class^='sticker']";  // CSS запрос, выдающий список стикеров

            IList<IWebElement> MainMenuList; // = driver.FindElements(By.CssSelector(MenuListLocator)); //OK
            IList<IWebElement> StickList;  // = driver.FindElements(By.CssSelector(SubMenuListLocator)); //OK
            IWebElement OneDuck, OneStick;    // для итераций в цикле

            //Console.Write(MainMenuList.ToString()); //OK  отладка

            MainMenuList = driver.FindElements(By.CssSelector(GoodsListLocator));
            int liNumber = MainMenuList.Count;      // вычисляем число элементов в списке (11 шт). Проверку на их наличие не делаем, т.к. учебное упражнение

            for (int i = 0; i < liNumber; i++)        // в цикле для каждого элемента ищем стикер
            {
                // отладка:      
                OneDuck = MainMenuList[i];  // для наглядности
                StickList = OneDuck.FindElements(By.CssSelector(StickListLocator));
                int CurrSticks = StickList.Count;

                Console.Write(" Duck(" + (i + 1).ToString() + ") -> " + OneDuck.Text.ToString() + ";");
                Console.Write(" Stick(s) count = " + CurrSticks.ToString() + "; ");

                // блок проверок - пишем те, которые нам нужны
                if (CurrSticks == 0)
                {
                    Console.Write("Stick check: ERROR: stick is missed;");
                };
                if (CurrSticks == 1)
                {
                    Console.Write("Stick check: PASSED;");
                };
                if (CurrSticks > 1)
                {
                    Console.Write("Stick check: ERROR: several sticks when just one has expected;");
                };
                if (CurrSticks > 0)
                {
                    for (int j = 0; j < CurrSticks; j++)
                    {
                        Console.Write(" Stick #" + (j + 1).ToString() + " label = " + StickList[j].Text.ToString() + ";");
                    };
                };

            }

            Console.Write("Point 6.2. has reached; ");   // отладка
        }




        public void LoginShop()    //Вспомогательный метод - логин админом в тестовый магазин, затем логаут
        {
            Console.Write("Point 4.1. has reached; ");   // отладка
            // открытие  веб-магазина и логин в него:
            driver.Url = "http://localhost/litecart/en/";
            //driver.FindElement(By.Name("username")).SendKeys("admin");
            // driver.FindElement(By.Name("password")).SendKeys("admin");
            //driver.FindElement(By.Name("login")).Click();
            Console.Write("Point 4.2. has reached; ");   // отладка
            Console.Write("Login sucessfull; ");   // отладка

        }

        public void LogoutShop()    //Вспомогательный метод - logout из магазина
        {
            Console.Write("Point 5.1. has reached; ");   // отладка
                                                         //  Logout:
                                                         // driver.FindElement(By.ClassName("fa")).Click();
            Console.Write("Point 5.2. has reached; ");   // отладка
            Console.Write("Logout sucessfull; ");   // отладка
        }

        [TearDown]
        public void Stop()
        {
            Console.Write("Point 3.1. has reached; ");   // отладка
            driver.Quit();
            driver = null;
            Console.Write("Point 3.2. has reached; ");   // отладка
            Console.Write("Logout sucessfull; ");   // отладка
        }

    }


}

namespace UnitTestProject4_lesson5
{
    [TestFixture]
    public class UnitTest1_lesson5_Task09         // учебное задание 9, Проверить сортировку стран и геозон в админке 
     

    {
        private IWebDriver driver;
        private WebDriverWait wait;


        [SetUp]
        public void Start()
        {
            Console.Write("Point 1.1. has reached; ");   // отладка
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));  // обязательна предыдущая строка
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);  // установка времени ожидания 5 сек
            Console.Write("Point 1.2. has reached; ");    // отладка
        }

        [Test]
         public void CheckCountriesAndGezones()    // основной тест
        {
            Console.Write("Point 2.1. has reached; ");   // отладка
            LoginShop();            // вход в магазин  (просто открытие страницы магазина)
            ExecuteRoutineT9_1a();     // основные шаги тестового задания п.1.а
            ExecuteRoutineT9_1b();     // основные шаги тестового задания п.1.б
            ExecuteRoutineT9_2();       // основные шаги тестового задания п.2.
            LogoutShop();         // выход из магазина - в задании 8 не требуется
            Console.Write("Point 2.2. has reached; ");   // отладка
        }

        public void ExecuteRoutineT9_1a()    // основной тест 1a 
    {   // делайте сценарии, которые проверяют сортировку стран и геозон (штатов) в учебном приложении litecart.
        // 1) на странице http://localhost/litecart/admin/?app=countries&doc=countries
        // а) проверить, что страны расположены в алфавитном порядке
        // б) для тех стран, у которых количество зон отлично от нуля-- открыть страницу этой страны и там проверить, что зоны расположены в алфавитном порядке
        // 
        // 2) на странице http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones
        // зайти в каждую из стран и проверить, что зоны расположены в алфавитном порядке

            Console.Write("Point 6.1. has reached; ");
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries"; // переход на страницу со списком стран

            const string CountryListLocator = "table tr[class=row]";       // CSS запрос, выдающий список стран (238 шт. в тестовом примере)
            
            IList<IWebElement> CountryList; 
            IWebElement OneCountry;    // для итераций в цикле

            //Console.Write(MainMenuList.ToString()); //OK  отладка

            CountryList = driver.FindElements(By.CssSelector(CountryListLocator));

            int liNumber = CountryList.Count;      // вычисляем число элементов в списке (238 шт). Проверку на их наличие не делаем, т.к. учебное упражнение
         
            string CountryName,  CountryNameLocator;                      // для интераций в цикле
            string CountryNamePrev = ""; // инициализация значением, заведомо первым
            bool HasAlphabeticalOrder = true;      // проверка упорядочивания по алфавиту

            for (int i = 0; i < liNumber; i++)        // проверить, что страны расположены в алфавитном порядке
            {
                if (i > 0)   // 1-ю строку с хидерами исключаем
                { 
                  // конструируем динамический локатор-селектор вида: $$("table tr[class=row]:nth-child(3) td:nth-child(5)") 
                    CountryNameLocator = "table tr[class=row]:nth-child(" + (i+1).ToString() + ") td:nth-child(5)";  // вытаскиваем назание страны
                    OneCountry = driver.FindElement(By.CssSelector(CountryNameLocator));
                    CountryName = OneCountry.GetAttribute("innerText");


                    if (!IsAlpphabetical(CountryNamePrev, CountryName)) { HasAlphabeticalOrder = false; }; // можно было использовать CompareTo()
                    
                    // отладка:
                    Console.Write(" Country(" + (i + 1).ToString() + ") = " + CountryName + ";");
                    Console.Write(" HasOrder(" + (i + 1).ToString() + ") -> " + HasAlphabeticalOrder.ToString() + ";");
                    CountryNamePrev = CountryName;
                }
            }
            if (HasAlphabeticalOrder)       // какая-то проверка на упорядоченность названий стран и соотвествующие действия
            {
                Console.Write("ALL COUNTRIES ARE ORDERED CORRECTLY");
            }
            else
            {
                Console.Write("PROBLEM WITH COUNTRIES ORDER DETECTED");
                throw new AssertFailedException();      // выбрасываем исключение и ломаем тест - он будет красный при выполнении.
            }   



            Console.Write("Point 6.2. has reached; ");   // отладка
        }

        public void ExecuteRoutineT9_1b()    // основной тест 1b 
        {   // делайте сценарии, которые проверяют сортировку стран и геозон (штатов) в учебном приложении litecart.
            // 1) на странице http://localhost/litecart/admin/?app=countries&doc=countries
            // а) проверить, что страны расположены в алфавитном порядке
            // б) для тех стран, у которых количество зон отлично от нуля-- открыть страницу этой страны и там проверить, что зоны расположены в алфавитном порядке
            // 
            // 2) на странице http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones
            // зайти в каждую из стран и проверить, что зоны расположены в алфавитном порядке

            Console.Write("Point 7.1. has reached; ");
            const string CountriesURL = "http://localhost/litecart/admin/?app=countries&doc=countries";
            driver.Url = CountriesURL; // переход на страницу со списком стран

            const string CountryListLocator = "table tr[class=row]";       // CSS запрос, выдающий список стран (238 шт. в тестовом примере)

            IList<IWebElement> CountryList;
            IWebElement OneCountry;    // для итераций в цикле

            CountryList = driver.FindElements(By.CssSelector(CountryListLocator));

            int liNumber = CountryList.Count;      // вычисляем число элементов в списке (238 шт). Проверку на их наличие не делаем, т.к. учебное упражнение
            string CountryName, CountryZone, CountryPage;
            string CountryNameLocator, CountryZoneLocator, CountryPageLocator;                    // для интераций в цикле
            string CountryNamePrev = ""; // инициализация значением, заведомо первым
            bool HasAlphabeticalOrder = true;      // проверка упорядочивания по алфавиту

            for (int i = 0; i < liNumber; i++)        // проверить, что таймзона отлична от нуля
            {
                if (i > 0)   // 1-ю строку с хидерами исключаем
                {
                    // конструируем динамический локатор-селектор вида: $$("table tr[class=row]:nth-child(3) td:nth-child(5)") 
                    CountryNameLocator = "table tr[class=row]:nth-child(" + (i + 1).ToString() + ") td:nth-child(5)";  // вытаскиваем назание страны
                    OneCountry = driver.FindElement(By.CssSelector(CountryNameLocator));
                    CountryName = OneCountry.GetAttribute("innerText");

                    CountryZoneLocator = "table tr[class=row]:nth-child(" + (i + 1).ToString() + ") td:nth-child(6)"; // количество зон
                    OneCountry = driver.FindElement(By.CssSelector(CountryZoneLocator));
                    CountryZone = OneCountry.GetAttribute("innerText");

                    CountryPageLocator = "table tr[class=row]:nth-child(" + (i + 1).ToString() + ") td:nth-child(5) a";  // ссылка внутри 5й ячейки
                    OneCountry = driver.FindElement(By.CssSelector(CountryPageLocator));
                    CountryPage = OneCountry.GetAttribute("href");
                    
                    if (CountryZone != "0")
                    {
                        // для тех стран, у которых количество зон отлично от нуля-- открыть страницу этой страны и там проверить, что зоны расположены в алфавитном порядке
                        // отладка: 
                        Console.Write(" PROBLEM ZONE:  Country(" + (i + 1).ToString() + ") = " + CountryName + "; ZONE NUMBER:" + CountryZone + "; ");
                        Console.Write(" HREF: " + CountryPage + "; ");
                        driver.Url = CountryPage; // переход на страницу со списком стран
                        Console.Write(" JUMP FORWARD. ");

                        // локатор для списка зон: $$("table[class=dataTable] tr")
                        // локатор для поиска названия таймзоны:      $$("table[class=dataTable] tr:nth-child(3) td:nth-child(3)")

                        string ZoneListLocator = "table[class=dataTable] tr";
                        string ZoneNameLocator, ZoneName;
                        string ZoneNamePrev = ""; // инициализация значением, заведомо первым
                        bool HasAlphabeticalZone = true;      // проверка упорядочивания по алфавиту зон
                        
                        IList<IWebElement> ZoneList;
                        IWebElement OneZone;    // для итераций в цикле

                        ZoneList = driver.FindElements(By.CssSelector(ZoneListLocator));
                        int ziNumber = ZoneList.Count;

                        for (int j = 0; j < ziNumber; j++)        // проверить, что таймзоны идут по спсику
                        {
                            if ((j > 0) & (j < (ziNumber-1)) )  // 1-ю строку с хидерами исключаем + последнюю с футером тоже исключаем
                            {
                                // конструируем динамический локатор-селектор вида: $$("table[class=dataTable] tr:nth-child(3) td:nth-child(3)")  // название зоны 
                                ZoneNameLocator = "table[class=dataTable] tr:nth-child(" + (j + 1).ToString() + ") td:nth-child(3)";  // вытаскиваем назание страны
                                OneZone = driver.FindElement(By.CssSelector(ZoneNameLocator));
                                ZoneName = OneZone.GetAttribute("innerText");
                                // отладка
                                //Console.Write(" Zone("+j.ToString()+") = "+ ZoneName + ";");

                                if ( !(IsAlpphabetical(ZoneNamePrev, ZoneName))) {HasAlphabeticalZone = false; }; // можно было использовать CompareTo()
      
                            }
                         
                        }

                        if (HasAlphabeticalZone)       // какая-то проверка на упорядоченность названий зон
                        {
                            Console.Write(" ALL ZONES FOR [" + CountryName + "] ARE ORDERED CORRECTLY;");
                        }
                        else
                        {
                            Console.Write(" PROBLEM WITH ZONES FOR [" + CountryName + "]; ");
                            //throw new AssertFailedException();      // выбрасываем исключение и ломаем тест - он будет красный при выполнении.
                        }

                        driver.Url = CountriesURL; // возврат на исходную страницу со списком стран
                        Console.Write(" JUMP BACK. ");

                    }; 

                    // отладка:
                    //Console.Write(" Country(" + (i + 1).ToString() + ") = " + CountryName + ";");
                    //Console.Write(" HasOrder(" + (i + 1).ToString() + ") -> " + HasAlphabeticalOrder.ToString() + ";");
                }
            }
            if (HasAlphabeticalOrder)       // какая-то проверка на упорядоченность названий стран и соотвествующие действия
            {
                Console.Write("ALL COUNTRIES ARE ORDERED CORRECTLY");
            }
            else
            {
                Console.Write("PROBLEM WITH COUNTRIES ORDER DETECTED");
                throw new AssertFailedException();      // выбрасываем исключение и ломаем тест - он будет красный при выполнении.
            }



            Console.Write("Point 7.2. has reached; ");   // отладка
        }

        public void ExecuteRoutineT9_2()    // основной тест 2
        {   
            // 2) на странице http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones
            // зайти в каждую из стран и проверить, что зоны расположены в алфавитном порядке

            Console.Write("Point 8.1. has reached; ");
            const string CountriesURL = "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones";
            driver.Url = CountriesURL; // переход на страницу со списком стран  (2 шт. в тестовом примере )

            const string CountryListLocator = "table[class=dataTable] tr";       // CSS запрос, выдающий список стран (2 шт. в тестовом примере)

            IList<IWebElement> CountryList;
            IWebElement OneCountry;    // для итераций в цикле

            CountryList = driver.FindElements(By.CssSelector(CountryListLocator));

            int liNumber = CountryList.Count;      // вычисляем число элементов в списке (2 шт). Проверку на их наличие не делаем, т.к. учебное упражнение
            string CountryName, CountryZone, CountryPage;
            string CountryNameLocator, CountryZoneLocator, CountryPageLocator;                    // для интераций в цикле
            string CountryNamePrev = ""; // инициализация значением, заведомо первым
 
            for (int i = 0; i < liNumber; i++)        // прохождение по строкам из списка
            {
                if ((i > 0)&(i< liNumber-1))   // 1-ю строку с хидерами исключаем + последнюю с футером тоже
                {
                    // конструируем динамический локатор-селектор вида: $$("table[class=dataTable] tr:nth-child(2) td:nth-child(3) a") 
                    CountryNameLocator = "table[class=dataTable] tr:nth-child(" + (i + 1).ToString() + ") td:nth-child(3)";  // вытаскиваем назание страны
                    OneCountry = driver.FindElement(By.CssSelector(CountryNameLocator));
                    CountryName = OneCountry.GetAttribute("innerText");

                    //CountryZoneLocator = "table tr[class=row]:nth-child(" + (i + 1).ToString() + ") td:nth-child(6)"; // количество зон
                    //OneCountry = driver.FindElement(By.CssSelector(CountryZoneLocator));
                    //CountryZone = OneCountry.GetAttribute("innerText");

                    CountryPageLocator = "table[class=dataTable] tr:nth-child(" + (i + 1).ToString() + ") td:nth-child(3) a";  // ссылка внутри 3й ячейки
                    OneCountry = driver.FindElement(By.CssSelector(CountryPageLocator));
                    CountryPage = OneCountry.GetAttribute("href");

                    driver.Url = CountryPage; // переход на страницу со списком стран
                    Console.Write(" JUMP FORWARD. ");


                    // локатор для списка зон: $$("table[class=dataTable][id=table-zones] tr")
                    // локатор для поиска названия таймзоны:      $$("table[class=dataTable][id=table-zones] tr:nth-child(1) td:nth-child(3)") 

                    string ZoneListLocator = "table[class=dataTable][id=table-zones] tr";
                    string ZoneNameLocator, ZoneName;
                    string ZoneNamePrev = ""; // инициализация значением, заведомо первым
                    bool HasAlphabeticalZone = true;      // проверка упорядочивания по алфавиту зон

                    IList<IWebElement> ZoneList;
                    IWebElement OneZone;    // для итераций в цикле

                    ZoneList = driver.FindElements(By.CssSelector(ZoneListLocator));
                    int jNumber = ZoneList.Count;

                    for (int j = 0; j < jNumber; j++)        // проверить, что таймзоны идут по спсику
                    {
                            if ((j > 0) & (j < (jNumber - 1)))  // 1-ю строку с хидерами исключаем + последнюю с футером тоже исключаем
                            {
                            // конструируем динамический локатор-селектор вида: $$("table[class=dataTable][id=table-zones] tr:nth-child(2) td:nth-child(3) select")  // название зоны 
                            ZoneNameLocator = "table[class=dataTable][id=table-zones] tr:nth-child(" + (j + 1).ToString() + ") td:nth-child(3) select";  // вытаскиваем назание зоны
                            OneZone = driver.FindElement(By.CssSelector(ZoneNameLocator));
                            ZoneName = OneZone.GetAttribute("value");
                            //ZoneName = OneZone.GetAttribute("selectedIndex");
                            //ZoneName = OneZone.GetAttribute("innerText");
                            // отладка
                            //Console.Write(" Zone("+j.ToString()+") = "+ ZoneName + ";");

                            if (!(IsAlpphabetical(ZoneNamePrev, ZoneName))) { HasAlphabeticalZone = false; }; 

                            }

                        }

                        if (HasAlphabeticalZone)       // какая-то проверка на упорядоченность названий зон
                        {
                            Console.Write(" ALL ZONES FOR [" + CountryName + "] ARE ORDERED CORRECTLY;");
                        }
                        else
                        {
                            Console.Write(" PROBLEM WITH ZONES FOR [" + CountryName + "]; ");
                            throw new AssertFailedException();      // выбрасываем исключение и ломаем тест - он будет красный при выполнении.
                        }


                    driver.Url = CountriesURL; // возврат на исходную страницу со списком стран
                    Console.Write(" JUMP BACK. ");

                    // отладка:
                    //Console.Write(" Country(" + (i + 1).ToString() + ") = " + CountryName + ";");
                    //Console.Write(" HasOrder(" + (i + 1).ToString() + ") -> " + HasAlphabeticalOrder.ToString() + ";");
                }
            }
            
            Console.Write("Point 8.2. has reached; ");   // отладка
        }

        public bool IsAlpphabetical(string S1, string S2)           // проверка, 1-я строка должна быть раньше 2й (true) или нет (false)
        {
            if (S1.CompareTo(S2) < 0) { return true; } else {return false; }; 
            
        }
        
        public void LoginShop()    //Вспомогательный метод - логин админом в тестовый магазин, затем логаут
        {
            Console.Write("Point 4.1. has reached; ");   // отладка
            // открытие  веб-магазина и логин в него:
            // driver.Url = "http://localhost/litecart/en/";  // обычный магазин
            driver.Url = "http://localhost/litecart/admin/login.php"; // открытие админской консоли веб-магазина и логин в него:
            driver.FindElement(By.Name("username")).SendKeys("admin");  
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            Console.Write("Point 4.2. has reached; ");   // отладка
            Console.Write("Login sucessfull; ");   // отладка

        }

        public void LogoutShop()    //Вспомогательный метод - logout из магазина
        {
            Console.Write("Point 5.1. has reached; ");   // отладка
                                                         //  Logout:
                                                         // driver.FindElement(By.ClassName("fa")).Click();
            Console.Write("Point 5.2. has reached; ");   // отладка
            Console.Write("Logout sucessfull; ");   // отладка
        }

        [TearDown]
        public void Stop()
        {
            Console.Write("Point 3.1. has reached; ");   // отладка
            driver.Quit();
            driver = null;
            Console.Write("Point 3.2. has reached; ");   // отладка
            Console.Write("Logout sucessfull; ");   // отладка
        }

    }

    [TestFixture]
    public class UnitTest1_lesson5_Task10        // учебное задание 10, Проверить товар в магазине 

    {
        private IWebDriver driver;
        private WebDriverWait wait;


        [SetUp]
        public void Start()
        {
            Console.Write(" Point 1.1. has reached; ");   // отладка
            //driver = new ChromeDriver();  // временно отключено
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));  // обязательна предыдущая строка
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);  // установка времени ожидания 5 сек
            Console.Write(" Point 1.2. has reached; ");    // отладка
        }

        public void StartChrome()
        {
            Console.Write(" Point 1.1. has reached; ");   // отладка
            Console.Write(" Chrome driver; ");   // отладка
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));  // обязательна предыдущая строка
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);  // установка времени ожидания 5 сек
            Console.Write(" Point 1.2. has reached; ");    // отладка
        }

        public void StartFireFox()
        {
            Console.Write(" Point 1.1. has reached; ");   // отладка
            Console.Write(" FireFoх driver; ");   // отладка
            driver = new FirefoxDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));  // обязательна предыдущая строка
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);  // установка времени ожидания 5 сек
            Console.Write("Point 1.2. has reached; ");    // отладка
        }

        public void StartIE()
        {
            Console.Write(" Point 1.1. has reached; ");   // отладка
            Console.Write(" IE driver; ");   // отладка
            driver = new InternetExplorerDriver(); 
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));  // обязательна предыдущая строка
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);  // установка времени ожидания 5 сек
            Console.Write(" Point 1.2. has reached; ");    // отладка
        }

        public void StartEdge()
        {
            Console.Write(" Point 1.1. has reached; ");   // отладка
            Console.Write(" Edge driver; ");   // отладка
            driver = new EdgeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));  // обязательна предыдущая строка
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);  // установка времени ожидания 5 сек
            Console.Write(" Point 1.2. has reached; ");    // отладка
        }

        [Test]
        public void Run5Checks_Chrome()    // основной тест
        {
            Console.Write(" Point 2.1. has reached; ");   // отладка
            //LoginShop();            // вход в магазин  (просто открытие страницы магазина)
            StartChrome();
            ExecuteRoutineT10();     // основные шаги тестового задания 
            //LogoutShop();         // выход из магазина - в задании 10 не требуется
            Console.Write(" Point 2.2. has reached; ");   // отладка
        }

        [Test]
        public void Run5Checks_FireFox()    // основной тест
        {
            Console.Write(" Point 2.1. has reached; ");   // отладка
            //LoginShop();            // вход в магазин  (просто открытие страницы магазина)
            StartFireFox();
            ExecuteRoutineT10();     // основные шаги тестового задания 
            //LogoutShop();         // выход из магазина - в задании 10 не требуется
            Console.Write(" Point 2.2. has reached; ");   // отладка
        }

        [Test]
        public void Run5Checks_IE()    // основной тест
        {
            Console.Write(" Point 2.1. has reached; ");   // отладка
            //LoginShop();            // вход в магазин  (просто открытие страницы магазина)
            StartIE();
            ExecuteRoutineT10();     // основные шаги тестового задания 
            //LogoutShop();         // выход из магазина - в задании 10 не требуется
            Console.Write(" Point 2.2. has reached; ");   // отладка
        }

        [Test]
        public void Run5Checks_Edge()    // основной тест
        {
            //LoginShop();            // вход в магазин  (просто открытие страницы магазина)
            Console.Write(" Point 2.1. has reached; ");   // отладка
            StartEdge();
            ExecuteRoutineT10();     // основные шаги тестового задания 
            //LogoutShop();         // выход из магазина - в задании 10 не требуется
            Console.Write(" Point 2.2. has reached; ");   // отладка
        }

        public void ExecuteRoutineT10()    // основной тест Задания 10 
        {   //  Сделайте сценарий, который проверяет, что при клике на товар открывается правильная страница товара в учебном приложении litecart.
            // Более точно, нужно открыть главную страницу, выбрать первый товар в блоке Campaigns и проверить следующее:
            // a) на главной странице и на странице товара совпадает текст названия товара
            // b) на главной странице и на странице товара совпадают цены(обычная и акционная)
            // c) обычная цена зачёркнутая и серая(можно считать, что "серый" цвет это такой, у которого в RGBa представлении одинаковые значения для каналов R, G и B)
            // d) акционная жирная и красная(можно считать, что "красный" цвет это такой, у которого в RGBa представлении каналы G и B имеют нулевые значения)
            // (цвета надо проверить на каждой странице независимо, при этом цвета на разных страницах могут не совпадать)
            // e) акционная цена крупнее, чем обычная(это тоже надо проверить на каждой странице независимо)
            // Необходимо убедиться, что тесты работают в разных браузерах, желательно проверить во всех трёх ключевых браузерах(Chrome, Firefox, IE).

            Console.Write("Point 6.1. has reached; ");

            bool CheckA = false;    // Проверки, перечисленные выше. В конце будет список, что пройдено, а что нет
            bool CheckB = false;
            bool CheckC = false;
            bool CheckD = false;
            bool CheckE = false;

            const string StoreURL = "http://localhost/litecart/en/"; // главная страница магазина

            // ----- CheckA
            {   // выбрать первый товар в блоке Campaigns и проверить следующее:
                // a) на главной странице и на странице товара совпадает текст названия товара
                driver.Url = StoreURL; // переход на главную страницу 

                string loc1 = "#box-campaigns div.name"; // локатор названия на главной странице 
                IWebElement DuckPrice1 = driver.FindElement(By.CssSelector(loc1)); // получаем элемент, содержащий ценник
                string Nam1 = DuckPrice1.GetAttribute("innerText");

                Console.Write(" Nam1 = " + Nam1 + "; "); //  отладка

                string DuckURLlocator = "#box-campaigns > div > ul > li > a.link"; // локатор для поиска ссылки на страницу товара
                string DuckURL = driver.FindElement(By.CssSelector(DuckURLlocator)).GetAttribute("href"); // получаем URL

                //Console.Write(" DuckURL = " + DuckURL + "; "); //  отладка

                driver.Url = DuckURL;   // переход на страницу товара

                string loc2 = "#box-product > div:nth-child(1) > h1"; // локатор названия на странице товара
                IWebElement DuckPrice2 = driver.FindElement(By.CssSelector(loc2)); // получаем элемент, содержащий ценник
                string Nam2 = DuckPrice2.GetAttribute("innerText");
                Console.Write(" Nam2 = " + Nam2 + "; "); //  отладка

                if (Nam1 == Nam2) { CheckA = true; }       // первая проверка из учебного задания
                Console.Write(" CheckA = " + CheckA.ToString() + "; "); //  отладка
            }

            // ----- CheckB
            {   // выбрать первый товар в блоке Campaigns и проверить следующее:
                // b) на главной странице и на странице товара совпадают цены(обычная и акционная)
                bool CheckB1 = false;   // признак проверки на первой странице - обычная цена
                bool CheckB2 = false;   // признак проверки на второй странице - акционная цена

                driver.Url = StoreURL; // переход на главную страницу 
                string loc3a = "#box-campaigns s.regular-price"; // локатор для обычной цены 1 стр
                string loc3b = "#box-campaigns strong.campaign-price"; // локатор для акционной цены 1 стр

                string Price1a = driver.FindElement(By.CssSelector(loc3a)).GetAttribute("innerText"); // получаем ценник с главной страницы 
                string Price1b = driver.FindElement(By.CssSelector(loc3b)).GetAttribute("innerText"); // получаем ценник с главной страницы 

                Console.Write(" Price1a = " + Price1a + "; "); //  отладка
                Console.Write(" Price1b = " + Price1b + "; "); //  отладка

                string DuckURLlocator = "#box-campaigns > div > ul > li > a.link"; // локатор для поиска ссылки на страницу товара
                string DuckURL = driver.FindElement(By.CssSelector(DuckURLlocator)).GetAttribute("href"); // получаем URL
                driver.Url = DuckURL;  // переход на страницу товара.

                string loc4a = "#box-product s.regular-price"; // локатор для обычной  цены 2 стр
                string loc4b = "#box-product strong.campaign-price"; // локатор для акционной  цены 2 стр

                string Price2a = driver.FindElement(By.CssSelector(loc4a)).GetAttribute("innerText"); // получаем ценник со страницы товара
                string Price2b = driver.FindElement(By.CssSelector(loc4b)).GetAttribute("innerText"); // получаем ценник со страницы товара

                Console.Write(" Price2a = " + Price2a + "; "); //  отладка
                Console.Write(" Price2b = " + Price2b + "; "); //  отладка

                if (Price1a == Price2a) { CheckB1 = true; }       // совпадает обычная цена
                if (Price1b == Price2b) { CheckB2 = true; }       // совпадает акционноая цена
                CheckB = CheckB1 & CheckB2;
                Console.Write(" CheckB = " + CheckB.ToString() + "; "); //  отладка

                //const string GoodLocator = "#box-campaigns strong.campaign-pricek";       // локатор для цены
            }

            // ----- CheckC
            {   // открыть главную страницу, выбрать первый товар в блоке Campaigns и проверить следующее:
                // c) обычная цена зачёркнутая и серая(можно считать, что "серый" цвет это такой, у которого в RGBa представлении одинаковые значения для каналов R, G и B)
                driver.Url = StoreURL; // переход на главную страницу 
                string loc5 = "#box-campaigns s.regular-price"; // локатор для обычной цены
                IWebElement DuckPriceElement = driver.FindElement(By.CssSelector(loc5));
                string Text5 = DuckPriceElement.GetAttribute("innerText");  // получаем ценник с главной страницы 
                string Color5 = DuckPriceElement.GetCssValue("color");      // получаем ценник с главной страницы 

                //Console.Write(" Text5 = " + Text5 + "; "); //  отладка
                Console.Write(" Color5 = " + Color5 + "; "); //  отладка

                if (IsGrey(Color5)) { CheckC = true; }; // проверка из учебного задания

                Console.Write(" CheckC = " + CheckC.ToString() + "; "); //  отладка
            }

            // ----- CheckD
            { // открыть главную страницу, выбрать первый товар в блоке Campaigns и проверить следующее:
              // d) акционная жирная и красная(можно считать, что "красный" цвет это такой, у которого в RGBa представлении каналы G и B имеют нулевые значения)
              // (цвета надо проверить на каждой странице независимо, при этом цвета на разных страницах могут не совпадать)
                bool CheckD1 = false;   // признак проверки на первой странице
                bool CheckD2 = false;   // признак проверки на второй странице
                driver.Url = StoreURL; // переход на главную страницу 

                string loc6 = "#box-campaigns strong.campaign-price"; // локатор для акционной цены на первой странице
                IWebElement DuckPriceElement = driver.FindElement(By.CssSelector(loc6));
                string Text6 = DuckPriceElement.GetAttribute("innerText");  // получаем ценник с главной страницы 
                string Color6 = DuckPriceElement.GetCssValue("color");      // получаем ценник с главной страницы 

                //Console.Write(" Text6 = " + Text6 + "; "); //  отладка
                Console.Write(" Color6 = " + Color6 + "; "); //  отладка

                if (IsRed(Color6)) { CheckD1 = true; }; // проверка из учебного задания

                string DuckURLlocator = "#box-campaigns > div > ul > li > a.link"; // локатор для поиска ссылки на страницу товара
                string DuckURL = driver.FindElement(By.CssSelector(DuckURLlocator)).GetAttribute("href"); // получаем URL
                driver.Url = DuckURL;  // переход на страницу товара.

                string loc7 = "#box-product strong.campaign-price"; // локатор для акционной цены на второй странице
                IWebElement DuckPriceElement2 = driver.FindElement(By.CssSelector(loc7));
                string Text7 = DuckPriceElement2.GetAttribute("innerText");  // получаем ценник с главной страницы 
                string Color7 = DuckPriceElement2.GetCssValue("color");      // получаем ценник с главной страницы 

                //Console.Write(" Text7 = " + Text7 + "; "); //  отладка
                Console.Write(" Color7 = " + Color7 + "; "); //  отладка

                if (IsRed(Color7)) { CheckD2 = true; }; // проверка из учебного задания

                CheckD = CheckD1 & CheckD2; // для выполнения нужно чтобы два условия выполнялись

                Console.Write(" CheckD = " + CheckC.ToString() + "; "); //  отладка
            }

            // ----- CheckE
            {// открыть главную страницу, выбрать первый товар в блоке Campaigns и проверить следующее:
             // e) акционная цена крупнее, чем обычная(это тоже надо проверить на каждой странице независимо)

                bool CheckE1 = false;   // признак проверки на первой странице
                bool CheckE2 = false;   // признак проверки на второй странице

               driver.Url = StoreURL; // переход на главную страницу 

                string loc8a = "#box-campaigns s.regular-price"; // локатор для обычной цены 1 стр
                string loc8b = "#box-campaigns strong.campaign-price"; // локатор для акционной цены 1 стр

                IWebElement DuckPriceElement1a = driver.FindElement(By.CssSelector(loc8a));
                IWebElement DuckPriceElement1b = driver.FindElement(By.CssSelector(loc8b));

                string Text8a = DuckPriceElement1a.GetAttribute("innerText");  // получаем ценник с главной страницы 
                string Text8b = DuckPriceElement1b.GetAttribute("innerText");  // получаем ценник с главной страницы 

                Console.Write(" Text8a = " + Text8a + "; "); //  отладка
                Console.Write(" Text8b = " + Text8b + "; "); //  отладка

                System.Drawing.Size Size8a = DuckPriceElement1a.Size; // ToString();  // размер обычной цены
                System.Drawing.Size Size8b = DuckPriceElement1b.Size;  // размер акционной цены 

                Console.Write(" Size8a = " + Size8a.ToString() + "; "); //  отладка
                Console.Write(" Size8b = " + Size8b.ToString() + "; "); //  отладка

                if ((Size8a.Width < Size8b.Width) & (Size8a.Height < Size8b.Height)) { CheckE1 = true; };   // проверка по условию задания


                string DuckURLlocator = "#box-campaigns > div > ul > li > a.link"; // локатор для поиска ссылки на страницу товара
                string DuckURL = driver.FindElement(By.CssSelector(DuckURLlocator)).GetAttribute("href"); // получаем URL
                driver.Url = DuckURL;  // переход на страницу товара.

                string loc9a = "#box-product s.regular-price"; // локатор для обычной  цены 2 стр
                string loc9b = "#box-product strong.campaign-price"; // локатор для акционной  цены 2 стр

                IWebElement DuckPriceElement2a = driver.FindElement(By.CssSelector(loc9a));
                IWebElement DuckPriceElement2b = driver.FindElement(By.CssSelector(loc9b));

                string Text9a = DuckPriceElement2a.GetAttribute("innerText");  // получаем ценник
                string Text9b = DuckPriceElement2b.GetAttribute("innerText");  // получаем ценник

                Console.Write(" Text9a = " + Text9a + "; "); //  отладка
                Console.Write(" Text9b = " + Text9b + "; "); //  отладка

                System.Drawing.Size Size9a = DuckPriceElement2a.Size;  // размер обычной цены
                System.Drawing.Size Size9b = DuckPriceElement2b.Size;  // размер акционной цены 

                Console.Write(" Size9a = " + Size9a.ToString() + "; "); //  отладка
                Console.Write(" Size9b = " + Size9b.ToString() + "; "); //  отладка

                if ((Size9a.Width < Size9b.Width) & (Size9a.Height < Size9b.Height)) { CheckE2 = true; };   // проверка по условию задания
                
                CheckE = CheckE1 & CheckE2; // для выполнения нужно чтобы два условия выполнялись

                Console.Write(" CheckE = " + CheckE.ToString() + "; "); //  отладка

            }

            //CheckC = false; // отладка -  принудительное присваивание проверки как не пройденной - для отладки исключений
            //Console.Write(" CheckC =  FALSE (forced);");

            if (CheckA & CheckB & CheckC & CheckD & CheckE)       //все 5 условий должны быть пройдены успешно
            {
                Console.Write(" ALL 5 CHECKS HAS PASSED CORRECTLY;");
            }
            else
            {
                Console.Write(" PROBLEM WITH  5 CHECKS DETECTED;");
                throw new AssertFailedException();      // выбрасываем исключение и ломаем тест - он будет красный при выполнении.
            }

            Console.Write("Point 6.2. has reached; ");   // отладка
        }

        public bool IsGrey(string RGBstring)        // true если серый, false если нет
        {
            string RGB = RGBstring.Trim(new char[] { 'r', 'g', 'b', 'a', '(', ')' }); //удаляем ненужные элементы из подстроки
            string[] RGBarray = RGB.Split(); // парсим строку RGBstring и выделяем отдельные элементы R,G,B:
            string R = RGBarray[0].Trim(',');    // удаляем запятые посе парсинга
            string G = RGBarray[1].Trim(',');    // удаляем запятые посе парсинга
            string B = RGBarray[2].Trim(',');    // удаляем запятые посе парсинга
            //  Console.Write("R=" + R + "; "); // отладка
            //  Console.Write("G=" + G + "; "); // отладка
            //  Console.Write("B=" + B + "; "); // отладка
            if (R == G)
            {
                   if (R == B) { return true; } else { return false; };
            }
            else { return false;};
        }

        public bool IsRed(string RGBstring)        // true если красный, false если нет
        {
            string RGB = RGBstring.Trim(new char[] { 'r', 'g', 'b', 'a', '(', ')' }); //удаляем ненужные элементы из подстроки
            string[] RGBarray = RGB.Split(); // парсим строку RGBstring и выделяем отдельные элементы R,G,B:
            string R = RGBarray[0].Trim(',');    // удаляем запятые посе парсинга
            string G = RGBarray[1].Trim(',');    // удаляем запятые посе парсинга
            string B = RGBarray[2].Trim(',');    // удаляем запятые посе парсинга

            //  Console.Write("R=" + R + "; "); // отладка
            //  Console.Write("G=" + G + "; "); // отладка
            //  Console.Write("B=" + B + "; "); // отладка

            if ((G=="0")&(B=="0")) { return true; } else { return false; };          
        }

        public void LoginShop()    //Вспомогательный метод - логин админом в тестовый магазин, затем логаут
        {
            Console.Write("Point 4.1. has reached; ");   // отладка
            // открытие  веб-магазина и логин в него:
            // driver.Url = "http://localhost/litecart/en/";  // обычный магазин
            driver.Url = "http://localhost/litecart/admin/login.php"; // открытие админской консоли веб-магазина и логин в него:
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            Console.Write("Point 4.2. has reached; ");   // отладка
            Console.Write("Login sucessfull; ");   // отладка

        }

        public void LogoutShop()    //Вспомогательный метод - logout из магазина
        {
            Console.Write("Point 5.1. has reached; ");   // отладка
                                                         //  Logout:
                                                         // driver.FindElement(By.ClassName("fa")).Click();
            Console.Write("Point 5.2. has reached; ");   // отладка
            Console.Write("Logout sucessfull; ");   // отладка
        }

        [TearDown]
        public void Stop()
        {
            Console.Write("Point 3.1. has reached; ");   // отладка
            driver.Quit();
            driver = null;
            Console.Write("Point 3.2. has reached; ");   // отладка
            Console.Write("Logout sucessfull; ");   // отладка
        }

    }
}

namespace UnitTestProject4_lesson6
{
    [TestFixture]
    public class UnitTest1_lesson6_Task11         // учебное задание 11,  регистрация нового пользователя
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Start()
        {
            Console.Write("Point 1.1. has reached; ");   // отладка
            driver = new ChromeDriver();    // Все Ок. Иногда Хром выкидывает окно, предлагающее запоминать пароли. Обход этого окна не сделан (не требуется по учебному заданию)
            // driver = new FirefoxDriver();   //  Все ОК
            // driver = new InternetExplorerDriver(); // здесь не работает, ломается на выборе страны из дропбокса. Отлаживать не стал, в 3х других браузерах все работает.
            // driver = new EdgeDriver(); // Все ОК 

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));  // обязательна предыдущая строка
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);  // установка времени ожидания 5 сек
            Console.Write("Point 1.2. has reached; ");    // отладка
        }

        [Test]
        public void RegisterNewCustomer()    // запуск теста 
        {
            Console.Write("Point 2.1. has reached; ");   // отладка
            //LoginShop();            // вход в магазин  (просто открытие страницы магазина)
            ExecuteRoutineT11();     // основные шаги тестового задания
            //LogoutShop();         // выход из магазина - в задании 8 не требуется
            Console.Write("Point 2.2. has reached; ");   // отладка
        }

        public void ExecuteRoutineT11()    // основной тест 
        {   // делайте сценарий для регистрации нового пользователя в учебном приложении litecart (не в админке, а в клиентской части магазина).
            // Сценарий должен состоять из следующих частей:
            // 1) регистрация новой учётной записи с достаточно уникальным адресом электронной почты(чтобы не конфликтовало с ранее созданными пользователями, в том числе при предыдущих запусках того же самого сценария),
            // 2) выход(logout), потому что после успешной регистрации автоматически происходит вход,
            // 3) повторный вход в только что созданную учётную запись,
            // 4) и ещё раз выход.
            // В качестве страны выбирайте United States, штат произвольный.При этом формат индекса --пять цифр.

            Console.Write("Point 6.1. has reached; ");
            const string StoreURL = "http://localhost/litecart/en/"; // URL главной страницы магазина 
            driver.Url = StoreURL; // переход на главную страницу магазина 

            string NewCustomerListLocator = "#box-account-login  tr:nth-child(5) > td > a";       // локатор для ссылки, которая ведет на форму регистрации нвого пользователя
            IWebElement NewCustomerLinkElement = driver.FindElement(By.CssSelector(NewCustomerListLocator));
            string NewCustomerPageURL = NewCustomerLinkElement.GetAttribute("href");
            Console.Write(" NewCustomerPageURL = " + NewCustomerPageURL + "; "); // отладка

            driver.Url = NewCustomerPageURL;  // ОК, стандартный переход. Вместо него попробуем отправить Click в элемент с линком на эту же страницу
            //NewCustomerLinkElement.Click(); // OK, это тоже работает (!! Кроме браузера IE). Переход на новую страницу.
            Console.Write(" PageURL=" + driver.Url.ToString() + "; "); // отладка

            // здесь мы находимся на новой странице регистрации нового пользователя. 
            // определяем локаторы элементов: 
            string locTaxID = "#create-account input[type='text'][name='tax_id']";    // локатор поля ввода TaxID
            string locCompany = "#create-account input[type='text'][name='company']";   // локатор поля ввода TaxID
            string locFirstName = "#create-account input[type='text'][name='firstname']"; // далее по аналогии
            string locLastName = "#create-account input[type='text'][name='lastname']";  // +
            string locAddress1 = "#create-account input[type='text'][name='address1']";  // +
            string locAddress2 = "#create-account input[type='text'][name='address2']";  // +
            string locPostCode = "#create-account input[type='text'][name='postcode']";  // +
            string locCity = "#create-account input[type='text'][name='city']";      // +
            string locCountry = "#create-account span.select2-selection__rendered"; // до какого-то выбора ЭТО НЕВЕРНО

            //         string locCountry = "create-account span#select2-country_code-ay-container.select2-selection__rendered"; // до какого-то выбора 
            string locZone = "#create-account select[name='zone_code']"; // +
            string locEmail = "#create-account input[type='email'][name='email']";  // +
            string locPhone = "#create-account input[type='tel'][name='phone']";    // +
            string locNewsLetterCheckbox = "#create-account input[type='checkbox'][name='newsletter']";    // +
            string locPassword = "#create-account input[type='password'][name='password']"; // +
            string locConfPassword = "#create-account input[type='password'][name='confirmed_password']"; // +
            string locSubmitButton = "#create-account button[type='submit'][name='create_account']"; //+

            // определяем занчения полей, которые должны быть заполнены при регистрации  (NC - сокращение New Customer)
            // По-уму надо сделать отдельную функцию для каждого поля, но в целях простоты сделаем максимально коротко
            Random rnd = new Random();
            string NCTaxID = rnd.Next(10000000, 99999999).ToString();  // случайное числа в указанном диапазоне
            string NCCompany = "Company#" + NCTaxID;                   // далее по аналогии
            string NCFirstName = "FirstName-" + NCTaxID;
            string NCLastName = "LastName-" + NCTaxID;
            string NCAddress1 = "Address1-" + NCTaxID;
            string NCAddress2 = "Address2-" + NCTaxID;
            string NCPostCode = rnd.Next(10000, 99999).ToString();   // индекс содержит 5 цифр
            string NCCity = "City-" + NCTaxID.Substring(6);         // последние 2 цифры TaxID
            string NCCountry = "United States";  // по условию задания
            string NCZone = "Arizona"; // выбран произвольный штат
            string NCEmail = GetUniqueEmail(); // получаем значение нового уникального e-mail; 
            string NCPhone = "8-" + NCTaxID;
            bool NCNewsLetterCheckbox = false;    // отключаем новости
            string NCPassword = "ncpassword"; // 
            string NCConfPassword = "ncpassword"; // пароли совпадают

            // проводим заполнение полей:
            IWebElement eCurrElement;   // текущий элемент (итератор, но без цикла)

            //driver.FindElement(By.CssSelector(locTaxID)).Click();
            //driver.FindElement(By.CssSelector(locTaxID)).SendKeys(NCTaxID);

            // (1) Заполнение TaxID
            eCurrElement = driver.FindElement(By.CssSelector(locTaxID));
            //eCurrElement.Click(); // получаем фокус на элемент - этого не требуется
            eCurrElement.SendKeys(NCTaxID); // передаем значение в поле ввода

            // Вместо eCurrElement.SendKeys(NCTaxID); // используем следующие 3 строки
            //Actions actions = new Actions(driver); // инициализация классе actions 
            //actions.SendKeys(eCurrElement, NCTaxID);
            //actions.Perform();
            Console.Write(" TaxID=" + eCurrElement.GetAttribute("value").ToString() + ";"); //отладка

            // (2) Заполнение Company
            eCurrElement = driver.FindElement(By.CssSelector(locCompany));
            eCurrElement.SendKeys(NCCompany); // передаем значение в поле ввода
            Console.Write(" Company=" + eCurrElement.GetAttribute("value").ToString() + ";"); //отладка

            // (3) Заполнение locFirstName
            eCurrElement = driver.FindElement(By.CssSelector(locFirstName));
            eCurrElement.SendKeys(NCFirstName); // передаем значение в поле ввода
            Console.Write(" FirstName=" + eCurrElement.GetAttribute("value").ToString() + ";"); //отладка

            // (4) Заполнение LastName
            eCurrElement = driver.FindElement(By.CssSelector(locLastName));
            eCurrElement.SendKeys(NCLastName); // передаем значение в поле ввода
            Console.Write(" LastName=" + eCurrElement.GetAttribute("value").ToString() + ";"); //отладка

            // (5) Заполнение Address1
            eCurrElement = driver.FindElement(By.CssSelector(locAddress1));
            eCurrElement.SendKeys(NCAddress1); // передаем значение в поле ввода
            Console.Write(" Address1=" + eCurrElement.GetAttribute("value").ToString() + ";"); //отладка

            // (6) Заполнение Address2
            eCurrElement = driver.FindElement(By.CssSelector(locAddress2));
            eCurrElement.SendKeys(NCAddress2); // передаем значение в поле ввода
            Console.Write(" Address2=" + eCurrElement.GetAttribute("value").ToString() + ";"); //отладка

            // (7) Заполнение PostCode
            eCurrElement = driver.FindElement(By.CssSelector(locPostCode));
            eCurrElement.SendKeys(NCPostCode); // передаем значение в поле ввода
            Console.Write(" PostCode=" + eCurrElement.GetAttribute("value").ToString() + ";"); //отладка

            // (8) Заполнение City
            eCurrElement = driver.FindElement(By.CssSelector(locCity));
            eCurrElement.SendKeys(NCCity); // передаем значение в поле ввода
            Console.Write(" City=" + eCurrElement.GetAttribute("value").ToString() + ";"); //отладка

            // (9) Заполнение Country  //  НЕ ПОЛУЧИЛОСЬ РАБОТАТЬ С ДРОПБОКОМ. НУЖНА ПОМОЩЬ!!!!

            string locArea = "#create-account span[class='select2-selection select2-selection--single']"; //локатор области где есть названия элементов
            eCurrElement = driver.FindElement(By.CssSelector(locArea));
            eCurrElement.Click();   // получение фокуса элемента (Важно - не должно быть случайных двойных кликов)

            IWebElement eCurrElement4 = driver.FindElement(By.CssSelector("input[class=select2-search__field]"));
            eCurrElement4.SendKeys(NCCountry);
            eCurrElement4.SendKeys(Keys.Enter);

            eCurrElement = driver.FindElement(By.CssSelector(locArea));  // на всякий случай ищем элемент заново
            Console.Write(" Country=" + eCurrElement.GetAttribute("innerText").ToString() + ";");

            // получаем справочник стран. Ищем по названию страны ее ID  - СЛИШКОМ СЛОЖНО И  НЕ НУЖНО. МОЖНО ПРОЩЕ ЧЕРЕЗ SendKeys. ПОлезный код, пусть будет в комментариях
            //string locCList = "li.select2-results__option"; // находится 232 элемента. Но только после клика на дропбокс
            //IList<IWebElement> le = driver.FindElements(By.CssSelector(locCList));
            //int leNum = le.Count;
            // int USindex = 0;        // индекс элемента со страной US, его надо найти
            //string USid = "";       // нужно найти ID, т.к. он динамически меняется :(
            //Console.Write(" leNum=" + leNum.ToString() + ";"); // отладка
            //Console.Write(" select#2;"); // отладка
            //
            //string iText;
            //for (int i = 0; i < leNum; i++)
            //{
            // /   iText = le[i].GetAttribute("innerText").ToString();
            //    //f (i > 220) { Console.Write(" le[" + i.ToString() + "]=" + iText + ";"); } //отладка 
            //    if (iText == NCCountry)
            //    {
            //        USindex = i;
            //        USid = le[i].GetAttribute("id").ToString();
            //        Console.Write(" COUNRTY[" + iText + "] HAS SELECTED;");  //отладка 
            //        Console.Write(" COUNRTY ID=" + USid + ";");  //отладка   select2-country_code-w9-result-ge5o-US
            //                                                     //              select2-country_code-oe-result-vrbq-U
            //    };
            //}



            // (10) Заполнение Zone  // пока не сделано, пусть заполняется значениями по умолчанию при ввооде формы
                        locArea = "#create-account select[name=zone_code]"; //локатор области где есть названия элементов
            eCurrElement = driver.FindElement(By.CssSelector(locArea));
            
            SelectElement SelZoneList = new SelectElement(eCurrElement);     // Объект Select для работы со списком
            //SelZoneList.SelectByIndex(2);   // выбирает 2й элемент в списке. Допклики не нужны
            SelZoneList.SelectByText("Colorado");   // Поскольку название произвольное, пусть будет Colorado
                        
            eCurrElement = driver.FindElement(By.CssSelector(locArea));  // на всякий случай ищем элемент заново
            Console.Write(" Zone=" + eCurrElement.GetAttribute("value").ToString() + ";");


            // (11) Заполнение Email
            eCurrElement = driver.FindElement(By.CssSelector(locEmail));
            eCurrElement.SendKeys(NCEmail); // передаем значение в поле ввода
            Console.Write(" Email=" + eCurrElement.GetAttribute("value").ToString() + ";"); //отладка

            // (12) Заполнение Phone
            eCurrElement = driver.FindElement(By.CssSelector(locPhone));
            eCurrElement.SendKeys(NCPhone); // передаем значение в поле ввода
            eCurrElement = driver.FindElement(By.CssSelector(locPhone));
            eCurrElement.Click(); // чтобы убрать фокус с элемента (9)
            Console.Write(" Phone=" + eCurrElement.GetAttribute("value").ToString() + ";"); //отладка

            // (12) Заполнение NewsLetterCheckbox
            eCurrElement = driver.FindElement(By.CssSelector(locNewsLetterCheckbox));
            if (eCurrElement.GetAttribute("checked").ToString() == "true") { eCurrElement.Click(); } // после клика пропадает ссылка на объект
            Console.Write(" LetterCheckbox unchecked;"); //отладка

            // (13) Заполнение Password
            eCurrElement = driver.FindElement(By.CssSelector(locPassword));
            eCurrElement.SendKeys(NCPassword); // передаем значение в поле ввода
            Console.Write(" Password=" + eCurrElement.GetAttribute("value").ToString() + ";"); //отладка

            // (14) Заполнение ConfPassword
            eCurrElement = driver.FindElement(By.CssSelector(locConfPassword));
            eCurrElement.SendKeys(NCConfPassword); // передаем значение в поле ввода
            Console.Write(" ConfPassword=" + eCurrElement.GetAttribute("value").ToString() + ";"); //отладка

            // (15) Нажимаем кнопку "Create Account"
            string locBtnCreateAccount = "#create-account button[name=create_account]"; // локатор кнопки
            eCurrElement = driver.FindElement(By.CssSelector(locBtnCreateAccount));
            Console.Write(" btnCA=" + eCurrElement.GetAttribute("innerText").ToString() + ";"); //отладка
            eCurrElement.Click();

            // (16) Если все успешно, то здесь должен произойти переход на другую страницу. Проверим, что он действиельно произошел.
            // Если нет, то выбросим исключение и сломаем тест. Ищем элемент Logout

            string locLogoutLink = "#box-account li:nth-child(4) a";
            IList<IWebElement> eExist = driver.FindElements(By.CssSelector(locLogoutLink));
            Console.Write(" eExist.Count=" + eExist.Count.ToString() + ";"); //отладка

            if (eExist.Count == 0)
            {
                throw new AssertFailedException();      // выбрасываем исключение и ломаем тест - он будет красный при выполнении. Например, если ZIP код не 5 символов
            }
            else
            {
                eExist[0].Click();      // мы знаем, что элемент там только один такой. Жмем на Logout
            }

            // (17) повторный вход в только что созданную учётную запись
            string locLoginFiled = "#box-account-login input[type='text']";     // локатор поля ввода логина
            string locPswFiled = "#box-account-login input[type='password']";    // локатор поля ввода пароля
            string locLoginBtn = "#box-account-login button[type='submit'][name='login']"; // локатор кнопки Login

            eCurrElement = driver.FindElement(By.CssSelector(locLoginFiled));
            eCurrElement.SendKeys(NCEmail);

            eCurrElement = driver.FindElement(By.CssSelector(locPswFiled));
            eCurrElement.SendKeys(NCPassword);

            eCurrElement = driver.FindElement(By.CssSelector(locLoginBtn));
            eCurrElement.Click();

            Console.Write(" Logged in again;");

            // (18) проверка на то, что успешно вошли и ещё раз выход.

            locLogoutLink = "#box-account li:nth-child(4) a";
            eExist = driver.FindElements(By.CssSelector(locLogoutLink));
            Console.Write(" eExist.Count=" + eExist.Count.ToString() + ";"); //отладка

            if (eExist.Count == 0)
            {
                throw new AssertFailedException();      // выбрасываем исключение и ломаем тест - он будет красный при выполнении. Например, если ZIP код не 5 символов
            }
            else
            {
                eExist[0].Click();      // мы знаем, что элемент там только один такой. Жмем на Logout
            }

            Console.Write("Logged out again; ");

            Console.Write("Point 6.2. has reached; ");   // отладка

        }
      
        public string GetUniqueEmail()     //функция возвращает уникальный адрес электронной почты
        {
            DateTime datetime = DateTime.Now;  //предполагаем, что время будет уникальным при вызоые этой функции, т.е. ее вызов реже чем раз в 1 сек
            string NameUniq = datetime.ToString();
            NameUniq = NameUniq.Replace(":", ""); // удаляем ненужные символы
            NameUniq = NameUniq.Replace("/", "");
            NameUniq = NameUniq.Replace(".", "");
            NameUniq = NameUniq.Replace(",", "");
            NameUniq = NameUniq.Replace(" ", "");
            NameUniq = "Task11_Cust_" + NameUniq + "@mail.ru";
            //Console.Write("NameUniq = " + NameUniq + ";");   // отладка
            return (NameUniq);
        }

        public void LoginShopAdmin()    //Вспомогательный метод - логин админом в тестовый магазин, затем логаут
        {
            Console.Write("Point 4.1. has reached; ");   // отладка
                                                         // открытие  веб-магазина и логин в него:
                                                         // driver.Url = "http://localhost/litecart/en/";  // обычный магазин
            driver.Url = "http://localhost/litecart/admin/login.php"; // открытие админской консоли веб-магазина и логин в него:
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            Console.Write("Point 4.2. has reached; ");   // отладка
            Console.Write("Login sucessfull; ");   // отладка

        }

        public void LogoutShopAdmin()    //Вспомогательный метод - logout из магазина админ
        {
            Console.Write("Point 5.1. has reached; ");   // отладка
                                                         //  Logout:
                                                         // driver.FindElement(By.ClassName("fa")).Click();
            Console.Write("Point 5.2. has reached; ");   // отладка
            Console.Write("Logout sucessfull; ");   // отладка
        }

        [TearDown]
        public void Stop()
        {
            Console.Write("Point 3.1. has reached; ");   // отладка
            driver.Quit();
            driver = null;
            Console.Write("Point 3.2. has reached; ");   // отладка
            Console.Write("Logout sucessfull; ");   // отладка
        }
    }

    [TestFixture]
    public class UnitTest1_lesson6_Task12         // учебное задание 12, добваление нового товара в админке
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Start()
        {
            Console.Write("Point 1.1. has reached; ");   // отладка
            driver = new ChromeDriver();    // 
            // driver = new FirefoxDriver();   //  
            // driver = new InternetExplorerDriver(); // 
            // driver = new EdgeDriver(); //

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));  // обязательна предыдущая строка
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);  // установка времени ожидания 5 сек
            Console.Write("Point 1.2. has reached; ");    // отладка
        }

        [Test]
        public void AddNewGood()    // запуск теста 
        {
            Console.Write("Point 2.1. has reached; ");   // отладка
            LoginShopAdmin();            // вход в магазин  (админом)
            ExecuteRoutineT12();     // основные шаги тестового задания
            LogoutShopAdmin();         // выход из магазина 
            Console.Write("Point 2.2. has reached; ");   // отладка
        }

        public void ExecuteRoutineT12()    // основной тест 
        {   // Сделайте сценарий для добавления нового товара (продукта) в учебном приложении litecart (в админке).
            // Для добавления товара нужно открыть меню Catalog, в правом верхнем углу нажать кнопку "Add New Product", заполнить поля с информацией о товаре и сохранить.
            // Достаточно заполнить только информацию на вкладках General, Information и Prices.Скидки(Campains) на вкладке Prices можно не добавлять.
            // Переключение между вкладками происходит не мгновенно, поэтому после переключения можно сделать небольшую паузу(о том, как делать более правильные ожидания, будет рассказано в следующих занятиях).
            // Картинку с изображением товара нужно уложить в репозиторий вместе с кодом.При этом указывать в коде полный абсолютный путь к файлу плохо, на другой машине работать не будет. Надо средствами языка программирования преобразовать относительный путь в абсолютный.
            // После сохранения товара нужно убедиться, что он появился в каталоге(в админке).Клиентскую часть магазина можно не проверять.

            Console.Write("Point 6.1. has reached; ");
            // здесь мы уже вошли в магазин администратором
            // (1) для  добавления товара нужно открыть меню Catalog, в правом верхнем углу нажать кнопку "Add New Product", заполнить поля с информацией о товаре и сохранить.

            IWebElement eCurr; // итератор текущего элемента
            
            string MenuLocator = "div [id='box-apps-menu'] [id='app-']";
            IList<IWebElement> MainMenuList = driver.FindElements(By.CssSelector(MenuLocator));
            string MenuText = MainMenuList[1].GetAttribute("innerText");
            MainMenuList[1].Click();            // их прошлых заданий мы знаем, где находится меню "Catalog", интеллектуальный поиск по имени не делаем для упрощения теста
            Console.Write(" MenuText="+ MenuText); //OK  отладка

            string locAddNewProduct = "#content > div:nth-child(2) > a:nth-child(2)[class=button]";  // локатор кнопки AddNewProduct
            eCurr = driver.FindElement(By.CssSelector(locAddNewProduct));
            eCurr.Click();

            // тут открывается новая форма Add New Product. Проверки на ее фактическое появление не делаем, задание учебное
            // (2) Достаточно заполнить только информацию на вкладках General, Information и Prices.Скидки(Campains) на вкладке Prices можно не добавлять.

            // находим URL вкладок:
            string linkGenTab = ""; // URL вкладки General 
            string linkInfoTab = ""; // URL вкладки Information
            string linkPricesTab = ""; // URL вкладки Prices

            string locTabs = "#content ul.index > li > a"; // локатор списка 5 элементов TAB
            IList<IWebElement> eTabs = driver.FindElements(By.CssSelector(locTabs));
            Console.Write(" eTabs.Count=" + eTabs.Count.ToString() + ";"); //OK  отладка

            string icheck, ihref; // для проверки в цикле

            for (int i=0; i< eTabs.Count; i++)
            {
                icheck = eTabs[i].GetAttribute("innerText").ToString();
                ihref = eTabs[i].GetAttribute("href").ToString();
                if (icheck == "General") { linkGenTab = ihref; };
                if (icheck == "Information") { linkInfoTab = ihref; };
                if (icheck == "Prices") { linkPricesTab = ihref; };
            }
            Console.Write(" linkGenTab=" + linkGenTab + ";"); //OK  отладка
            Console.Write(" linkInfoTab=" + linkInfoTab + ";"); //OK  отладка
            Console.Write(" linkPricesTab=" + linkPricesTab + ";"); //OK  отладка

            // ----------------------- переходим на вкладку General и заполняем элементы:
            driver.Url = linkGenTab;

            // (G-1) элемент Enabled
            string locEnabledRB = "#tab-general label:nth-child(3) > input[type='radio']"; // локатор радиобаттона Enabled
            eCurr = driver.FindElement(By.CssSelector(locEnabledRB));
            eCurr.Click();
            Console.Write(" Enabled=" + eCurr.GetAttribute("checked").ToString() + "; ");  // отладка

            // (G-2) элемент Name
            string NewProductName = GetUniqueProductName();
            string locNPN = "#tab-general input[type='text'][name='name[en]']"; // локатор поля ввода имени прдукта
            eCurr = driver.FindElement(By.CssSelector(locNPN));
            eCurr.SendKeys(NewProductName);

            // (G-3) элемент Code
            string NewProductCode = GetUniqueProductCode();
            string locNPC = "#tab-general input[type='text'][name=code]";  // локатор поля ввода кода прдукта
            eCurr = driver.FindElement(By.CssSelector(locNPC));
            eCurr.SendKeys(NewProductCode);

            // (G-4) 3 чекбокса категорий выбираем 2 последних
            string locCB0 = "#tab-general input[type=checkbox][name='categories[]'][value='0']";  // можно запихнуть в цикл
            string locCB1 = "#tab-general input[type=checkbox][name='categories[]'][value='1']";
            string locCB2 = "#tab-general input[type=checkbox][name='categories[]'][value='2']";

            eCurr = driver.FindElement(By.CssSelector(locCB1)); //наличие галки можно проверить через eCurr.GetAttribute("checked");
            eCurr.Click();
            eCurr = driver.FindElement(By.CssSelector(locCB2)); //наличие галки можно проверить через eCurr.GetAttribute("checked");
            eCurr.Click();

            // (G-5) Default Catgory только одна, код не нужен

            // (G-6) 3 чекбокса femail/male/unisex проставляем все
            string locCBFemale = "#tab-general input[type='checkbox'][name='product_groups[]'][value='1-2']";
            string locCBMale = "#tab-general input[type='checkbox'][name='product_groups[]'][value='1-1']";
            string locCBUnisex = "#tab-general input[type='checkbox'][name='product_groups[]'][value='1-3']";

            eCurr = driver.FindElement(By.CssSelector(locCBFemale));
            eCurr.Click();
            eCurr = driver.FindElement(By.CssSelector(locCBMale));
            eCurr.Click();
            eCurr = driver.FindElement(By.CssSelector(locCBUnisex));
            eCurr.Click();

            // (G-7) Quantity + остальные 3 поля оставляем по умолчанию
            string locQty = "#tab-general input[type=number][name=quantity]"; // локатор поля Quantity 
            Random rnd = new Random();
            string sRandomQty = rnd.Next(5, 9999).ToString(); // случайное число товара
            
            eCurr = driver.FindElement(By.CssSelector(locQty));
            eCurr.SendKeys(sRandomQty);

            // (G-8) Upload Image
            string locFUpload = "#tab-general input[type='file'][name='new_images[]']"; // локатор меню загрузки файлов
            //string pathToImg = @"C:\Users\SeaRu\source\repos\UnitTestProject4\UnitTestProject4\MeraDuck640x640_fwb.png";   // как-то задаем положение файла. Предполагается что это локальный путь
            // string pathToImg = Directory.GetCurrentDirectory() + @"\MeraDuck640x640_fwb_LOCAL.png";   // System/Win32
            string pathToImg = AppDomain.CurrentDomain.BaseDirectory + @"MD640.png"; //локальный путь к проекту (по умолчанию bin/debug)
            

            FileInfo fileInf = new FileInfo(pathToImg);  // затем полный путь к файлу получаем через свойство fileInf.FullName
            string fullpathToImg = fileInf.FullName;  // полный путь к файлу получаем через свойство fileInf.FullName
            Console.Write(" Path:" + fullpathToImg + ";");
            //string curDir = Directory.GetCurrentDirectory();
            //Console.Write(" curDir:" + curDir + ";");

             eCurr = driver.FindElement(By.CssSelector(locFUpload));
             eCurr.SendKeys(fullpathToImg);
             //eCurr.Click();   // клик не нужен
             Console.Write(" Image file uploaded from:" + fullpathToImg + ";");

            //throw new AssertFailedException();      //принудительно ломаем тест (отладка)

            // (G-9) указание дат
            string locDateFrom = "#tab-general input[type='date'][name=date_valid_from]"; // локаторы для полей ввода дат
            string locDateTo = "#tab-general input[type='date'][name=date_valid_to]";
            string dateFrom = "12/12/2017";
            string dateTo = "12/12/2025";

            eCurr = driver.FindElement(By.CssSelector(locDateFrom));
            eCurr.SendKeys(dateFrom);

            eCurr = driver.FindElement(By.CssSelector(locDateTo));
            eCurr.SendKeys(dateTo);



            // ----------- переходим на вкладку Information:
            driver.Url = linkInfoTab;
            string locInfoTab = "#content a[href='#tab-information']";  // локатор вкладки Information, для клика о нему
            eCurr = driver.FindElement(By.CssSelector(locInfoTab));
            eCurr.Click();  // это обязательно, иначе будут валиться element not vidible exceptions в следующих блоках

            // (I-1) производитель
            string locManID = "#tab-information select[name=manufacturer_id]"; // локатор id производителя
            eCurr = driver.FindElement(By.CssSelector(locManID));
            SelectElement selManList = new SelectElement(eCurr);     // Объект Select для работы со списком
            //selManList.SelectByIndex(1);   // выбирает 1й элемент в списке, т.к. других нет  (0й элемент это не то, что нужно)
            selManList.SelectByText("ACME Corp.");   // доступен только 1 элемент в списке
            Console.Write(" Manufacturer IDX=" + eCurr.GetAttribute("selectedIndex").ToString() + ";");

            // (I-2) производитель
            string locSupID = "#tab-information select[name=supplier_id]"; // локатор id поставщика
            eCurr = driver.FindElement(By.CssSelector(locSupID));
            SelectElement selSupList = new SelectElement(eCurr);     // Объект Select для работы со списком
            //selSupList.SelectByIndex(0);   // выбирает 1й элемент в списке, т.к. других нет  (0й элемент это не то, что нужно)
            selSupList.SelectByText("-- Select --");   // доступен только 0 элемент в списке
            Console.Write(" Supplier IDX=" + eCurr.GetAttribute("selectedIndex").ToString() + ";");

            // (I-3) ключевые слова
            string locKeyWords = "#tab-information input[type=text][name=keywords]";
            eCurr = driver.FindElement(By.CssSelector(locKeyWords));
            eCurr.SendKeys("MegaDuck, Mega Duck, Mega");
            Console.Write(" Keywords=" + eCurr.GetAttribute("value").ToString() + ";" );

            // (I-4) короткое описание Short Description
            string locShortDesc = "#tab-information input[type=text][name='short_description[en]']";
            eCurr = driver.FindElement(By.CssSelector(locShortDesc));
            eCurr.SendKeys("COOL DUCK");
            Console.Write(" Short Desc=" + eCurr.GetAttribute("value").ToString() + ";");

            // (I-5)  описание Description
            string locDesc = "#tab-information div.trumbowyg-editor";
            eCurr = driver.FindElement(By.CssSelector(locDesc));
            eCurr.SendKeys("COOL DUCK long long Description");
            Console.Write(" Desc=" + eCurr.GetAttribute("innerText").ToString() + ";");
            
            // (I-6)  описание Head Title
            string locHeadTitle = "#tab-information input[type=text][name='head_title[en]']";
            eCurr = driver.FindElement(By.CssSelector(locHeadTitle));
            eCurr.SendKeys("DUCK Head Title");
            Console.Write(" Head Title=" + eCurr.GetAttribute("value").ToString() + ";");
            
            // (I-7)  описание Meta Description
            string locMetaDesc = "#tab-information input[type=text][name='meta_description[en]']";
            eCurr = driver.FindElement(By.CssSelector(locMetaDesc));
            eCurr.SendKeys("DUCK Meta Description");
            Console.Write(" Meta Desc=" + eCurr.GetAttribute("value").ToString() + ";");

            
            // ------------ переходим на вкладку  Prices:
            driver.Url = linkPricesTab;

            string locPriceTab = "#content a[href='#tab-prices']";  // локатор вкладки Information, для клика о нему
            eCurr = driver.FindElement(By.CssSelector(locPriceTab));
            eCurr.Click();  // это обязательно, иначе будут валиться element not vidible exceptions в следующих блоках

            // (P-1) Purchase Price 
            string locPurPrice = "#tab-prices input[type=number][name=purchase_price]";
           
            eCurr = driver.FindElement(By.CssSelector(locPurPrice));
            eCurr.Clear(); // обязательно, иначе дальнейший ввод не сработает
            eCurr.SendKeys("22.50");
            //pauseMY();
            eCurr.SendKeys(Keys.Tab); // иначе введнное значение пропадает
            //Console.Write(" PurPrice=" + eCurr.GetAttribute("value").ToString() + ";");

            // (P-2) Purchase currency
            string locPurCurrency = "#tab-prices select[name=purchase_price_currency_code]";
            eCurr = driver.FindElement(By.CssSelector(locPurCurrency));
            SelectElement selCurList = new SelectElement(eCurr);     // Объект Select для работы со списком
            //selCurList.SelectByIndex(1);   // выбирает 1й элемент в списке
            selCurList.SelectByText("US Dollars");   // 
            Console.Write(" PurCurrency IDX=" + eCurr.GetAttribute("selectedIndex").ToString() + ";");

            // (P-3) TaxID
            string locTaxID = "#tab-prices select[name=tax_class_id]";
            eCurr = driver.FindElement(By.CssSelector(locTaxID));
            SelectElement selTaxList = new SelectElement(eCurr);     // Объект Select для работы со списком
            //selTaxList.SelectByIndex(0);   // выбирает 1й элемент в списке, т.к. других нет  (0й элемент это не то, что нужно)
            selTaxList.SelectByText("-- Select --");   // доступен только 0 элемент в списке
            Console.Write(" TaxID IDX=" + eCurr.GetAttribute("selectedIndex").ToString() + ";");

            // (P-4) Price USD
            string locPriceUSD = "#tab-prices input[type=text][name='prices[USD]']";
            eCurr = driver.FindElement(By.CssSelector(locPriceUSD));
            eCurr.SendKeys("29.99");
            Console.Write(" PriceUSD=" + eCurr.GetAttribute("value").ToString() + ";");

            // (P-5) Price EUR
            string locPriceEUR = "#tab-prices input[type=text][name='prices[EUR]']";
            eCurr = driver.FindElement(By.CssSelector(locPriceEUR));
            eCurr.SendKeys("39.99");
            Console.Write(" PriceEUR=" + eCurr.GetAttribute("value").ToString() + ";");


            // ---------  нажимаем кнопку Save -  ПОСЛЕ ЗАПОЛНЕНИЯ ВСЕХ ВКЛАДОК!!!  (3 шт)

            string locSaveBtn = "#content button[type=submit][name=save]"; // локатор кнопки Save
            eCurr = driver.FindElement(By.CssSelector(locSaveBtn));
            eCurr.Click();  // ВАЖНОЕ МЕСТО. ПРОИСХОДИТЬ РЕАЛЬНОЕ СОЗДАНИЕ ТОВАРА В БАЗЕ

            // ----------  проверка, что:
            // После сохранения товара нужно убедиться, что он появился в каталоге(в админке).

            // для отладки: 
            //string GoodName = "MegaDuck_02062018230448";
            string  GoodName = NewProductName; // при нормальном исполнении теста

            // Переходим на страницу каталога:
                              
            string SubmenuLocator = "li [id=doc-catalog] [href ^='http://localhost/litecart/admin/?app=catalog&doc=catalog']"; // Меню 2.1.
            driver.FindElement(By.CssSelector(SubmenuLocator)).Click();

            // Ищем товар в списке:

            //$$("#content > form > table > tbody > tr:nth-child(4) > td:nth-child(3) > a")
            //$$("#content > form > table > tbody > tr:nth-child(5) > td:nth-child(3) > a")
            //$$("#content > form > table > tbody > tr.row > td:nth-child(3)>a")
            //$$("#content  tr.row > td:nth-child(3)>a")
            string locGoodsList = "#content  tr.row > td:nth-child(3)>a"; //список элементов, у которых в поле text прописано название товара
            IList<IWebElement> eGoods = driver.FindElements(By.CssSelector(locGoodsList));
            Console.Write(" eGoods.Count=" + eGoods.Count.ToString() + ";");
            //eGoods.Count

            bool GoodFound = false; // проверка нахождения товара

            for (int i = 0; i < eGoods.Count; i++)
            {
                if (eGoods[i].GetAttribute("text") == GoodName)
                {
                    GoodFound = true;
                    break;
                };
            }

            if (GoodFound)
            {
                Console.Write(" NEW GOOD[" + GoodName + "] HAS RECORDED SUCESSFULLY");
            }
            else
            {
                throw new AssertFailedException();      //принудительно ломаем тест
            }; 

          
                Console.Write("Point 6.2. has reached; ");   // отладка

        }

        public string GetUniqueProductName()     //функция возвращает уникальный адрес электронной почты
        {
            DateTime datetime = DateTime.Now;  //предполагаем, что время будет уникальным при вызоые этой функции, т.е. ее вызов реже чем раз в 1 сек
            string NameUniq = datetime.ToString();
            NameUniq = NameUniq.Replace(":", ""); // удаляем ненужные символы
            NameUniq = NameUniq.Replace("/", "");
            NameUniq = NameUniq.Replace(".", "");
            NameUniq = NameUniq.Replace(",", "");
            NameUniq = NameUniq.Replace(" ", "");
            NameUniq = "MegaDuck_" + NameUniq;
            Console.Write("NameUniq = " + NameUniq + ";");   // отладка
            return (NameUniq);
        }

        public string GetUniqueProductCode()     //функция возвращает уникальный адрес электронной почты
        {
            DateTime datetime = DateTime.Now;  //предполагаем, что время будет уникальным при вызоые этой функции, т.е. ее вызов реже чем раз в 1 сек
            string NameUniq = datetime.ToString();
            NameUniq = NameUniq.Replace(":", ""); // удаляем ненужные символы
            NameUniq = NameUniq.Replace("/", "");
            NameUniq = NameUniq.Replace(".", "");
            NameUniq = NameUniq.Replace(",", "");
            NameUniq = NameUniq.Replace(" ", "");
            NameUniq = "MegaDuckCode_" + NameUniq;
            Console.Write("NameUniq = " + NameUniq + ";");   // отладка
            return (NameUniq);
        }

        public void pauseMY()       // впомогательная пауза
        {
            System.Threading.Thread.Sleep(1000);
        }

        public void LoginShopAdmin()    //Вспомогательный метод - логин админом в тестовый магазин, затем логаут
        {
            Console.Write("Point 4.1. has reached; ");   // отладка
                                                         // открытие  веб-магазина и логин в него:
                                                         // driver.Url = "http://localhost/litecart/en/";  // обычный магазин
            driver.Url = "http://localhost/litecart/admin/login.php"; // открытие админской консоли веб-магазина и логин в него:
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            Console.Write("Point 4.2. has reached; ");   // отладка
            Console.Write("Login sucessfull; ");   // отладка

        }

        public void LogoutShopAdmin()    //Вспомогательный метод - logout из магазина админ
        {
            Console.Write("Point 5.1. has reached; ");   // отладка
                                                         //  Logout:
                                                         // driver.FindElement(By.ClassName("fa")).Click();
            Console.Write("Point 5.2. has reached; ");   // отладка
            Console.Write("Logout sucessfull; ");   // отладка
        }

        [TearDown]
        public void Stop()
        {
            Console.Write("Point 3.1. has reached; ");   // отладка
            driver.Quit();
            driver = null;
            Console.Write("Point 3.2. has reached; ");   // отладка
            Console.Write("Logout sucessfull; ");   // отладка
        }
    }


}

namespace UnitTestProject4_lesson7
{
    [TestFixture]
    public class UnitTest1_lesson7_Task13         // учебное задание 13, добваление/удаление нового товара в корзину
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private const bool ConsoleDebug = true; // признак вывода на консоль для отладки

        [SetUp]
        public void Start()
        {
            Console.Write("Point 1.1. has reached; ");   // отладка
            driver = new ChromeDriver();    // 
            // driver = new FirefoxDriver();   //  
            // driver = new InternetExplorerDriver(); // 
            // driver = new EdgeDriver(); //

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));  // обязательна предыдущая строка
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);  // установка времени ожидания 5 сек
            Console.Write("Point 1.2. has reached; ");    // отладка
        }

        [Test]
        public void AddRemoveGoods()    // запуск теста 
        {
            Console.Write("Point 2.1. has reached; ");   // отладка
            //LoginShopAdmin();            // вход в магазин  (админом)
            ExecuteRoutineT13();     // основные шаги тестового задания
            //LogoutShopAdmin();         // выход из магазина 
            Console.Write("Point 2.2. has reached; ");   // отладка
        }

        public void ExecuteRoutineT13()    // основной тест 
        {   // Сделайте сценарий для добавления товаров в корзину и удаления товаров из корзины.
            // 1) открыть главную страницу
            // 2а) открыть первый товар из списка
            // 2б) добавить его в корзину(при этом может случайно добавиться товар, который там уже есть, ничего страшного)
            // 3) подождать, пока счётчик товаров в корзине обновится
            // 4) вернуться на главную страницу, повторить предыдущие шаги ещё два раза, чтобы в общей сложности в корзине было 3 единицы товара
            // 5) открыть корзину(в правом верхнем углу кликнуть по ссылке Checkout)
            // 6) удалить все товары из корзины один за другим, после каждого удаления подождать, пока внизу обновится таблица

            Console.Write("Point 6.1. has reached; ");
            // 1) открыть главную страницу
            // входим в магазин
            string StoreLink = "http://localhost/litecart/en/";    // линк на главную страницу магазина

            // 4) вернуться на главную страницу, повторить предыдущие шаги ещё два раза, чтобы в общей сложности в корзине было 3 единицы товара
            for (int j = 1; j <= 3; j++)
            {
                if (ConsoleDebug) { Console.Write(" j=" + j.ToString() + ";"); }; //  отладка

                driver.Url = StoreLink;
                if (ConsoleDebug) { Console.Write(" Store opened;"); }; //  отладка

                IWebElement eCurr; // итератор текущего элемента


                // 2а) открыть первый товар из списка
                string locFirstGood = "#box-most-popular ul li:nth-child(1) > a.link";       //локатор первого элемента
                eCurr = driver.FindElement(By.CssSelector(locFirstGood));
                eCurr.Click();
                if (ConsoleDebug) { Console.Write(" Good clicked;"); }; //  отладка

                // 2б) добавить его в корзину(при этом может случайно добавиться товар, который там уже есть, ничего страшного)
                string locCartCount = "#cart span.quantity"; //локатор счетчика товаров в корзине. Запоминаем значение 
                eCurr = driver.FindElement(By.CssSelector(locCartCount));
                string sCartCountPrev = eCurr.GetAttribute("innerText"); // запоминаем предыдущее значение. В тип int не переводим, т.к. отслеживаем только факт изменения
                if (ConsoleDebug) { Console.Write(" sCartCountPrev=" + sCartCountPrev + ";"); }; //  отладка

                // в корзину иногда попадает желтая Утка "Sale". Для нее требуется ввести в выпадающем списке значение, иначе невозможно ее добавить в корзину по клику
                string locSaleSelect = "#box-product  select[name='options[Size]']";
                try
                {
                    IWebElement weSel = driver.FindElement(By.CssSelector(locSaleSelect));  // ищем элемент. Если не находим, вылетает исключение NoSuchElementException e
                    SelectElement selSizeList = new SelectElement(weSel);     // Объект Select для работы со списком
                    selSizeList.SelectByIndex(2);   // выбирает 2й элемент в списке
                    //SelZoneList.SelectByText("Small");   // Варинат выбора по названию

                    //string actualValue = we.GetAttribute(attr);     // поиск значения атрибута
                    //if (ConsoleDebug) { Console.Write(" actualValue(" + i.ToString() + "," + attr + ")=" + actualValue + ";"); }; //  отладка
                                        
                }
                catch (NoSuchElementException e) { };   // если нет элемента, все хорошо, ничего заполнять не надо




                string locBtnAddToCart = "#box-product button[type=submit][name=add_cart_product]"; // локатор кнопки Add to Cart
                eCurr = driver.FindElement(By.CssSelector(locBtnAddToCart));
                eCurr.Click();
                if (ConsoleDebug) { Console.Write(" AddToCart clicked;"); }; //  отладка

                // 3) подождать, пока счётчик товаров в корзине обновится
                eCurr = driver.FindElement(By.CssSelector(locCartCount));
                string valCurr = eCurr.GetAttribute("innerText");
                if (ConsoleDebug) { Console.Write(" innerText=" + valCurr.ToString() + ";"); }; //  отладка

                bool wr = WaitForAttrValue(locCartCount, "innerText", j.ToString(), 15); // процедура ждет до появления значения переданного атрибута или срабатывания таймауа
                if (ConsoleDebug) { Console.Write(" Waited to price refresh; wr=" + wr.ToString() + ";"); }; //  отладка

                eCurr = driver.FindElement(By.CssSelector(locCartCount));
                valCurr = eCurr.GetAttribute("innerText");
                if (ConsoleDebug) { Console.Write(" innerText=" + valCurr.ToString() + ";"); }; //  отладка


               // pauseMY(3); // принудительная пауза на указанное количество секунд
            }


            // 5) открыть корзину(в правом верхнем углу кликнуть по ссылке Checkout)
            string locCheckOutLink = "#cart a.link[href='http://localhost/litecart/en/checkout']";
            IWebElement we = driver.FindElement(By.CssSelector(locCheckOutLink));
            we.Click();

            //здесь можно написать проверку ожидания того, что страница с нужным URL загрузилась
            if (ConsoleDebug) { Console.Write(" URL=" + driver.Url.ToString() + ";"); }; //  отладка

            string locRemoveButton = "#box-checkout-cart  ul > li:nth-child(1)  button[type=submit][name=remove_cart_item]"; // локатор кнопки Remove
            string locRowItem = "#order_confirmation-wrapper > table > tbody > tr:nth-child(2) > td:nth-child(1)"; // локатор 1-го элемент 1-й строки таблицы
            string locNoIems = "#checkout-cart-wrapper p:nth-child(1) em";  // локатор элемента с надписью "There are no items in your cart."
            bool LoopInterupt = false;
            IWebElement weRowItem;  // итератор в следующем цикле

            // 6) удалить все товары из корзины один за другим, после каждого удаления подождать, пока внизу обновится таблица
            for (int j = 1; j <= 3; j++)       // три раза кликнуть на кнопку по условию задания
            {
                // Важно - кнопка Remove при однократном нажатии может удалить  ДВА одинаковых товара, если они были в корзине. Тогда цикл свалится на j=3 c exception
                // Чтобы этого не происходило, проверяем, что кнопка Remove присуствует  - проверка в блока try|catch
                weRowItem = driver.FindElement(By.CssSelector(locRowItem));
                try
                {
                    we = driver.FindElement(By.CssSelector(locRemoveButton));   // находим кнопку Remove
                    we.Click(); // нажимаем ее
                                // сама кнопка исчезнет, на ее месте появится другая с точно таким же локатором. Нужно подождать, пока кнопка исчезнет, прежде чем повторять дейтвие
                    //wait.Until(ExpectedConditions.StalenessOf(we));  // ждем пока кнопка Remove исчезнет
                    wait.Until(ExpectedConditions.StalenessOf(weRowItem)); // если первый элемент 1й колонки исчез, значит таблица обновилась
                                                                           // если под "обновлением таблицы" понимать что-то другое. то можно реализовать более сложную логику
                }
                catch (NoSuchElementException e) { };

                if (ConsoleDebug) { Console.Write(" weRowItem[" + j.ToString() + "];"); }; //  отладка

                // проверка досрочного выхода их цикла, если уже появилась надпись "There are no items in your cart."
                try
                {
                    we = driver.FindElement(By.CssSelector(locNoIems));   // локатор элемента с надписью "There are no items in your cart."
                    LoopInterupt = true;
                 } catch (NoSuchElementException e) { };    // если исключение вылетело, то все хорошо - досрочно не выходим

                if (LoopInterupt & (j<3))   // последнее значение не нужно учитывать
                {
                    if (ConsoleDebug) { Console.Write(" LOOP INTERRUPTED;"); }; //  отладка
                    break;
                }
            }

            // Проверяем, что появилась надпись  "There are no items in your cart." Если она появилась - тест пройден. Если нет - выбрасываем исключение
          
            we = driver.FindElement(By.CssSelector(locNoIems));
            string NoItemsText = we.GetAttribute("innerText");
            if ("There are no items in your cart." == NoItemsText) { } else { throw new AssertFailedException(); }
            
            // if (true) { throw new AssertFailedException(); };      //принудительно ломаем тест
            
            Console.Write("Point 6.2. has reached; ");   // отладка

        }

        public bool WaitForAttrValue(string locElement, string attr, string val, int timeoutSec ) // процедура ожидания значения атрибута в переданном элементе. True если найденб false если нет
        {
            bool wasFound = false;
            for (int i=0; i< timeoutSec; i++)     // упрощенная версия цикла, засыпаем на 1 сек
            {

                try
                {
                    IWebElement we = driver.FindElement(By.CssSelector(locElement));  // ищем элемент. Если не находим, вылетает исключение
                    // сюда попадаем если элемент we найден
                    wasFound = true;
                    string actualValue = we.GetAttribute(attr);     // поиск значения атрибута
                    if (ConsoleDebug) { Console.Write(" actualValue(" + i.ToString() + "," + attr + ")=" + actualValue + ";"); }; //  отладка

                    if (actualValue == val)  // ожидаемое значение элемента соотвествует найденному
                    {
                        if (ConsoleDebug) { Console.Write(" Expected value found:" + actualValue + ";"); }; //  отладка
                        return true;
                    }

                    else
                    {
                        System.Threading.Thread.Sleep(1000); // засыпаем на 1 сек                ;       
                    };
                }
                catch (NoSuchElementException e)
                {
                    System.Threading.Thread.Sleep(1000); // засыпаем на 1 сек
                };
            }
            if (ConsoleDebug) { Console.Write(" wasFound=" + wasFound + ";"); }; //  отладка
            return false;  // ожидаемое значение элемента НЕ соотвествует найденному 
         }

        public void pauseMY(int sec)       // впомогательная пауза
        {
            System.Threading.Thread.Sleep(sec*1000);
        }

        public void LoginShopAdmin()    //Вспомогательный метод - логин админом в тестовый магазин, затем логаут
        {
            Console.Write("Point 4.1. has reached; ");   // отладка
                                                         // открытие  веб-магазина и логин в него:
                                                         // driver.Url = "http://localhost/litecart/en/";  // обычный магазин
            driver.Url = "http://localhost/litecart/admin/login.php"; // открытие админской консоли веб-магазина и логин в него:
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            Console.Write("Point 4.2. has reached; ");   // отладка
            Console.Write("Login sucessfull; ");   // отладка

        }

        public void LogoutShopAdmin()    //Вспомогательный метод - logout из магазина админ
        {
            Console.Write("Point 5.1. has reached; ");   // отладка
                                                         //  Logout:
                                                         // driver.FindElement(By.ClassName("fa")).Click();
            Console.Write("Point 5.2. has reached; ");   // отладка
            Console.Write("Logout sucessfull; ");   // отладка
        }

        [TearDown]
        public void Stop()
        {
            Console.Write("Point 3.1. has reached; ");   // отладка
            driver.Quit();
            driver = null;
            Console.Write("Point 3.2. has reached; ");   // отладка
            Console.Write("Logout sucessfull; ");   // отладка
        }
    }


}

