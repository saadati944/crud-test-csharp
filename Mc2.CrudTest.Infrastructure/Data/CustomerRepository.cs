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

    public IEnumerable<Customer> GetCustomers(ISpecification<Customer> specification)
    {
        return specification.Apply(_context.Customers);
    }
    
    public IEnumerable<Customer> GetCustomers(ISpecification<Customer> specification, int skip, int take)
    {
        return GetCustomers(specification).Skip(skip).Take(take);
    }

    public int GetCount(ISpecification<Customer> specification)
    {
        return specification.Apply(_context.Customers).Count();
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
