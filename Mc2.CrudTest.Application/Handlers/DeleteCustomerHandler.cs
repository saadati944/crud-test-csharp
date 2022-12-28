namespace Mc2.CrudTest.Application.Handlers;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetCustomerByID(request.ID);
        
        if (customer is null)
            throw new CustomerNotFoundException();

        _customerRepository.DeleteCustomer(customer);
        await _customerRepository.SaveChanges();

        return Unit.Value;
    }
}
