using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.CustomerAggregate
{
    public class Customer
    {
        // There may be an entity in the infrastructure layer which stores the actual data in the database
        // but for simplicity I just use my domain model as an entity.
        public Guid ID { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }

        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                // To test this kind of stuff This shouldn't use DateTime.Now. instead you can create
                // something like IDateTimeProvider and get Now from that service
                if (value > DateTime.Now)
                    throw new InvalidDateOfBirthException("The date of birth can not be in the future");
                
                _dateOfBirth = value;
            }
        }

        public PhoneNumber PhoneNumber { get; private set; }
        public Email Email { get; private set; }

        // It is possible to use a value object for this property too
        public string BankAccountNumber { get; set; }


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
            if (string.IsNullOrEmpty(firstname) || firstname.Length > 150)
                throw new InvalidFirstNameException("Invalid first name");

            if (string.IsNullOrEmpty(lastname) || lastname.Length > 150)
                throw new InvalidLastNameException("Invalid last name");

            if (string.IsNullOrEmpty(bankAccountNumber) || bankAccountNumber.Length > 30)
                throw new InvalidBankAccountNumberException("Invalid bank account number");

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
}
