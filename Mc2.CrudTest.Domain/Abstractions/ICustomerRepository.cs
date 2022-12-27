using Mc2.CrudTest.Domain.CustomerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Abstractions;

public interface ICustomerRepository
{
    // TODO: get customers (and get count) by specification
    IEnumerable<Customer> GetCustomers();
    int GetCount();

    Customer GetCustomerByID(Guid id);
    void InsertCustomer(Customer customer);
    void DeleteCustomer(Customer customer);
    void UpdateCustomer(Customer customer);
    void SaveChanges();
}
