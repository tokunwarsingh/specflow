Feature: Cart


 Background:
   Given I am logged into the website as "standard_user"

    @cart
  Scenario: Adding items to the cart   
    When I add the "Sauce Labs Backpack" to the cart
    And I add the "Sauce Labs Bike Light" to the cart
    Then I should see 2 items in the shopping cart

@cart
  Scenario: Checking out from the cart
    Given I have added items to the cart
    When I click on the shopping cart icon
    And I click on the "Checkout" button
    And I enter my personal information
    And I click on the "Continue" button
    And I verify the order summary
    And I click on the "Finish" button
    Then I should see the order confirmation page
