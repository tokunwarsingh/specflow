Feature: Wikipedia Search
  As a user
  I want to be able to search for topics on Wikipedia
  So that I can find relevant information

  Scenario: Searching for a Topic  
    Given I am on the Wikipedia homepage
    When I search for "SpecFlow" using the search bar
    Then I should see search results related to "SpecFlow"

  Scenario: Navigating to a Page
    Given I have searched for "SpecFlow" on Wikipedia
    When I click on the first search result
    Then I should be navigated to the "SpecFlow" page

  Scenario: Verifying Content
    Given I am on the "SpecFlow" page on Wikipedia
    Then I should see the heading "SpecFlow" on the page
    And I should see a section containing information about SpecFlow

