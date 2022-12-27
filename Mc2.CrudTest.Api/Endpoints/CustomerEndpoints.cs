using Mc2.CrudTest.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Api.Endpoints;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this WebApplication app)
    {
        app.MapPost("/Customer", CreateCustomer);
    }

    private static CreateCustomerResponse CreateCustomer([FromBody] CreateCustomerRequest customer)
    {
        return new CreateCustomerResponse(Guid.NewGuid(), customer.FirstName, customer.LastName);
    }
}
