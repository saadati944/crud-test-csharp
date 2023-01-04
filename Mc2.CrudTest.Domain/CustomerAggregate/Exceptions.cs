namespace Mc2.CrudTest.Domain.CustomerAggregate;

public class InvalidPhoneNumberException : BaseException
{
    public override int ErrorCode => 101;
    public override string ErrorMessage => "Invalid Mobile Number";
}

public class InvalidEmailException : BaseException
{
    public override int ErrorCode => 102;
    public override string ErrorMessage => "Invalid Email address";
}

public class InvalidBankAccountNumberException : BaseException
{
    public override int ErrorCode => 103;
    public override string ErrorMessage => "Invalid Bank Account Number";
}

public class InvalidFirstNameException : BaseException
{
    public override int ErrorCode => 104;
    public override string ErrorMessage => "Invalid First Name";
}

public class InvalidLastNameException : BaseException
{
    public override int ErrorCode => 105;
    public override string ErrorMessage => "Invalid Last Name";
}

public class InvalidDateOfBirthException : BaseException
{
    public override int ErrorCode => 106;
    public override string ErrorMessage => "Invalid Date Of Birth";
}
