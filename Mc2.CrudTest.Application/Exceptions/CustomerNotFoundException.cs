namespace Mc2.CrudTest.Application.Exceptions;

public class CustomerNotFoundException : BaseException
{
    public CustomerNotFoundException() : base("Customer not found")
    {
    }
}
