using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy_Repo_Project.Utilities;
using OpenQA.Selenium;

namespace Nancy_Repo_Project.Pages
{
    internal class HomePage
    {

        public void dashboard (IWebDriver driver)
        {

            // Go to TM page
            IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationDropdown.Click();
            Wait.ClickableElement(driver, "Xpath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 10);

            IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            tmOption.Click();

        }

        internal void GoToEmployeePage(IWebDriver driver)
        {
            // Go to TM page
            IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationDropdown.Click();
            Wait.ClickableElement(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a", 2);

            IWebElement eOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a"));
            eOption.Click();


        }
    }
}
