using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    class TestOne
    {
        static void Main(string[] args)
        {
            // Initiate new ChromeDriver called driver and navigate to login URL
            IWebDriver driver = new ChromeDriver(".");
            driver.Navigate().GoToUrl("https://login.yahoo.com/config/login?.src=finance&.intl=us&.done=https%3A%2F%2Ffinance.yahoo.com%2F");

            // Input username field, submit
            IWebElement username = driver.FindElement(By.Name("username"));
            username.SendKeys("mikeishere3@intracitygeeks.org");
            username.Submit();

            // Initiate new driver wait to wait for page to load and elements to appear
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            
            // Wait, then Input password field, submit using click
            IWebElement password = wait.Until(d => driver.FindElement(By.Id("login-passwd")));
            password.SendKeys("scraper123");
            IWebElement submit = driver.FindElement(By.Id("login-signin"));
            submit.Click();

            // Navigate to portfolio url once logged in
            driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_0/view/v1");

            // Wait for tr elements to load
            wait.Until(d => driver.FindElements(By.TagName("tr")));

            int count;
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> list = driver.FindElements(By.TagName("tr"));
            count = list.Count;
            //foreach (IWebElement row in list)
            //{
            //    count++;
            //}

            Console.WriteLine("There are " + count + " stocks in the list");

            // Loop to iterate through names and prices of stocks
            for (int i = 1; i < count; i++)
            {
                var symbol = driver.FindElement(By.XPath("//*[@id=\"main\"]/section/section[2]/div[2]/table/tbody/tr[" + i + "]/td[1]/span/a")).Text;
                var price = driver.FindElement(By.XPath("//*[@id=\"main\"]/section/section[2]/div[2]/table/tbody/tr[" + i + "]/td[2]/span")).Text;
                
                Console.WriteLine(symbol + " " + price);
            }

            
            Console.WriteLine("Scraped.");
            

        }
    }
}
