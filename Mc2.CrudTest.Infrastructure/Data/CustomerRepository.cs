using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Data;

public class CustomerRepository : ICustomerRepository
{
    private readonly CrudTestsContext _context;

    public CustomerRepository(CrudTestsContext context)
    {
        _context = context;
    }

    public void InsertCustomer(Customer customer)
    {
        _context.Add(customer);
    }

    public async Task<Customer> GetCustomerByID(Guid id)
    {
        return await _context.Customers.Where(c => c.ID == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Customer>> GetCustomers(ISpecification<Customer> specification)
    {
        return await specification.Apply(_context.Customers).ToListAsync();
    }

    public async Task<IEnumerable<Customer>> GetCustomers(ISpecification<Customer> specification, int skip, int take)
    {
        return await specification.Apply(_context.Customers).Skip(skip).Take(take).ToListAsync();
    }

    public async Task<int> GetCount(ISpecification<Customer> specification)
    {
        return await specification.Apply(_context.Customers).CountAsync();
    }

    public void UpdateCustomer(Customer customer)
    {
        _context.Update(customer);
    }

    public void DeleteCustomer(Customer c)
    {
        _context.Remove(c);
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}
