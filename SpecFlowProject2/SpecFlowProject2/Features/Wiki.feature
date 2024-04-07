Feature: Wiki Page Reading
    As a user
    I want to be able to read wiki pages
    So that I can access information

Scenario: Reading a Wiki Page
    Given I am on the wiki page for "SpecFlow"
    Then I should see the content of the page
