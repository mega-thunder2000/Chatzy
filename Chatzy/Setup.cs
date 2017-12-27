using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Chatzy
{
    class Setup
    {
        static void Main(string[] args)
        {
            IWebDriver driver;
            var driverService = PhantomJSDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            driver = new PhantomJSDriver(driverService);

            var collection = Enumerable.Range(0, 1338);
            foreach (var item in collection)
            {
                driver.Url = "http://collabedit.com/new"; driver.Navigate();
                string page = driver.Url.Split('/').Last();
                File.AppendAllText("Collabedit.txt", page + Environment.NewLine);
                driver.Url = "www.bing.com"; driver.Navigate();
            }
            driver.Close();

            var lines = File.ReadAllLines("Collabedit.txt");
            Array.Sort(lines);
            File.WriteAllLines("Collabedit.txt", lines);
        }
    }
}
