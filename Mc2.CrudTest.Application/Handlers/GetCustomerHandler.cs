namespace Mc2.CrudTest.Application.Handlers;

public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, Customer>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        return await _customerRepository.GetCustomerByID(request.ID);
    }
}
