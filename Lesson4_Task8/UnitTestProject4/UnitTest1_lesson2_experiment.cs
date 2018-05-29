using System;
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
            if (H1check()) { Console.Write(">" + MenuText + " H1-OK; ");  } else { Console.Write(">" + MenuText + " H1-FAIL; ");  };

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
                Console.Write(" MainMenu(" +  i.ToString() + ") -> " + MainMenuList[i].Text.ToString() + "; ");
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
                        if (H1check()){ Console.Write("H1 check passed;"); }
                        else { Console.Write("H1 check failed;"); };
                     }
                }

            }
            
            Console.Write("Point 6.2. has reached; ");   // отладка
        }

        public Boolean H1check () //true если элемент H1 найден и false в обратном случае
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
                
                Console.Write(" Duck(" + (i+1).ToString() + ") -> " + OneDuck.Text.ToString() + ";");
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
                    { for (int j = 0; j < CurrSticks; j++)
                        {
                            Console.Write(" Stick #"+ (j+1).ToString() +" label = " + StickList[j].Text.ToString() + ";");
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