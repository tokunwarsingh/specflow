
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
    public class ProductStepDefinitions:BaseStepDefinition
    {
        
        [Given(@"I am at product page")]
        public void GivenIAmAtProductPage()
        {
        }

        /*
        [When(@"I enter ""([^""]*)"" in the search bar")]
        public void WhenIEnterInTheSearchBar(string searchText)
        {
            driver.FindElement(By.CssSelector(".product_label a")).Click();
            driver.FindElement(By.Id("search-box")).SendKeys(searchText);
        }

        [When(@"I press the Enter key")]
        public void WhenIPressTheEnterKey()
        {
            driver.FindElement(By.Id("search-box")).SendKeys(Keys.Enter);
        }

        [Then(@"I should see the ""([^""]*)"" product in the search results")]
        public void ThenIShouldSeeTheProductInTheSearchResults(string productName)
        {
            // Add assertions to verify that the product is in the search results
            var productResults = driver.FindElements(By.CssSelector(".inventory_item_name"));
            bool productFound = false;

            foreach (var product in productResults)
            {
                if (product.Text.Equals(productName, StringComparison.OrdinalIgnoreCase))
                {
                    productFound = true;
                    break;
                }
            }

            Assert.IsTrue(productFound);
        }
        */
        [When(@"I select the ""([^""]*)"" option from the dropdown")]
        public void WhenISelectTheOptionFromTheDropdown(string p0)
        {
            ProductPageObject productPage = new ProductPageObject(driver);
            productPage.SelectLowtoHighFileter();
           // driver.FindElement(By.XPath("//select[@class='product_sort_container']")).Click();
            // driver.FindElement(By.XPath("//option[@value='lohi']")).Click();

        }

        [Then(@"the products should be displayed in ascending price order")]
        public void ThenTheProductsShouldBeDisplayedInAscendingPriceOrder()
        {
            //var p =driver.FindElement(By.XPath("(//div[@class='inventory_item_description'])[1]")).Text;
            ProductPageObject productPage = new ProductPageObject(driver);
            var p = productPage.GetFirstProductNameAfterFiletrApply();
            Assert.IsTrue(p.Contains("Sauce Labs Onesie"));
        }
    }
}

