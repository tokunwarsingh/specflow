
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace ECart.AccpetanceTests.StepDefinitions
{
    [Binding]
    public class CartStepDefinitions : BaseStepDefinition
    {
       
        [When(@"I add the ""([^""]*)"" to the cart")]
        public void WhenIAddTheToTheCart(string itemName)
        {            
            driver.FindElement(By.XPath($"//div[@class='inventory_item_name' and text()='{itemName}']/ancestor::div[@class='inventory_item']//button")).Click();           
        }

        [Then(@"I should see (.*) items in the shopping cart")]
        public void ThenIShouldSeeItemsInTheShoppingCart(int itemCount)
        {
            var cartBadge = driver.FindElement(By.CssSelector(".shopping_cart_badge"));
            int actualItemCount = int.Parse(cartBadge.Text);

            // Add an assertion to compare the actual item count with the expected
            Assert.AreEqual(itemCount, actualItemCount);
        }

        [Given(@"I have added items to the cart")]
        public void GivenIHaveAddedItemsToTheCart()
        {
            driver.FindElement(By.XPath($"//div[@class='inventory_item_name' and text()='Sauce Labs Backpack']/ancestor::div[@class='inventory_item']//button")).Click();
        }

        [When(@"I click on the ""([^""]*)"" button")]
        public void WhenIClickOnTheButton(string buttonText)
        {
            driver.FindElement(By.XPath($"//button[text()='{buttonText}']")).Click();
        }


        [When(@"I click on the shopping cart icon")]
        public void WhenIClickOnTheShoppingCartIcon()
        {
            driver.FindElement(By.XPath("//a[@class='shopping_cart_link']")).Click();
        }

        [When(@"I enter my personal information")]
        public void WhenIEnterMyPersonalInformation()
        {
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@id='first-name']")).SendKeys("first name");
            driver.FindElement(By.XPath("//input[@id='last-name']")).SendKeys("last name");
            driver.FindElement(By.XPath("//input[@id='postal-code']")).SendKeys("1234");
        }

        [When(@"I verify the order summary")]
        public void WhenIVerifyTheOrderSummary()
        {
            var finishButton= driver.FindElement(By.Id("finish"));
            Assert.IsTrue(finishButton.Enabled);
        }

        [Then(@"I should see the order confirmation page")]
        public void ThenIShouldSeeTheOrderConfirmationPage()
        {
           var confirmationMessage= driver.FindElement(By.XPath("//h2[normalize-space()='Thank you for your order!']"));
            Assert.IsTrue(confirmationMessage.Enabled);
        }
    }
}
