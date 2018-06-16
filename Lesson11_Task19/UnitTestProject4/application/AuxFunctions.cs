using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace UnitTestProject4_L11
{
    class AuxFunctions          //полезные вспомогательные функции
    {

        public static bool WaitForAttrValue(IWebDriver driver, string locElement, string attr, string val, int timeoutSec) // процедура ожидания значения атрибута в переданном элементе. True если найденб false если нет
        {
            bool wasFound = false;
            for (int i = 0; i < timeoutSec; i++)     // упрощенная версия цикла, засыпаем на 1 сек
            {

                try
                {
                    IWebElement we = driver.FindElement(By.CssSelector(locElement));  // ищем элемент. Если не находим, вылетает исключение
                    // сюда попадаем если элемент we найден
                    wasFound = true;
                    string actualValue = we.GetAttribute(attr);     // поиск значения атрибута
                    //if (ConsoleDebug) { Console.Write(" actualValue(" + i.ToString() + "," + attr + ")=" + actualValue + ";"); }; //  отладка

                    if (actualValue == val)  // ожидаемое значение элемента соотвествует найденному
                    {
                        //if (ConsoleDebug) { Console.Write(" Expected value found:" + actualValue + ";"); }; //  отладка
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
            //if (ConsoleDebug) { Console.Write(" wasFound=" + wasFound + ";"); }; //  отладка
            return false;  // ожидаемое значение элемента НЕ соотвествует найденному 
        }

        public static void pauseMY(int sec)       // впомогательная пауза
        {
            System.Threading.Thread.Sleep(sec * 1000);
        }


    }
}
