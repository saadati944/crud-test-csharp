using Mc2.CrudTest.Domain.Abstractions;
using Mc2.CrudTest.Domain.CustomerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.Data;

public class CustomerRepository : ICustomerRepository
{
    private readonly CrudTestsContext _context;

    public CustomerRepository(CrudTestsContext context)
    {
        _context = context;
    }

    public void DeleteCustomer(Customer c)
    {
        _context.Remove(c);
    }

    public Customer GetCustomerByID(Guid id)
    {
        return _context.Customers.Where(c => c.ID == id).FirstOrDefault();
    }

    public void InsertCustomer(Customer customer)
    {
        _context.Add(customer);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void UpdateCustomer(Customer customer)
    {
        _context.Update(customer);
    }
}
