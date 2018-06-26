using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    class TestOne
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(".");
            driver.Navigate().GoToUrl("https://login.yahoo.com/config/login?.src=finance&.intl=us&.done=https%3A%2F%2Ffinance.yahoo.com%2F");

            Console.WriteLine("We scrapin' bruh!");

            IWebElement username = driver.FindElement(By.Name("username"));
            username.SendKeys("mikeishere3@intracitygeeks.org");
            username.Submit();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            

            IWebElement password = wait.Until(d => driver.FindElement(By.Id("login-passwd")));
            password.SendKeys("scraper123");
            IWebElement submit = driver.FindElement(By.Id("login-signin"));
            submit.Click();

            Console.WriteLine("We're in!");

            driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_0/view/v1?bypass=true");


        }
    }
}
