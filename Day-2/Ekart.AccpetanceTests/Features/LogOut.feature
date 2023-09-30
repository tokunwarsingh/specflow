Feature: LogOut

A short summary of the feature

@logout
Scenario: Logging out of the website
    Given I am logged into the website as "standard_user"
    When I click on the menu
    And I click the "Logout" option
    Then I should see the login page
