
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
            //button[@id='add-to-cart-sauce-labs-backpack']
            var div =driver.FindElement(By.XPath($"//div[text()='{itemName}']"));
            div.FindElement(By.XPath("//button[text()='Add to cart'")).Click();
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
            driver.FindElement(By.XPath($"//div[text()='Sauce Labs Backpack']/following-sibling::div/button")).Click();

        }

        [When(@"I click on the shopping cart icon")]
        public void WhenIClickOnTheShoppingCartIcon()
        {
            driver.FindElement(By.XPath("//a[@class='shopping_cart_link']")).Click();
        }

        [When(@"I enter my personal information")]
        public void WhenIEnterMyPersonalInformation()
        {
            driver.FindElement(By.Id("fist-name")).SendKeys("first name");
            driver.FindElement(By.Id("last-name")).SendKeys("last name");
            driver.FindElement(By.Id("postal-code")).SendKeys("1234");
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
