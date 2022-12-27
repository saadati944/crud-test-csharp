using Mc2.CrudTest.Api.Models;
using Mc2.CrudTest.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Api.Endpoints;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this WebApplication app)
    {
        app.MapPost("/Customer", CreateCustomer);
    }

    private static async Task<CreateCustomerResponse> CreateCustomer([FromBody] CreateCustomerRequest customer,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var req = customer.MapToCreateCustomerCommand();

        var res = await mediator.Send(req, cancellationToken);

        return CreateCustomerResponse.CreateFromCustomer(res);
    }
}
