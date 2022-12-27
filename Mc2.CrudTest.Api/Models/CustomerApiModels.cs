using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Domain.CustomerAggregate;

namespace Mc2.CrudTest.Api.Models;

public sealed record CreateCustomerRequest(string FirstName,
    string LastName,
    DateTime DateOfBirth,
    string PhoneNumber,
    string EmailAddress,
    string BankAccountNumber)
{
    public CreateCustomerCommand MapToCreateCustomerCommand()
    {
        return new CreateCustomerCommand
        {
            Firstname = this.FirstName,
            Lastname = this.LastName,
            DateOfBirth = this.DateOfBirth,
            EmailAddress = this.EmailAddress,
            PhoneNumber = this.PhoneNumber,
            BankAccountNumber = this.BankAccountNumber,
        };
    }
}

public sealed record CreateCustomerResponse(
    Guid ID,
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    string PhoneNumber,
    string EmailAddress,
    string BankAccountNumber)

{
    public static CreateCustomerResponse CreateFromCustomer(Customer customer)
    {
        return new CreateCustomerResponse(
            customer.ID,
            customer.Firstname,
            customer.Lastname,
            customer.DateOfBirth,
            customer.Email.Address,
            customer.PhoneNumber.NumberString,
            customer.BankAccountNumber);
    }
}
