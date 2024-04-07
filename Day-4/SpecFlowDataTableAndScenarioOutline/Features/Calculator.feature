Feature: Calculator


@calculatortest
Scenario: Addition of two numbers using data table
    Given I have entered the following numbers into the calculator:
        | Number1 | Number2 |
        | 50      | 70      |
    When I press the add button
    Then the result should be 121
    
@cenarioutlinetets
Scenario Outline: Addition of two numbers
    Given I have entered "<Number1>" into the calculator
    And I have entered "<Number2>" into the calculator
    When I press the add button
    Then the result should be "<Result>"

    Examples:
        | Number1 | Number2 | Result |
        | 5       | 7       | 12     |
        | 10      | 15      | 25     |
        | 3       | 3       | 6      |
        | 4       | 5       | 9      |