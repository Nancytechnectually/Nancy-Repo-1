using System;
using Nancy_Repo_Project.Pages;
using Nancy_Repo_Project.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Nancy_Repo_Project
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        LoginPage LoginPageobj = new LoginPage();
        HomePage dashboardobj = new HomePage();
        TMPage TMPageobj = new TMPage();


        [Given(@"I can login successfully into turnup portal")]
        public void GivenICanLoginSuccessfullyIntoTurnupPortal()
        {
            LoginPageobj.LoginSteps(driver);

        }

        [Given(@"I navigated to the time and material page")]
        public void GivenINavigatedToTheTimeAndMaterialPage()
        {
            dashboardobj.dashboard(driver);
        }

        [When(@"I have created new record")]
        public void WhenIHaveCreatedNewRecord()
        {
            TMPageobj.CreateTM(driver);
        }


        [Then(@"I can see the new entered record on last page")]
        public void ThenICanSeeTheNewEnteredRecordOnLastPage()
        {
            String newCode = TMPageobj.GetCode(driver);
            String newTypecode = TMPageobj.GetTypeCode(driver);
            String newDescription = TMPageobj.GetDescription(driver);
            String newPrice = TMPageobj.GetPrice(driver);



            Assert.That(newCode == "February2022", "Actual code and expected code do not match");
            Assert.That(newTypecode == "M", "Actual type code and expected type code do not match");
            Assert.That(newDescription == "February2022", "Actual description and expected description do not match");
            Assert.That(newPrice == "$12.00", "Actual price and expected price do not match");



        }


        [When(@"I Update '([^']*)' of existing record with valid data")]



        [When(@"I Update '([^']*)' , '([^']*)' and '([^']*)' of existing record with valid data")]
        public void WhenIUpdateAndOfExistingRecordWithValidData(string p0, string p1, string p2)
        {

            TMPageobj.EditTM(driver, p0, p1, p2);

        }

        [Then(@"I checked the updated '([^']*)' , '([^']*)' and '([^']*)'is present on Time and material page")]
        public void ThenICheckedTheUpdatedAndIsPresentOnTimeAndMaterialPage(string p0, string p1, string p2)
        {

            String Des = TMPageobj.NewEditedDescription(driver);
            String EditCode = TMPageobj.GetEditedCode(driver);
            String EditPrice = TMPageobj.GetEditedPrice(driver);




            Assert.That(Des == p0, "New Description Do not match with Expected description");
            Assert.That(EditCode == p1, "New Description Do not match with Expected description");
            Assert.That(EditPrice == p2, "New Description Do not match with Expected description");


        }





       





    }
}
