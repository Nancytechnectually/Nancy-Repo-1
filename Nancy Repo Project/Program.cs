using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Nancy_Repo_Project
{
    internal class Program
    {
        private static int k;
        private static int a;

        static void Main(string[] args)
        {

            // open chrome browser
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // launch turnup portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

            // enter credentials and login

            IWebElement username = driver.FindElement(By.Id("UserName"));
            username.SendKeys("hari");

            IWebElement password = driver.FindElement(By.Id("Password"));
            password.Clear();
            password.SendKeys("123123");

            IWebElement login = driver.FindElement(By.CssSelector("#loginForm > form > div:nth-child(5) > input.btn.btn-default"));
            login.Click();


            Thread.Sleep(1000);
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


            // Create Time and Material record

            // Go to TM page
            IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationDropdown.Click();

            IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            tmOption.Click();

            // Click on create new button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewButton.Click();

            // Select material from TypeCode dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();

            IWebElement materialOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
            Thread.Sleep(1000);

            materialOption.Click();

            // Identify the code textbox and input a code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("abcdef");

            // Identify the description textbox and input a description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("qwerty");

            // Identify the price textbox and input a price
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceTag.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("21");

            // Click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(5000);

            // Click on go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(5000);



            // Check if record create is present in the table and has expected value
           
            int b = 0;
            
            for (a = 1; a <= 10; a = a + 1 )
            {

                try
                {

                    IWebElement rows = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + a + "]/td[1]"));
                    if (rows.Displayed)
                    {
                        Console.WriteLine("Row + a + " + a);
                        b++;
                        Console.WriteLine("value of b is : " + a);

                    }
                    else
                    {
                        
                   

                        Console.WriteLine("Value of b is: " + b);
                      
                    
                    }
                }
                catch
                {
                    Console.WriteLine("No element");

                }

            }

            k = b;

            IWebElement actualCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + k + "]/td[1]"));



            if (actualCode.Text == "abcdef")
            {
                Console.WriteLine("Materail record created successfully, test passed.");
            }
            else
            {
                Console.WriteLine("Test failed.");



            }

            // Check if a user is able to edit the material record created in the previous test

            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + k + "]/td[5]/a[1]"));
            editButton.Click();


            try
            {
                driver.FindElement(By.XPath("//*[@id=\"files\"]"));
                Console.WriteLine("Test passed, user can edit the entry");
            }
            catch (Exception)
            {

                Console.WriteLine(" Test failed, user Cannot edit the entry");
            }


            IWebElement save = driver.FindElement(By.Id("SaveButton"));
            save.Click();

            Thread.Sleep(4000);

            // Click on go to last page button

            IWebElement goToLastPageButton2 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton2.Click();


            Thread.Sleep(4000);



            // Check if a user is able to delete the material record updated in the previous test


            IWebElement deletebtn = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + k + "]/td[5]/a[2]"));
            deletebtn.Click();


            try
            {

                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();

                Thread.Sleep(1000);

                Console.WriteLine("Test passed , entry has been deleted");
            }
            catch (Exception)
            {
                Console.WriteLine("Test failed");

            }

        }


    }
   

 }



