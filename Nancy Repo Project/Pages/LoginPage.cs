using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nancy_Repo_Project.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Nancy_Repo_Project.Pages
{
    internal class LoginPage
    {

        public void LoginSteps (IWebDriver driver)
        {

            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();


            // enter credentials and login


            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

            IWebElement username = driver.FindElement(By.Id("UserName"));
            username.SendKeys("hari");

            IWebElement password = driver.FindElement(By.Id("Password"));
            password.Clear();
            password.SendKeys("123123");

            IWebElement login = driver.FindElement(By.CssSelector("#loginForm > form > div:nth-child(5) > input.btn.btn-default"));
            login.Click();


            Wait.ElementVisible(driver, "CssSelector", "logoutForm > ul > li > a", 10);
            //check if login was successful
            IWebElement icon = driver.FindElement(By.CssSelector(" #logoutForm > ul > li > a"));

            String text = "Hello hari!";


            if (icon.Text == text)
            {
                Console.WriteLine("Test Pass, able to access dashboard");
            }

            else

            {
                Console.WriteLine("Test failed");
            }

        }

    }
}
