using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Exceptions;
using Mc2.CrudTest.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Handlers;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _customerRepository.GetCustomerByID(request.ID);
        
        if (customer is null)
            throw new CustomerNotFoundException();

        _customerRepository.DeleteCustomer(customer);

        return Task.FromResult(Unit.Value);
    }
}
