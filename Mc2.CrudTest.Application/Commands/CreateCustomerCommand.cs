namespace Mc2.CrudTest.Application.Commands;

public sealed class CreateCustomerCommand : IRequest<Customer>
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public string BankAccountNumber { get; set; }
}
