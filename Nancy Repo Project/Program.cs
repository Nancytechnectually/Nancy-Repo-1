using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Nancy_Repo_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String url = "http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f";
            // open chrome browser
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // launch turnup portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

            // click on Dasboard 

            IWebElement Dashboard = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul[1]/li[1]/a"));          Dashboard.Click();

           
            // check if dashboard button responds without login


            driver.Navigate().GoToUrl(url);

            String newurl = driver.Url;


            if ( newurl == url)
               
            {
                Console.WriteLine("Test Pass, unable to access dashboard");
            }
            else
            {
                Console.WriteLine("Test failed");

            }
        }
    }
}


