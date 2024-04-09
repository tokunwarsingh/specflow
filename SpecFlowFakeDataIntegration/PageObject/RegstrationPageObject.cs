using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowFakeDataIntegration.PageObject
{
    public class RegstrationPageObject
    {
        private readonly IWebDriver driver;

        public RegstrationPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FirstNameTextBox => driver.FindElement(By.XPath("//input[@ng-model='FirstName']"));
        public IWebElement LastNameTextBox => driver.FindElement(By.XPath("//input[@ng-model='LastName']"));
        public IWebElement EmailTextBox => driver.FindElement(By.XPath("//input[@ng-model='EmailAdress']"));
        public IWebElement PhoneTextBox => driver.FindElement(By.XPath("//input[@ng-model='Phone']"));
        public IWebElement MaleGenderRadioButton => driver.FindElement(By.XPath("//input[@value='Male']"));
        public IWebElement FemaleGenderRadioButton => driver.FindElement(By.XPath("//input[@value='FeMale']"));
        public IWebElement AddressTextArea => driver.FindElement(By.XPath("//textarea[@ng-model='Adress']"));
        public IWebElement CricketHobbyCheckbox => driver.FindElement(By.XPath("//input[@id='checkbox1']"));
        public IWebElement MoviesHobbyCheckbox => driver.FindElement(By.XPath("//input[@id='checkbox2']"));
        public IWebElement HockeyHobbyCheckbox => driver.FindElement(By.XPath("//input[@id='checkbox3']"));
        public IWebElement LanguageDropdown => driver.FindElement(By.XPath("//div[@id='msdd']"));
        public IWebElement SkillsDropdown => driver.FindElement(By.XPath("//select[@ng-model='Skill']"));
        public IWebElement CountryDropdown => driver.FindElement(By.XPath("//select[@ng-model='countries']"));
        public IWebElement IndiaCountryOption => driver.FindElement(By.Id("country"));
        public IWebElement YearOfBirthDropdown => driver.FindElement(By.XPath("//select[@id='yearbox']"));
        public IWebElement MonthOfBirthDropdown => driver.FindElement(By.XPath("//select[@ng-model='monthbox']"));
        public IWebElement DateOfBirthDropdown => driver.FindElement(By.XPath("//select[@ng-model='daybox']"));
        public IWebElement PasswordTextBox => driver.FindElement(By.XPath("//input[@id='firstpassword']"));
        public IWebElement ConfirmPasswordTextBox => driver.FindElement(By.XPath("//input[@id='secondpassword']"));
        public IWebElement SubmitButton => driver.FindElement(By.XPath("//button[@id='submitbtn']"));

        public void NavigateToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
