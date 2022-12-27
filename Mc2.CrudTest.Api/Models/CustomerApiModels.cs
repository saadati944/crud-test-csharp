namespace Mc2.CrudTest.Api.Models;

public sealed record CreateCustomerRequest(string FirstName, string LastName)
{

}

public sealed record CreateCustomerResponse(Guid ID, string FirstName, string LastName)
{
    
}
