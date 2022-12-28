using Mc2.CrudTest.Domain.CustomerAggregate;

namespace Mc2.CrudTest.Domain.Abstractions;

public interface ICustomerRepository
{
    IEnumerable<Customer> GetCustomers(ISpecification<Customer> specification);
    IEnumerable<Customer> GetCustomers(ISpecification<Customer> specification, int skip, int take);
    int GetCount(ISpecification<Customer> specification);

    Customer GetCustomerByID(Guid id);
    void InsertCustomer(Customer customer);
    void DeleteCustomer(Customer customer);
    void UpdateCustomer(Customer customer);
    void SaveChanges();
}
