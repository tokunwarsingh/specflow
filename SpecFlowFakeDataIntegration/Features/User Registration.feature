Feature: User Registration
  As a user
  I want to register on the website
  So that I can access its features

  Scenario: Register with valid details
    Given User is on the registration page
    When User enters valid details
    And User clicks on the submit button
    Then User should be registered successfully

  Scenario: Register with invalid details
    Given User is on the registration page
    When User enters invalid details
    And User clicks on the submit button
    Then User should see an error message