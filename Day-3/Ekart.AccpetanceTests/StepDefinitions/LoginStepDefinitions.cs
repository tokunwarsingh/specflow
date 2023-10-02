using ECart.AccpetanceTests.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace ECart.AccpetanceTests.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions :BaseStepDefinition
    {
        

        [Given(@"I am on the SauceDemo website homepage")]
        public void GivenIAmOnTheSauceDemoWebsiteHomepage()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com");
        }

        [When(@"I enter the username ""([^""]*)""")]
        public void WhenIEnterTheUsername(string username)
        {
            LoginPageObject loginpageObject = new LoginPageObject(driver);
            loginpageObject.EnterUserId(username);
        }

        [When(@"I enter the password ""([^""]*)""")]
        public void WhenIEnterThePassword(string password)
        {
            LoginPageObject loginpageObject = new LoginPageObject(driver);
            loginpageObject.EnterUserPaqssord(password);

            //driver.FindElement(By.Id("password")).SendKeys(password);
        }

        [When(@"I click the ""([^""]*)"" button")]
        public void WhenIClickTheButton(string buttonText)
        {
            LoginPageObject loginpageObject = new LoginPageObject(driver);
            loginpageObject.ClickOnLoginButton();
            //driver.FindElement(By.XPath($"//input[@value='{buttonText}']")).Click();
        }

        [Then(@"I should see the Products page")]
        public void ThenIShouldSeeTheProductsPage()
        {
            // Add an assertion to verify that you are on the Products page
            Assert.IsTrue(driver.Url.Contains("inventory.html"));
        }

        [Then(@"I should see an error message")]
        public void ThenIShouldSeeAnErrorMessage()
        {
            // Add an assertion to verify the presence of an error message
            //IWebElement errorMessage = driver.FindElement(By.CssSelector(".error-message-container"));
            LoginPageObject loginpageObject = new LoginPageObject(driver);
            Assert.IsTrue(loginpageObject.IsErrorMessageDisplay());

        }  

    }

}
