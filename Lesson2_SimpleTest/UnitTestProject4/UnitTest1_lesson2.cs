using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;                  // не было в тестовом примере
using OpenQA.Selenium.Support.UI;       // не было в тестовом примере
using OpenQA.Selenium.Chrome;           // не было в тестовом примере
using NUnit;                            // не было в тестовом примере
using NUnit.Framework.Internal;         // не было в тестовом примере


namespace UnitTestProject4_lesson2
{
    //[TestFixture]    // не работает в тестовом примере
    [TestClass]
    public class UnitTest1_lesson2
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        
        [TestMethod]
        public void FirstTestRunAll()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Url = "http://www.ya.ru/";

            //driver.Url = "http://www.google.ru/"; // эти строки теста не работает, на сайте гугл появляется непредусмотренное диалоговое окно.
            //driver.FindElement(By.Name("q")).SendKeys("webdriver"); 
            //driver.FindElement(By.Name("btnG")).Click();
            //wait.Until(ExpectedConditions.TitleIs("webdriver - поиск в Google"));

            driver.Quit();
            driver = null;
        }

        //[SetUp] // не работает в тестовом примере
        [TestMethod]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        //[Test] // не работает в тестовом примере
        [TestMethod]
        public void FirstTest()
        {
            driver.Url = "http://www.google.com/";
            //driver.FindElement(By.Name("q")).SendKeys("webdriver");
            //driver.FindElement(By.Name("btnG")).Click();
            //wait.Until(ExpectedConditions.TitleIs("webdriver - поиск в Google"));
        }

        //[TearDown] // не работает в тестовом примере
        [TestMethod]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }

        

    }
}
