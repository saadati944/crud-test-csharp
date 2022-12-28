namespace Mc2.CrudTest.Application.Handlers;

public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, CustomersDTO>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomersHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomersDTO> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        // TODO: add filter parameters

        var allCustomersSpecification = new AllCustomersSpecification();

        return new CustomersDTO
        {
            Total = await _customerRepository.GetCount(allCustomersSpecification),
            Customers = (await _customerRepository.GetCustomers(allCustomersSpecification, request.Page * request.PageSize, request.PageSize)).ToList()
        };
    }
}
