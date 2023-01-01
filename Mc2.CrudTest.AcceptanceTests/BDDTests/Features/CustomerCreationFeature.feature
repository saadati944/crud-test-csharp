Feature: CustomerCreationFeature
    The custoemr endpoint should create and persist a new customer


Scenario: By using valid information customers should be created successfully 
    Given Following customer informations
    | firstName | lastName | dateOfBirth | phoneNumber | email            | bankAccountNumbe    |
    | Ali       | saadati  | 2000/01/02  | +10334252345 | sdt@mail.com     | 1234-5342-2344-5234 |
    | John      | martin   | 1997/01/02  | +32025234325 | email2@email.com | 6435-1942-9182-9128 |
    When Calling CreateCustomer endpoint
    Then New customers should be created

Scenario: Customers emails should be unique
    Given Following customer informations
    | firstName | lastName | dateOfBirth | phoneNumber | email          | bankAccountNumbe    |
    | Ali       | saadati  | 2000/01/02  | +10334252345 | same@email.com | 1234-5342-2344-5234 |
    | John      | martin   | 1997/01/02  | +32025234325 | same@email.com | 6435-1942-9182-9128 |
    When Calling CreateCustomer endpoint
    Then Only first customer should be created

Scenario: Combination of first name and last name and date of birth should be unique for each customer
    Given Following customer informations
    | firstName | lastName | dateOfBirth | phoneNumber | email            | bankAccountNumbe    |
    | John      | martin   | 1997/01/02  | +10334252345 | email1@email.com | 1234-5342-2344-5234 |
    | John      | martin   | 1997/01/02  | +32025234325 | email2@email.com | 6435-1942-9182-9128 |
    When Calling CreateCustomer endpoint
    Then Only first customer should be created

Scenario: Customers should only be created with valid email addresses
    Given Following customer informations
    | firstName | lastName | dateOfBirth | phoneNumber | email            | bankAccountNumbe    |
    | name1     | lname1   | 1997/01/02  | +69203049235 | valid@email.com  | 1234-5342-2344-5234 |
    | name2     | lname2   | 1998/01/02  | +2342805394 |                  | 6435-1942-9182-9128 |
    | name3     | lname3   | 1999/01/02  | +6734572465 | email2$email.com | 6435-1942-9182-9128 |
    | name4     | lname4   | 2000/01/02  | +6356235235 | invalidEmail.com | 6435-1942-9182-9128 |
    When Calling CreateCustomer endpoint
    Then Only first customer should be created

Scenario: Delete customer endpoint should delete customer from database
    Given Following customer informations
    | firstName | lastName | dateOfBirth | phoneNumber | email            | bankAccountNumbe    |
    | John      | martin   | 1997/01/02  | +10334252345 | email1@email.com | 1234-5342-2344-5234 |
    When Calling CreateCustomer endpoint
    And Calling DeleteCustomer endpoint
    Then There should not be any customers in the database
# Other behavioural tests can be added here ...