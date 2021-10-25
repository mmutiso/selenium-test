using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloSelenium();
        }

        static void HelloSelenium()
        {
            string username = "";
            string password = "";

            using (IWebDriver driver = new ChromeDriver())
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                driver.Navigate().GoToUrl("url here");

                wait.Until(webDriver => webDriver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div[1]")).Displayed);

                driver.FindElement(By.Id("username-input")).SendKeys(username);
                driver.FindElement(By.Id("password-input")).SendKeys(password + Keys.Enter);
                wait.Until(webDriver => webDriver.FindElement(By.CssSelector("div.MuiGrid-root.MuiGrid-container.MuiGrid-spacing-xs-2")).Displayed);
                IWebElement firstResult = driver.FindElement(By.XPath("//*[@id=\"root\"]/div/main/div[3]/div/div/div/div[1]/div"));
                Console.WriteLine(firstResult.Text);
            }
        }
    }
}
