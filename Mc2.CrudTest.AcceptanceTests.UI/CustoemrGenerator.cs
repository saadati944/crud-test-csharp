using Bunit;
using Mc2.CrudTest.Blazor.Components;
using Mc2.CrudTest.Blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mc2.CrudTest.AcceptanceTests.UI;

public static class CustomerGenerator
{
    public static CustomersModel GenerateCustomersResponse(int page, int pageSize, int total)
    {
        var customers = GenerateCustomers(total).Skip(page*pageSize).Take(pageSize);
        return new CustomersModel
        {
            Page = page,
            PageSize = pageSize,
            TotalCount = total,
            Records = customers
        };
    }

    private static List<CustomerModel> GenerateCustomers(int count)
    {
        var customers = new List<CustomerModel>();

        for(int i=0; i<count; i++)
        {
            customers.Add(new CustomerModel()
            {
                FirstName = $"FirstName_{i}",
                LastName = $"LastName_{i}",
                DateOfBirth = DateTime.Now.AddDays(-100 * i),
                Email = $"email_{i}@mail.com",
                PhoneNumber = $"+{989123423454 + i}",
                BankAccountNumber = $"IR{23567543243532425 + i}"
            });
        }

        return customers;
    }
}
