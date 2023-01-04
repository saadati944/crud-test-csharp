namespace Mc2.CrudTest.Application.Exceptions;

public class CustomerNameAndDateOfBirthIsNotUnique : BaseException
{
    public override int ErrorCode => 201;
    public override string ErrorMessage => "Duplicate customer by First-name, Last-name, Date-of-Birth";
}
