using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;                  // не было в тестовом примере
using OpenQA.Selenium.Support.UI;       // не было в тестовом примере
using OpenQA.Selenium.Chrome;           // не было в тестовом примере
using NUnit;                            // не было в тестовом примере
using NUnit.Framework;                  // нужно для понимания аттрибутов [TextFixture]
using NUnit.Framework.Internal;         // не было в тестовом примере



namespace UnitTestProject4_lesson2
{
    [TestClass] 
    public class UnitTest1_lesson2_RunAll
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [TestMethod]
        public void FirstTestRunAll()
        {
            driver = new ChromeDriver();
            driver.Url = "http://www.ya.ru/";
            driver.Quit();
            driver = null;
        }
    }

    [TestFixture]
    public class UnitTest1_lesson2
    {
        private IWebDriver driver;
        private WebDriverWait wait;
           

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void FirstTest()    //почему-то при запуске ничего не происходит (браузер не запускается). Метод FirstTestRunAll() прекрасно работает
        {
            driver.Url = "http://www.ya.ru/";
            //driver.Url = "http://www.google.com/";
            //driver.FindElement(By.Name("q")).SendKeys("webdriver");
            //driver.FindElement(By.Name("btnG")).Click();
            //wait.Until(ExpectedConditions.TitleIs("webdriver - поиск в Google"));
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }

    }
       
       
    }
