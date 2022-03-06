using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Nancy_Repo_Project.Utilities
{
    internal class Wait
    {
        public static void ClickableElement(IWebDriver driver, String locator, String locatorValue, int seconds)
        {
            var Wait = new WebDriverWait(driver, new TimeSpan(0,0,seconds));

            if (locator == "XPath")
            {

                Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
            }
            else if (locator == "Cssselector")
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorValue)));

            }
            else if (locator == "Id")
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(locatorValue)));

            }
            else if (locator == "ClassName")
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(locatorValue)));

            }
            else if (locator == "Name")
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(locatorValue)));

            }
        }


        public static void ElementVisible(IWebDriver driver, String locator, String locatorValue, int seconds)
        {
            var Wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));

            if (locator == "XPath")
            {

                Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
            }
            else if (locator == "Cssselector")
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(locatorValue)));

            }
            else if (locator == "Id")
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locatorValue)));

            }
            else if (locator == "ClassName")
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(locatorValue)));

            }
            else if (locator == "Name")
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(By.Name(locatorValue)));

            }


        }


        public static void ElementNotVisible (IWebDriver driver, String locator, String locatorValue, int seconds)
        {
            var Wait = new WebDriverWait(driver, new TimeSpan(0,0,seconds));

            if (locator == "XPath")
            {

                Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(locatorValue)));
            }
            else if (locator == "Cssselector")
            {
                Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(locatorValue)));

            }
            else if (locator == "Id")
            {
                Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id(locatorValue)));

            }
            else if (locator == "ClassName")
            {
                Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName(locatorValue)));

            }
            else if (locator == "Name")
            {
                Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Name(locatorValue)));

            }
        }




    }
}



     
