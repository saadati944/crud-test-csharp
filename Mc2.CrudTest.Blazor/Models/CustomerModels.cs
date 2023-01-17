using System;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Blazor.Models;

public class CreateCustomerModel
{
    [Required]
    [MaxLength(150)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(150)]
    public string LastName { get; set; }

    [Required]
    //TODO: add custome validation attribute
    public DateTime DateOfBirth { get; set; }

    [Required]
    [Phone]
    public string PhoneNumber { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [RegularExpression("[A-Z]{2}[0-9]{2}[A-Z0-9]{4}[0-9]{7}([A-Z0-9]?){0,16}", ErrorMessage = "The BankAccountNumber field is not a valid bank account number.")]
    public string BankAccountNumber { get; set; }

    public static CreateCustomerModel Default()
    {
        return new CreateCustomerModel
        {
            FirstName = "",
            LastName = "",
            DateOfBirth = DateTime.Now,
            Email = "",
            PhoneNumber = "",
            BankAccountNumber = ""
        };
    }
}

public class CustomerModel
{
    public string ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }

    public static CustomerModel Default()
    {
        return new CustomerModel
        {
            ID = "",
            FirstName = "",
            LastName = "",
            DateOfBirth = DateTime.Now,
            Email = "",
            PhoneNumber = "",
            BankAccountNumber = ""
        };
    }
}

public class CustomersModel
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public IEnumerable<CustomerModel> Records { get; set; }
}