using Mc2.CrudTest.Domain.Abstractions.Services;

namespace Mc2.CrudTest.Application.Handlers;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Unit>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IPhoneNumberParser _numberParser;

    public UpdateCustomerHandler(ICustomerRepository customerRepository, IPhoneNumberParser numberParser)
    {
        _customerRepository = customerRepository;
        _numberParser = numberParser;
    }

    public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetCustomerByID(request.ID);

        if (customer is null)
            throw new CustomerNotFoundException();

        var emailSpec = new HasEmailSpecification(Email.Create(request.EmailAddress).Address);
        var nameAndDateOfBirthSpec = new HasNameAndDateOfBirthSpecification(request.Firstname, request.Lastname, request.DateOfBirth);
        
        // Check email uniqueness
        if (!customer.Email.Equals(Email.Create(request.EmailAddress))
                && (await _customerRepository.GetCustomers(emailSpec, 0, 1)).Any())
            throw new EmailIsNotUniqueException();

        // Check (firstname, lastname, dateofbirth) uniqueness
        if ((await _customerRepository.GetCustomers(nameAndDateOfBirthSpec, 0, 1)).Any())
            throw new CustomerNameAndDateOfBirthIsNotUnique();

        customer.Firstname = request.Firstname;
        customer.Lastname = request.Lastname;
        customer.DateOfBirth = request.DateOfBirth;
        customer.SetPhoneNumber(request.PhoneNumber, _numberParser);
        customer.SetEmail(request.EmailAddress);
        customer.BankAccountNumber = request.BankAccountNumber;

        _customerRepository.UpdateCustomer(customer);
        await _customerRepository.SaveChanges();

        return Unit.Value;
    }
}
