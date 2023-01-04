using Mc2.CrudTest.Domain.Abstractions.Services;

namespace Mc2.CrudTest.Application.Handlers;

public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, CustomersDTO>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IPhoneNumberParser _numberParser;

    public GetCustomersHandler(ICustomerRepository customerRepository, IPhoneNumberParser numberParser)
    {
        _customerRepository = customerRepository;
        _numberParser = numberParser;
    }

    public async Task<CustomersDTO> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var filter = AllPropertiesSpecification.CreateWithParameters(
            request.FirstName,
            request.LastName,
            request.DateOfBirth,
            request.Email,
            request.PhoneNumber,
            request.BankAccountNumber,
            _numberParser
        );

        return new CustomersDTO
        {
            Total = await _customerRepository.GetCount(filter),
            Customers = (await _customerRepository.GetCustomers(filter, request.Page * request.PageSize, request.PageSize)).ToList()
        };
    }
}
