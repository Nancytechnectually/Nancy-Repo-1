using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy_Repo_Project.Pages;
using Nancy_Repo_Project.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace Nancy_Repo_Project.Tests
{
    internal class EmployeeTest
    {
        [TestFixture]
        [Parallelizable]
        internal class Employee_Tests : CommonDriver


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



            [Test, Order(1), Description("Check if user is able to create an employee with valid data")]
            public void CreateEmployee_Test()
            {
                // Home page object intialzation and definition
                HomePage homePageObj = new HomePage();
                homePageObj.GoToEmployeePage(driver);

                // TM page object intialzation and definition
                EmployeePage employPageObj = new EmployeePage();
                employPageObj.CreateEmployee(driver);
            }

            [Test, Order(2), Description("Check if user is able to edit an employee with valid data")]
            public void EditEmployee_Test()
            {
                // Home page object intialzation and definition
                HomePage homePageObj = new HomePage();
                homePageObj.GoToEmployeePage(driver);

                // Edit TM
                EmployeePage employPageObj = new EmployeePage();
                employPageObj.EditEmployee(driver);
            }

            [Test, Order(3), Description("Check if user is able to delete an existing employee")]
            public void DeleteEmployee_Test()
            {
                // Home page object intialzation and definition
                HomePage homePageObj = new HomePage();
                homePageObj.GoToEmployeePage(driver);

                // Delete TM
                EmployeePage employPageObj = new EmployeePage();
                employPageObj.DeleteEmployee(driver);
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

}





