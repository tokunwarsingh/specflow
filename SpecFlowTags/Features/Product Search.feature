 @Smoke
 Feature: Product Search
    As a shopper
    I want to search for products
    So that I can find what I'm looking for quickly

    Scenario: User can search for a product by name
        Given I am on the homepage
        When I enter the name of a product in the search bar
        And I click on the search button
        Then I should see a list of matching products
