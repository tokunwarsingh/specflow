
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using ECart.AccpetanceTests.PageObject;
using OpenQA.Selenium.DevTools.V115.Tracing;

namespace ECart.AccpetanceTests.StepDefinitions
{
    [Binding]
    public class CartStepDefinitions : BaseStepDefinition
    {
       
        [When(@"I add the ""([^""]*)"" to the cart")]
        public void WhenIAddTheToTheCart(string itemName)
        {
            // driver.FindElement(By.XPath($"//div[@class='inventory_item_name' and text()='{itemName}']/ancestor::div[@class='inventory_item']//button")).Click();           
            CartPageObject cartPageObject = new CartPageObject(driver);
            cartPageObject.AddProductToCart(itemName);
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
            CartPageObject cartPageObject = new CartPageObject(driver);
            cartPageObject.AddProductToCart("Sauce Labs Backpack");

           // driver.FindElement(By.XPath($"//div[@class='inventory_item_name' and text()='Sauce Labs Backpack']/ancestor::div[@class='inventory_item']//button")).Click();
        }

        [When(@"I click on the ""([^""]*)"" button")]
        public void WhenIClickOnTheButton(string buttonText)
        {
           
            if (buttonText.Equals("Continue"))
            {
                CartPageObject cartPageObject = new CartPageObject(driver);

                cartPageObject.ContinuteButtonClick();
            }
            if (buttonText.Equals("Checkout"))
            {
                CartPageObject cartPageObject = new CartPageObject(driver);

                cartPageObject.CheckoutButtonClick();
            }
            if (buttonText.Equals("Finish"))
            {
                CartPageObject cartPageObject = new CartPageObject(driver);
                cartPageObject.FinishButtonClick();
            }

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
            CartPageObject cartPageObject = new CartPageObject(driver);
            cartPageObject.AddPersobalInfo();
           
        }

        [When(@"I verify the order summary")]
        public void WhenIVerifyTheOrderSummary()
        {
            CartPageObject cartPageObject = new CartPageObject(driver);
            Assert.IsTrue(cartPageObject.finishButton.Enabled);
        }

        [Then(@"I should see the order confirmation page")]
        public void ThenIShouldSeeTheOrderConfirmationPage()
        {
            CartPageObject cartPageObject = new CartPageObject(driver);
            

          // var confirmationMessage= driver.FindElement(By.XPath("//h2[normalize-space()='Thank you for your order!']"));
            Assert.IsTrue(cartPageObject.confirmationMessage.Enabled);
        }
    }
}
