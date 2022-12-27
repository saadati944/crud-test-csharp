using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Exceptions;
using Mc2.CrudTest.Domain.Abstractions;
using Mc2.CrudTest.Domain.CustomerAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Handlers;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Unit>
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _customerRepository.GetCustomerByID(request.ID);
        
        if (customer is null)
            throw new CustomerNotFoundException();

        customer.Firstname = request.Firstname;
        customer.Lastname = request.Lastname;
        customer.DateOfBirth = request.DateOfBirth;
        customer.SetPhoneNumber(request.PhoneNumber);
        customer.SetEmail(request.EmailAddress);
        customer.BankAccountNumber = request.BankAccountNumber;

        _customerRepository.UpdateCustomer(customer);

        return Task.FromResult(Unit.Value);
    }
}
