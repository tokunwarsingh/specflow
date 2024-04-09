using AutoFixture;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V121.Audits;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject3.PageObject;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject3.StepDefinitions
{
    [Binding]
    public class UserRegistrationStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly RegstrationPageObject registrationPage;

        public UserRegistrationStepDefinitions()
        {
            driver = new ChromeDriver();
            registrationPage = new RegstrationPageObject(driver);
        }

        [Given(@"User is on the registration page")]
        public void GivenUserIsOnTheRegistrationPage()
        {
            registrationPage.NavigateToPage("https://demo.automationtesting.in/Register.html");
        }

        [When(@"User enters valid details")]
        public void WhenUserEntersValidDetails()
        {
            /*
            RegistrationTestData testData = new RegistrationTestData
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@example.com",
                Phone = "1234567890",
                Gender = "Male",
                Address = "123 Main Street",
                CricketHobby = true,
                MoviesHobby = false,
                HockeyHobby = true,
                Language = "English",
                Skill = "Analytics",
                Country = "India",
                DateOfBirth = "10",
                MonthOfBirth = "December",
                YearOfBirth = "1990",
                Password = "Password123",
                ConfirmPassword = "Password123"
            };
           
            RegistrationTestData testData = new Fixture()
                .Create<RegistrationTestData>();
             */
            var testData = TestDataGenerator.GenerateRegistrationTestData();

            // Fill in the registration form with the test data
            registrationPage.FirstNameTextBox.SendKeys(testData.FirstName);
            registrationPage.LastNameTextBox.SendKeys(testData.LastName);
            registrationPage.EmailTextBox.SendKeys(testData.Email);
            registrationPage.PhoneTextBox.SendKeys(testData.Phone);

            // Select gender
            if (testData.Gender == "Male")
                registrationPage.MaleGenderRadioButton.Click();
            else if (testData.Gender == "Female")
                registrationPage.FemaleGenderRadioButton.Click();

            registrationPage.AddressTextArea.SendKeys(testData.Address);

            // Select hobbies
            if (testData.CricketHobby)
                registrationPage.CricketHobbyCheckbox.Click();
            if (testData.MoviesHobby)
                registrationPage.MoviesHobbyCheckbox.Click();
            if (testData.HockeyHobby)
                registrationPage.HockeyHobbyCheckbox.Click();

            // Select language
            registrationPage.LanguageDropdown.Click();
            driver.FindElement(By.XPath($"//a[text()='{testData.Language}']")).Click();
            driver.FindElement(By.XPath("//body")).Click();
            // Select skills
            var skillsDropdown = new SelectElement(registrationPage.SkillsDropdown);
            skillsDropdown.SelectByText(testData.Skill);

            // Select country
            var countryDropdown = new SelectElement(registrationPage.IndiaCountryOption);
            countryDropdown.SelectByText(testData.Country);

            // Select date of birth
            var dateOfBirthDropdown = new SelectElement(registrationPage.DateOfBirthDropdown);
            dateOfBirthDropdown.SelectByText(testData.DateOfBirth);

            // Select month of birth
            var monthOfBirthDropdown = new SelectElement(registrationPage.MonthOfBirthDropdown);
            monthOfBirthDropdown.SelectByText(testData.MonthOfBirth);

            // Select year of birth
            var yearOfBirthDropdown = new SelectElement(registrationPage.YearOfBirthDropdown);
            yearOfBirthDropdown.SelectByText(testData.YearOfBirth);

            registrationPage.PasswordTextBox.SendKeys(testData.Password);
            registrationPage.ConfirmPasswordTextBox.SendKeys(testData.ConfirmPassword);
        }

        [When(@"User clicks on the submit button")]
        public void WhenUserClicksOnTheSubmitButton()
        {
            // Click submit button
            registrationPage.SubmitButton.Click();
        }

        [Then(@"User should be registered successfully")]       
        public void ThenUserShouldBeRegisteredSuccessfully()
        {
            // Example assertion to check if registration success message is displayed
            Assert.IsTrue(IsRegistrationSuccessMessageDisplayed(), "User should be registered successfully");
        }

        // Method to check if registration success message is displayed
        private bool IsRegistrationSuccessMessageDisplayed()
        {
            try
            {
                IWebElement successMessage = driver.FindElement(By.XPath("//div[contains(text(),'Registration Successful')]"));
                return successMessage.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        [When(@"User enters invalid details")]
        public void WhenUserEntersInvalidDetails()
        {
            throw new PendingStepException();
        }

        [Then(@"User should see an error message")]
        public void ThenUserShouldSeeAnErrorMessage()
        {
            throw new PendingStepException();
        }
    }
}
