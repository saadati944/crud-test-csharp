namespace Mc2.CrudTest.Api.Models;

public class ErrorResponse
{
    public int ErrorCode { get; init; }
    public string ErrorMessage { get; init; }

    public static ErrorResponse CreateFromException(BaseException baseException)
    {
        return new ErrorResponse
        {
            ErrorCode = baseException.ErrorCode,
            ErrorMessage = baseException.ErrorMessage
        };
    }
}
