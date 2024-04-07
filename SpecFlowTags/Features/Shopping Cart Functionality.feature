Feature: Shopping Cart Functionality
    As a shopper
    I want to add items to my shopping cart
    So that I can proceed to checkout

    Scenario: User can add items to the cart
        Given I am on the product page
        When I click on the "Add to Cart" button for a product
        Then the item should be added to my cart