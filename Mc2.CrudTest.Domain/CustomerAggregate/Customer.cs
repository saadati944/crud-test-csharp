namespace Mc2.CrudTest.Domain.CustomerAggregate;

public class Customer
{
    // There may be an entity in the infrastructure layer which stores the actual data in the database
    // but for simplicity I just use my domain model as an entity.
    public Guid ID { get; set; }

    private string _firstname;
    public string Firstname
    {
        get
        {
            return _firstname;
        }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 150)
                throw new InvalidFirstNameException("Invalid first name");

            _firstname = value;
        }
    }

    private string _lastname;
    public string Lastname
    {
        get
        {
            return _lastname;
        }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 150)
                throw new InvalidLastNameException("Invalid last name");

            _lastname = value;
        }
    }

    private DateTime _dateOfBirth;
    public DateTime DateOfBirth
    {
        get
        {
            return _dateOfBirth;
        }
        set
        {
            // To test this kind of stuff you shouldn't use DateTime.Now. instead you can create
            // something like IDateTimeProvider and get Now from that service
            if (value > DateTime.Now)
                throw new InvalidDateOfBirthException("The date of birth can not be in the future");
            
            _dateOfBirth = value;
        }
    }

    public PhoneNumber PhoneNumber { get; private set; }
    public Email Email { get; private set; }

    private string _bankAccountNumber;
    // It is possible to use a value object for this property too
    public string BankAccountNumber
    {
        get
        {
            return _bankAccountNumber;
        }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 30)
                throw new InvalidBankAccountNumberException("Invalid bank account number");

            _bankAccountNumber = value;
        }
    }


    private Customer()
    {
    }

    private Customer(Guid iD, string firstname, string lastname, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, string bankAccountNumber)
    {
        ID = iD;
        Firstname = firstname;
        Lastname = lastname;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
    }

    public static Customer Create(string firstname, string lastname, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
    {
        var id = Guid.NewGuid();
        var phone = PhoneNumber.Create(phoneNumber);
        var mail = Email.Create(email);

        return new Customer(id, firstname, lastname, dateOfBirth, phone, mail, bankAccountNumber);
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        PhoneNumber = PhoneNumber.Create(phoneNumber);
    }

    public void SetEmail(string email)
    {
        Email = Email.Create(email);
    }
}
