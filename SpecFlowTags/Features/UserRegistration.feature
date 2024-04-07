@Smoke
Feature: UserRegistration
    As a new user
    I want to register on the website
    So that I can access my account

    @scenario-level-tag-1
    Scenario: User can register with valid details
        Given I am on the registration page
        When I fill in the registration form with valid details
        And I submit the registration form
        Then I should see a confirmation message

  @scenario-level-tag
    Scenario: User can not register without valid details
        Given I am on the registration page
        When I fill in the registration form with valid details
        And I submit the registration form
        Then I should see a confirmation message

      