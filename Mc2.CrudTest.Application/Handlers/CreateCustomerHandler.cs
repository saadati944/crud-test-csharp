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

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Customer>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var emailSpec = new HasEmailSpecification(Email.Create(request.EmailAddress).Address);
        var nameAndDateOfBirthSpec = new HasNameAndDateOfBirthSpecification(request.Firstname, request.Lastname, request.DateOfBirth);

        // Check email uniqueness
        if (_customerRepository.GetCustomers(emailSpec, 0, 1).Any())
            throw new EmailIsNotUniqueException($"There is already a customer with email {request.EmailAddress}");

        // Check (firstname, lastname, dateofbirth) uniqueness
        if (_customerRepository.GetCustomers(nameAndDateOfBirthSpec, 0, 1).Any())
            throw new CustomerNameAndDateOfBirthIsNotUnique($"There is already a customer with the specified first name, last name and date of birth");

        var customer = Customer.Create(request.Firstname, request.Lastname, request.DateOfBirth, request.PhoneNumber, request.EmailAddress, request.BankAccountNumber);

        _customerRepository.InsertCustomer(customer);
        _customerRepository.SaveChanges();

        return Task.FromResult(customer);
    }
}
