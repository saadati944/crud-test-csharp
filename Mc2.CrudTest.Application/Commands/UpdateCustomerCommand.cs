namespace Mc2.CrudTest.Application.Commands;

public class UpdateCustomerCommand : IRequest<Unit>
{
    public Guid ID { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public string BankAccountNumber { get; set; }
}
