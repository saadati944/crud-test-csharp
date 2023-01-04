using Mc2.CrudTest.Domain.Abstractions.Services;

namespace Mc2.CrudTest.Application.Handlers;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Customer>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IPhoneNumberParser _numberParser;

    public CreateCustomerHandler(ICustomerRepository customerRepository, IPhoneNumberParser numberParser)
    {
        _customerRepository = customerRepository;
        _numberParser = numberParser;
    }

    public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var emailSpec = new HasEmailSpecification(Email.Create(request.EmailAddress).Address);
        var nameAndDateOfBirthSpec = new HasNameAndDateOfBirthSpecification(request.Firstname, request.Lastname, request.DateOfBirth);

        // Check email uniqueness
        if ((await _customerRepository.GetCustomers(emailSpec, 0, 1)).Any())
            throw new EmailIsNotUniqueException();

        // Check (firstname, lastname, dateofbirth) uniqueness
        if ((await _customerRepository.GetCustomers(nameAndDateOfBirthSpec, 0, 1)).Any())
            throw new CustomerNameAndDateOfBirthIsNotUnique();

        var customer = Customer.Create(request.Firstname, request.Lastname, request.DateOfBirth, request.PhoneNumber, request.EmailAddress, request.BankAccountNumber, _numberParser);

        _customerRepository.InsertCustomer(customer);
        await _customerRepository.SaveChanges();

        return customer;
    }
}
