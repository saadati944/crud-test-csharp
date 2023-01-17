Feature: Create Read Edit Delete Customer

    Background:
        Given system error codes are following
          | Code | Description                                                |
          | 101  | Invalid Mobile Number                                      |
          | 102  | Invalid Email address                                      |
          | 103  | Invalid Bank Account Number                                |
          | 201  | Duplicate customer by First-name, Last-name, Date-of-Birth |
          | 202  | Duplicate customer by Email address                        |

@ignore
    Scenario: Create Read Edit Delete Customer in blazor ui
        Given Browser at customers page
        When user fills CreateCustomer form by following data and clicks Create button
          | FirstName | LastName | Email        | PhoneNumber   | DateOfBirth | BankAccountNumber |
          | John      | Doe      | john@doe.com | +989121234567 | 01-JAN-2000 | IR000000000000001 |
        Then user can look at customers list and find "1" records by below properties
          | FirstName | LastName | Email        | PhoneNumber   | DateOfBirth | BankAccountNumber |
          | John      | Doe      | john@doe.com | +989121234567 | 01-JAN-2000 | IR000000000000001 |
        When user fills CreateCustomer form by following data and clicks Create button
          | FirstName | LastName | Email        | PhoneNumber   | DateOfBirth | BankAccountNumber |
          | John      | Doe      | other@doe.com | +989121234567 | 01-JAN-2000 | IR000000000000001 |
        Then user must get error message of code "201"
        When user clicks edit button on customers list for customer by email of "john@doe.com"
        And user fills UpdateCustomer form by following data and clicks Update button
          | FirstName | LastName | Email            | PhoneNumber | DateOfBirth | BankAccountNumber |
          | Jane      | William  | jane@william.com | +3161234567 | 01-FEB-2010 | IR000000000000002 |
        Then user can look at customers list and find "0" records by below properties
          | FirstName | LastName | Email        | PhoneNumber   | DateOfBirth | BankAccountNumber |
          | John      | Doe      | john@doe.com | +989121234567 | 01-JAN-2000 | IR000000000000001 |
        And user can look at customers list and find "1" records by below properties
          | FirstName | LastName | Email            | PhoneNumber | DateOfBirth | BankAccountNumber |
          | Jane      | William  | jane@william.com | +3161234567 | 01-FEB-2010 | IR000000000000002 |
        When user clicks delete button on customers list for customer by email of "jane@william.com"
        Then user can get all records and get "0" records