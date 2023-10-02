Feature: Product

 Background:
    Given I am logged into the website as "standard_user"
    And I am at product page

 #  @product
 # Scenario: Searching for products   
 #   When I enter "Sauce Labs Onesie" in the search bar
 #    And I press the Enter key
 #   Then I should see the "Sauce Labs Onesie" product in the search results

    @product
  Scenario: Sorting products    
    When I select the "Price (low to high)" option from the dropdown
    Then the products should be displayed in ascending price order
