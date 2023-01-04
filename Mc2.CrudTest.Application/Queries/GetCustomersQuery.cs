using Mc2.CrudTest.Domain.Abstractions.Services;

namespace Mc2.CrudTest.Application.Queries;

public class GetCustomersQuery : IRequest<CustomersDTO>
{
    public int Page { get; init; } = 0;
    public int PageSize { get; init; } = 10;

    public string FirstName { get; init; }
    public string LastName { get; init; }
    public DateTime? DateOfBirth { get; init; }
    public string PhoneNumber { get; init; }
    public string Email { get; init; }
    public string BankAccountNumber { get; init; }

    private GetCustomersQuery()
    {
    }

    public static GetCustomersQuery CreateWithParameters(int page, int pageSize, string firstName, string lastName, DateTime? dateOfBirth, string email, string phoneNumber, string bankAccountNumber)
    {
        return new GetCustomersQuery()
        {
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = dateOfBirth,
            Email = email,
            PhoneNumber = phoneNumber,
            BankAccountNumber = bankAccountNumber
        };
    }
}
