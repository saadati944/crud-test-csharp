using Mc2.CrudTest.Domain.CustomerAggregate;

namespace Mc2.CrudTest.Domain.Abstractions;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetCustomers(ISpecification<Customer> specification);
    Task<IEnumerable<Customer>> GetCustomers(ISpecification<Customer> specification, int skip, int take);
    Task<int> GetCount(ISpecification<Customer> specification);

    Task<Customer> GetCustomerByID(Guid id);
    void InsertCustomer(Customer customer);
    void DeleteCustomer(Customer customer);
    void UpdateCustomer(Customer customer);
    Task SaveChanges();
}
