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

        var emailSpec = new HasEmailSpecification(Email.Create(request.EmailAddress).Address);
        var nameAndDateOfBirthSpec = new HasNameAndDateOfBirthSpecification(request.Firstname, request.Lastname, request.DateOfBirth);
        
        // Check email uniqueness
        if (!customer.Email.Equals(Email.Create(request.EmailAddress))
                && _customerRepository.GetCustomers(emailSpec, 0, 1).Any())
            throw new EmailIsNotUniqueException($"There is already a customer with email {request.EmailAddress}");

        // Check (firstname, lastname, dateofbirth) uniqueness
        if (!customer.PhoneNumber.Equals(PhoneNumber.Create(request.PhoneNumber))
                && _customerRepository.GetCustomers(nameAndDateOfBirthSpec, 0, 1).Any())
            throw new CustomerNameAndDateOfBirthIsNotUnique($"There is already a customer with the specified first name, last name and date of birth");

        customer.Firstname = request.Firstname;
        customer.Lastname = request.Lastname;
        customer.DateOfBirth = request.DateOfBirth;
        customer.SetPhoneNumber(request.PhoneNumber);
        customer.SetEmail(request.EmailAddress);
        customer.BankAccountNumber = request.BankAccountNumber;

        _customerRepository.UpdateCustomer(customer);
        _customerRepository.SaveChanges();

        return Task.FromResult(Unit.Value);
    }
}
