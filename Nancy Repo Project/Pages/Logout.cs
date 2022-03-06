using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Nancy_Repo_Project.Utilities;

namespace Nancy_Repo_Project.Pages
{
    internal class Logout
    {

      

        internal void logoutFunction(IWebDriver driver)
        {

            driver.Quit();





        }
    }
}
