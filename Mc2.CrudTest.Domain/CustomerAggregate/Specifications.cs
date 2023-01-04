﻿namespace Mc2.CrudTest.Domain.CustomerAggregate;

// This type of implementation is not common but it works for me
public class AllCustomersSpecification : ISpecification<Customer>
{
    public IQueryable<Customer> Apply(IQueryable<Customer> query)
    {
        return query.OrderBy(c => c.Lastname).ThenBy(c => c.Firstname).ThenBy(c => c.Email.Address);
    }
}

public class HasEmailSpecification : ISpecification<Customer>
{
    private string _email;

    public HasEmailSpecification(string email)
    {
        _email = email;
    }

    public IQueryable<Customer> Apply(IQueryable<Customer> query)
    {
        return query.Where(c => c.Email.Address == _email);
    }
}

public class HasNameAndDateOfBirthSpecification : ISpecification<Customer>
{
    private string _firstname;
    private string _lastname;
    private DateTime _dateOfBirth;

    public HasNameAndDateOfBirthSpecification(string firstname, string lastname, DateTime dateOfBirth)
    {
        _firstname = firstname;
        _lastname = lastname;
        _dateOfBirth = dateOfBirth;
    }

    public IQueryable<Customer> Apply(IQueryable<Customer> query)
    {
        return query.Where(c => c.Firstname == _firstname && c.Lastname == _lastname && c.DateOfBirth == _dateOfBirth);
    }
}

public class AllPropertiesSpecification : ISpecification<Customer>
{
    public bool IsInputValid { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public DateTime? DateOfBirth { get; init; }
    public PhoneNumber PhoneNumber { get; init; }
    public Email Email { get; init; }
    public string BankAccountNumber { get; init; }

    private AllPropertiesSpecification()
    {
    }

    public static AllPropertiesSpecification CreateWithParameters(string firstName, string lastName, DateTime? dateOfBirth, string email, string phoneNumber, string bankAccountNumber, IPhoneNumberParser numberParser)
    {
        bool isDataValid = true;

        firstName = firstName?.ToLower();
        lastName = lastName?.ToLower();

        Email e = null;
        PhoneNumber p = null;

        if(bankAccountNumber is not null)
        {
            bankAccountNumber = bankAccountNumber.ToUpper();
            if (!string.IsNullOrEmpty(bankAccountNumber) && !Customer.IsBankAccountNumberValid().IsMatch(bankAccountNumber))
                isDataValid = false;
        }

        if(email is not null)
            try
            {
                e = Email.Create(email);
            }
            catch (InvalidEmailException)
            {
                isDataValid = false;
            }

        if(phoneNumber is not null)
            try
            {
                p = PhoneNumber.Create(phoneNumber, numberParser);
            }
            catch (InvalidPhoneNumberException)
            {
                isDataValid = false;
            }

        return new AllPropertiesSpecification()
        {
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = dateOfBirth,
            Email = e,
            PhoneNumber = p,
            BankAccountNumber = bankAccountNumber,
            IsInputValid = isDataValid
        };
    }

    public IQueryable<Customer> Apply(IQueryable<Customer> query)
    {
        if (!IsInputValid)
            return query.Where(q => false);

        return query.Where(q =>
            (string.IsNullOrWhiteSpace(FirstName) || q.Firstname == FirstName)
            && (string.IsNullOrWhiteSpace(LastName) || q.Lastname == LastName)
            && (Email == null || q.Email.Address == Email.Address)
            && (PhoneNumber == null || q.PhoneNumber.Number == PhoneNumber.Number)
            && (string.IsNullOrWhiteSpace(BankAccountNumber) || q.BankAccountNumber == BankAccountNumber)
        ).OrderBy(c => c.Lastname).ThenBy(c => c.Firstname).ThenBy(c => c.Email.Address);
    }
}