using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nancy_Repo_Project.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Nancy_Repo_Project.Pages
{
    internal class EmployeePage
    {
        internal void CreateEmployee(IWebDriver driver)
        {
            IWebElement createEmploy = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            Wait.ClickableElement(driver, "XPath", "//*[@id=\"container\"]/p/a", 10);
            createEmploy.Click();

            Wait.ElementVisible(driver, "CssSelector", "#container > h2", 10);

            IWebElement notice = driver.FindElement(By.CssSelector("#container > h2"));


            if (notice.Displayed)
            {
                Console.WriteLine(" create Page Appered");
            }

            else
            {
                Console.WriteLine("Failed");
            }

            IWebElement name = driver.FindElement(By.CssSelector("#Name"));
            name.SendKeys("Jessica Boss");


            IWebElement username = driver.FindElement(By.CssSelector("#Username"));
            username.SendKeys("Jessica_Boss003");



            IWebElement Password = driver.FindElement(By.CssSelector("#Password"));
            Password.SendKeys("300Boss_Jessica");


            IWebElement retry = driver.FindElement(By.CssSelector("#RetypePassword"));
            retry.SendKeys("300Boss_Jessica");

            IWebElement Savebtn = driver.FindElement(By.CssSelector("#SaveButton"));
            Savebtn.Click();

            // Go to TM page
            IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationDropdown.Click();
            Wait.ClickableElement(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a", 2);

            IWebElement eOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a"));
            eOption.Click();

            Wait.ClickableElement(driver, "XPath", "//*[@id=\"container\"]/p/a", 10);

            // Click on go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.CssSelector("#usersGrid > div.k-pager-wrap.k-grid-pager.k-widget > a.k-link.k-pager-nav.k-pager-last > span"));
            goToLastPageButton.Click();
            Thread.Sleep(2000);

            IWebElement actualEmployee = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(actualEmployee.Text == "Jessica Boss", "Employee not created");

        }

        internal void EditEmployee(IWebDriver driver)
        {
          

            // Click on go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.CssSelector("#usersGrid > div.k-pager-wrap.k-grid-pager.k-widget > a.k-link.k-pager-nav.k-pager-last > span"));
            goToLastPageButton.Click();
            Thread.Sleep(2000);

            IWebElement EditEmployee = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[1]"));
            EditEmployee.Click();

            IWebElement name = driver.FindElement(By.CssSelector("#Name"));
            name.Clear();
            name.SendKeys("New Jessica Boss");


            IWebElement username = driver.FindElement(By.CssSelector("#Username"));
            username.Clear();
            username.SendKeys("New_Jessica_Boss003");



            IWebElement Password = driver.FindElement(By.CssSelector("#Password"));
            Password.Clear();
            Password.SendKeys("300Boss_Jessica");


            IWebElement retry = driver.FindElement(By.CssSelector("#RetypePassword"));
            retry.Clear();
            retry.SendKeys("300Boss_Jessica");

            IWebElement Savebtn = driver.FindElement(By.CssSelector("#SaveButton"));
            Savebtn.Click();

            // Go to TM page
            IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationDropdown.Click();
            Wait.ClickableElement(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a", 2);

            IWebElement eOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a"));
            eOption.Click();

            Wait.ClickableElement(driver, "XPath", "//*[@id=\"container\"]/p/a", 10);

            // Click on go to last page button
            IWebElement goToLastPageButton1 = driver.FindElement(By.CssSelector("#usersGrid > div.k-pager-wrap.k-grid-pager.k-widget > a.k-link.k-pager-nav.k-pager-last > span"));
            goToLastPageButton1.Click();
            Thread.Sleep(2000);

            IWebElement actualEmployee = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(actualEmployee.Text == "New Jessica Boss", "Employee not created");



        }

        internal void DeleteEmployee(IWebDriver driver)
        {


            // Click on go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.CssSelector("#usersGrid > div.k-pager-wrap.k-grid-pager.k-widget > a.k-link.k-pager-nav.k-pager-last > span"));
            goToLastPageButton.Click();
            Thread.Sleep(2000);

            

            IWebElement findEditedEmployee = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if( findEditedEmployee.Text == "New Jessica Boss") 

            {
                IWebElement DeleteEmployee = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[2]"));
                DeleteEmployee.Click();
                Thread.Sleep(1000);
                driver.SwitchTo().Alert().Accept();

            }
            else
            {
                Assert.Fail("Employee to be deleted hasn't been found. Employee not deleted");
            }



        }
    }
}
