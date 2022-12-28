namespace Mc2.CrudTest.Application.Queries;

public class GetCustomersQuery : IRequest<CustomersDTO>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}

