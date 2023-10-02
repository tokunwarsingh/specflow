using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECart.AccpetanceTests.PageObject
{
    public class ProductPageObject
    {
        IWebDriver driver;

        public ProductPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement filetrButton => driver.FindElement(By.XPath("//select[@class='product_sort_container']"));
        private IWebElement filetrCriteriaLowToHigh => driver.FindElement(By.XPath("//option[@value='lohi']"));

        private IWebElement firstProductAfterSort => driver.FindElement(By.XPath("(//div[@class='inventory_item_description'])[1]"));


        public void SelectLowtoHighFileter()
        { 
            filetrButton.Click();
            filetrCriteriaLowToHigh.Click();
        
        }

        public string GetFirstProductNameAfterFiletrApply()
        {
            return firstProductAfterSort.Text;

        }

    }
}
