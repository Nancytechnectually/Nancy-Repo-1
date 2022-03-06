using System;
using OpenQA.Selenium;
using Nancy_Repo_Project.Utilities;
using System.Threading;
using System;
using NUnit.Framework;

namespace Nancy_Repo_Project
{
    internal class TMPage
    {
        private static int k;
        public static int b;
        public static int a;

        public void CreateNew(IWebDriver driver)
        {
            // Click on create new button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewButton.Click();

            // Select material from TypeCode dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();

            IWebElement materialOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
            Wait.ClickableElement(driver, "Id", "Code", 10);

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


             Wait.ElementVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 10);

            //Thread.Sleep(2000);
            // Click on go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(2000);
        }

        public  void CountTM(IWebDriver driver)
        {

            // Check if record create is present in the table and has expected value

            int b = 0;
            for (a = 1; a <= 10; a = a + 1)
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

        }

        public void editTM(IWebDriver driver)
        {
            // Check if a user is able to edit the material record created in the previous test

            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + k + "]/td[5]/a[1]"));
            editButton.Click();



            // Select material from TypeCode dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();

            IWebElement materialOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
            Wait.ClickableElement(driver, "Id", "Code", 10);

            materialOption.Click();



            // Identify the code textbox and input a code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.Clear();
            codeTextbox.SendKeys("Edited abcdef");

            // Identify the description textbox and input a description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.Clear();
            descriptionTextbox.SendKeys("Edited qwerty");

            // Edit price
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));

            priceTag.Click();
            priceTextbox.Clear();
            priceTag.Click();
            priceTextbox.SendKeys("120");

            IWebElement save = driver.FindElement(By.Id("SaveButton"));
            save.Click();


            Wait.ElementVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 10);
            //Thread.Sleep(2000);

            // Click on go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(2000);

            IWebElement newEntry = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + k + "]/td[1]"));

           /* if (newEntry.Text == "Edited qwerty")

            {
              Console.WriteLine("Test Passed ")  ;
            }

            else
            
            {
                Console.WriteLine("Test Failed ");

            }*/

            // Assertion
            IWebElement createdCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement createdTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            IWebElement createdDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement createdPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            Assert.That(createdCode.Text == "Edited abcdef", "Code record hasn't been edited.");
            Assert.That(createdTypeCode.Text == "M", "TypeCode record hasn't been edited.");
            Assert.That(createdDescription.Text == "Edited qwerty", "Description record hasn't been edited.");
            Assert.That(createdPrice.Text == "$120.00", "Price record hasn't been edited.");



        }

        public void deleteTM(IWebDriver driver)

        {

            // Check if a user is able to delete the material record updated in the previous test
           

            IWebElement deletebtn = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + k + "]/td[5]/a[2]"));
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
                Assert.Fail("Record to be deleted hasn't been found. Record not deleted");

            }

            // Assert that Time record has been deleted
            driver.Navigate().Refresh();
            Thread.Sleep(1000);

            IWebElement goToLastPageButton1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton1.Click();
            Thread.Sleep(1000);

            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement editedPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            // Assertion
            Assert.That(editedCode.Text != "EditedFebruary2022", "Code record hasn't been deleted.");
            Assert.That(editedDescription.Text != "EditedFebruary2022", "Description record hasn't been deleted.");
            Assert.That(editedPrice.Text != "$170.00", "Price record hasn't been deleted.");



        }
    }
}