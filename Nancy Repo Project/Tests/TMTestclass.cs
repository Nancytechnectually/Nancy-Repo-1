using System;
using System.Threading;
using Nancy_Repo_Project.Pages;
using Nancy_Repo_Project.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Nancy_Repo_Project
{
    [TestFixture]
    internal class TMTestclass : CommonDriver 
    {
     
        [OneTimeSetUp]
        public void LoginFunation()
        {
            // open chrome browser
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            //loginPage object initialization and definition

            LoginPage LoginPageobj = new LoginPage();
            LoginPageobj.LoginSteps(driver);

            //HomePage object initialization and definition

            HomePage dashboardobj = new HomePage();
            dashboardobj.dashboard(driver);

        }
        [Test, Order(1)]
        public void TC_1CreateTM_Test()
        {
            //HomePage object initialization and definition

            TMPage TMPageobj = new TMPage();
            TMPageobj.CreateNew(driver);

        }

        [Test, Order(2)]
        public void TC_2EditTM_Test()
        {
            //TMPage object initialization and definition

            TMPage TMPageobj1 = new TMPage();
            TMPageobj1.CountTM(driver);

            //HomePage object initialization and definition
            TMPage TMPageobj2 = new TMPage();
            TMPageobj2.editTM(driver);


        }

       [Test, Order(3)]

        public void TC_3DeleteTM_Test()
        {

            TMPage TMPageobj1 = new TMPage();
            TMPageobj1.CountTM(driver);

            //HomePage object initialization and definition
            TMPage TMPageobj3 = new TMPage();
            TMPageobj3.deleteTM(driver);



        }           

        [OneTimeTearDown]
        public void LogoutTM_Test()
        {
            //logout the chrome window 
            Logout logoutobj = new Logout();
            logoutobj.logoutFunction(driver);


        }



    }


}



