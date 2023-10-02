using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECart.AccpetanceTests.PageObject
{
    public  class CartPageObject
    {

        private IWebDriver driver;
        private WebDriverWait wait;

        public CartPageObject(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Page Elements
        private IReadOnlyCollection<IWebElement> ProductItems => driver.FindElements(By.CssSelector(".inventory_item"));
        private IWebElement ShoppingCartButton => driver.FindElement(By.CssSelector(".shopping_cart_badge"));

        private IWebElement fistname => driver.FindElement(By.XPath("//input[@id='first-name']"));
        private IWebElement lastname => driver.FindElement(By.XPath("//input[@id='last-name']"));
        private IWebElement postalCode => driver.FindElement(By.XPath("//input[@id='postal-code']"));

        public IWebElement finishButton => driver.FindElement(By.Id("finish"));
        public IWebElement confirmationMessage => driver.FindElement(By.XPath("//h2[normalize-space()='Thank you for your order!']"));
        public IWebElement continueButton => driver.FindElement(By.XPath("//input[@value='Continue']"));

        public IWebElement FinishButton => driver.FindElement(By.XPath($"//button[text()='Finish']"));

        public IWebElement CheckOutButton => driver.FindElement(By.Id("checkout"));


        // Page Methods
        public void AddProductToCart(string productName)
        {
            foreach (var productItem in ProductItems)
            {
                var productNameElement = productItem.FindElement(By.CssSelector(".inventory_item_name"));
                if (productNameElement.Text.Equals(productName))
                {
                    var addToCartButton = productItem.FindElement(By.CssSelector(".btn_inventory"));
                    addToCartButton.Click();
                    return;
                }
            }
        }

        public void AddPersobalInfo()
        {
            fistname.SendKeys("first name");
            lastname.SendKeys("last name");
            postalCode.SendKeys("1234");
        }

        public void ContinuteButtonClick()
        { 
            continueButton.Click();
        
        }

        internal void CheckoutButtonClick()
        {
            CheckOutButton.Click();
        }

        internal void FinishButtonClick()
        {
            finishButton.Click();
        }
    }
}
