namespace Mc2.CrudTest.Application.Exceptions;

public class CustomerNotFoundException : BaseException
{
    public override string ErrorMessage => "Customer not found";
}
