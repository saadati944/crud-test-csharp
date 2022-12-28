namespace Mc2.CrudTest.Application.Queries;

public class GetCustomerQuery : IRequest<Customer>
{
    public Guid ID { get; set; }
}
