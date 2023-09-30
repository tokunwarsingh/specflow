Feature: Login

 Background:
    Given I am on the SauceDemo website homepage

@login
  Scenario: Verify user is able to login sucessfully
    When I enter the username "standard_user"
    And I enter the password "secret_sauce"
    And I click the "Login" button
    Then I should see the Products page
@login
 Scenario: Verifying the locked_out_user login
    When I enter the username "locked_out_user"
    And I enter the password "secret_sauce"
    And I click the "Login" button
    Then I should see an error message
	
