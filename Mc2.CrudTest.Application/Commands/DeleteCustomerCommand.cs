namespace Mc2.CrudTest.Application.Commands;

public class DeleteCustomerCommand : IRequest
{
    public Guid ID { get; set; }
}
