using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECart.AccpetanceTests.PageObject
{
    public class LoginPageObject
    {
        IWebDriver driver;

        public LoginPageObject(IWebDriver driver)
        {
           this.driver = driver;
        }

        IWebElement useridfield => driver.FindElement(By.Id("user-name"));

        IWebElement passwordInput => driver.FindElement(By.Id("password"));

        IWebElement loginbutton => driver.FindElement(By.XPath("//input[@value='Login']"));

        IWebElement errorDiv => driver.FindElement(By.CssSelector(".error-message-container"));


        public void EnterUserId(string userid)
        {         
            useridfield.SendKeys(userid);
        }
        public void EnterUserPaqssord(string password)
        {
            passwordInput.SendKeys(password);

        }

        public void ClickOnLoginButton()
        { 
         loginbutton.Click();        
        }

        public bool IsErrorMessageDisplay()
        {
            return errorDiv.Enabled;
        }


    }
}
