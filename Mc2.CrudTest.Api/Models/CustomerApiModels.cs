namespace Mc2.CrudTest.Api.Models;

public sealed record CreateCustomerRequest(
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    string PhoneNumber,
    string Email,
    string BankAccountNumber)
{
    public CreateCustomerCommand MapToCreateCustomerCommand()
    {
        return new CreateCustomerCommand
        {
            Firstname = this.FirstName,
            Lastname = this.LastName,
            DateOfBirth = this.DateOfBirth,
            EmailAddress = this.Email,
            PhoneNumber = this.PhoneNumber,
            BankAccountNumber = this.BankAccountNumber,
        };
    }
}

public sealed record CustomerResponse(
    Guid ID,
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    string PhoneNumber,
    string Email,
    string BankAccountNumber)
{
    public static CustomerResponse Create(Customer customer)
    {
        return new CustomerResponse(
            customer.ID,
            customer.Firstname,
            customer.Lastname,
            customer.DateOfBirth,
            customer.PhoneNumber.NumberAsString,
            customer.Email.Address,
            customer.BankAccountNumber);
    }
}

// This model can inherit from a generic base PaginatedModel but I have only one model
// so creating a base model is not neccessary
public sealed record CustomersResponse(
      int Page,
      int PageSize,
      int TotalCount,
      IEnumerable<CustomerResponse> Records)
{
    public static CustomersResponse Create(int page, int pageSize, CustomersDTO customers)
    {
        return new CustomersResponse(
            page,
            pageSize,
            customers.Total,
            customers.Customers.Select(CustomerResponse.Create)
        );
    }
}

public sealed record UpdateCustomerRequest(
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    string PhoneNumber,
    string Email,
    string BankAccountNumber)
{
    public UpdateCustomerCommand MapToUpdateCustomerCommand()
    {
        return new UpdateCustomerCommand
        {
            Firstname = this.FirstName,
            Lastname = this.LastName,
            DateOfBirth = this.DateOfBirth,
            EmailAddress = this.Email,
            PhoneNumber = this.PhoneNumber,
            BankAccountNumber = this.BankAccountNumber,
        };
    }
}

//public sealed record FilterCustomerRequest(
//    string FirstName,
//    string LastName,
//    DateTime DateOfBirth,
//    string PhoneNumber,
//    string Email,
//    string BankAccountNumber);