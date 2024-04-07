using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowLivingDoc.StepDefinitions
{
    [Binding]
    public class WikipediaSearchSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver driver;
        public WikipediaSearchSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
            driver = ScenarioContext.Current.Get<IWebDriver>("WebDriver");
        }

        [Given(@"I am on the Wikipedia homepage")]
        public void GivenIAmOnTheWikipediaHomepage()
        {
            this._scenarioContext["Searchpage"] = "specFlow";
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
        }

        [When(@"I search for ""(.*)"" using the search bar")]
        public void WhenISearchForUsingTheSearchBar(string searchTerm)
        {
            IWebElement searchBar = driver.FindElement(By.Id("searchInput"));
            searchBar.SendKeys(searchTerm);
            searchBar.SendKeys(Keys.Enter);
        }

        [Then(@"I should see search results related to ""(.*)""")]
        public void ThenIShouldSeeSearchResultsRelatedTo(string expectedSearchTerm)
        {
            // Verify search results contain expected search term
            string searchResultsText = driver.FindElement(By.Id("mw-content-subtitle")).Text;

            Assert.IsTrue(searchResultsText.Contains(expectedSearchTerm));
        }

        [Given(@"I have searched for ""(.*)"" on Wikipedia")]
        public void GivenIHaveSearchedForOnWikipedia(string searchTerm)
        {
            GivenIAmOnTheWikipediaHomepage();
            WhenISearchForUsingTheSearchBar(searchTerm);
        }

        [When(@"I click on the first search result")]
        public void WhenIClickOnTheFirstSearchResult()
        {
            // Click on the first search result link
            driver.FindElement(By.CssSelector(".mw-redirect")).Click();
        }

        [Then(@"I should be navigated to the ""(.*)"" page")]
        public void ThenIShouldBeNavigatedToThePage(string expectedPageTitle)
        {
            // Verify current page title matches expected page title
            string actualPageTitle = driver.Title;
            Assert.True(actualPageTitle.Contains(expectedPageTitle));
        }

        [Given(@"I am on the ""(.*)"" page on Wikipedia")]
        public void GivenIAmOnThePageOnWikipedia(string pageTitle)
        {
            GivenIAmOnTheWikipediaHomepage();
            WhenISearchForUsingTheSearchBar(pageTitle);
            WhenIClickOnTheFirstSearchResult();
        }

        [Then(@"I should see the heading ""(.*)"" on the page")]
        public void ThenIShouldSeeTheHeadingOnThePage(string expectedHeading)
        {
            // Verify page contains expected heading
            string actualHeading = driver.FindElement(By.CssSelector("h1#firstHeading")).Text;
            Assert.AreEqual(expectedHeading, actualHeading);
        }

        [Then(@"I should see a section containing information about SpecFlow")]
        public void ThenIShouldSeeASectionContainingInformationAboutSpecFlow()
        {
            // Verify page contains section with information about SpecFlow
            Assert.IsTrue(driver.PageSource.Contains("SpecFlow"));
        }
    }
}
