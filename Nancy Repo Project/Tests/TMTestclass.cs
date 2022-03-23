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
    [Parallelizable]
    internal class TMTestclass : CommonDriver 
    {
     
        [SetUp]
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
            TMPageobj.CreateTM(driver);

        }

        [Test, Order(2)]
        public void TC_2EditTM_Test()
        {
                 


            //Editcommand  object initialization and definition
            TMPage TMPageobj2 = new TMPage();
            TMPageobj2.EditTM(driver, "Dummy1", "Dummy2", "Dummy3");


        }

       [Test, Order(3)]

        public void TC_3DeleteTM_Test()
        {


            //Celete object initialization and definition
            TMPage TMPageobj3 = new TMPage();
            TMPageobj3.DeleteTM(driver);



        }           

        [TearDown]
        public void LogoutTM_Test()
        {
            //logout the chrome window 
            Logout logoutobj = new Logout();
            logoutobj.logoutFunction(driver);


        }



    }


}



