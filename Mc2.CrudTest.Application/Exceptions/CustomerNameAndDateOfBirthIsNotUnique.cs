namespace Mc2.CrudTest.Application.Exceptions;

public class CustomerNameAndDateOfBirthIsNotUnique : BaseException
{
    public CustomerNameAndDateOfBirthIsNotUnique(string message) : base(message)
    {
    }
}
