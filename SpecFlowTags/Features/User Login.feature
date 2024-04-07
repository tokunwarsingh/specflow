 @Smoke
Feature: User Login
    As a registered user
    I want to log in to my account
    So that I can access my personalized content
        @scenario-level-tag
    Scenario: User can log in with valid credentials
        Given I am on the login page
        When I enter valid username and password
        And I click the login button
        Then I should be redirected to the dashboard