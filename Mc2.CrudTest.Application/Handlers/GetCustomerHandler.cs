using Mc2.CrudTest.Application.Queries;
using Mc2.CrudTest.Domain.Abstractions;
using Mc2.CrudTest.Domain.CustomerAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Handlers;

public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, Customer>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Task<Customer> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_customerRepository.GetCustomerByID(request.ID));
    }
}
