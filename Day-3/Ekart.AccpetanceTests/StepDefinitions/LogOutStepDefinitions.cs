
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;

namespace ECart.AccpetanceTests.StepDefinitions
{
    [Binding]
    public class LogOutStepDefinitions : BaseStepDefinition
        {
       

        [Given(@"I am logged into the website as ""([^""]*)""")]
        public void GivenIAmLoggedIntoTheWebsiteAs(string username)
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com");
            driver.FindElement(By.Id("user-name")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.XPath($"//input[@value='Login']")).Click();
        }

        [When(@"I click on the menu")]
        public void WhenIClickOnTheMenu()
        {
            driver.FindElement(By.Id("react-burger-menu-btn")).Click();
        }

        [When(@"I click the ""([^""]*)"" option")]
        public void WhenIClickTheOption(string logout)
        {
            Thread.Sleep(5000);
            driver.FindElement(By.Id("logout_sidebar_link")).Click();
        }


        [Then(@"I should see the login page")]
        public void ThenIShouldSeeTheLoginPage()
        {            
            // Add an assertion to verify that you are on the login page
            Assert.AreEqual("Swag Labs", driver.Title);
        }

    }
}

