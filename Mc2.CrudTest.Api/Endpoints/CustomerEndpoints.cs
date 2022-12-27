using Mc2.CrudTest.Api.Models;
using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Queries;
using Mc2.CrudTest.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Api.Endpoints;

public static class CustomerEndpoints
{
    private const string CustomerEndpointPath = "Customer";

    public static void MapCustomerEndpoints(this WebApplication app)
    {
        app.MapPost($"/{CustomerEndpointPath}", CreateCustomer);
        app.MapGet($"/{CustomerEndpointPath}/{{ID}}", GetCustomer);
    }

    private static async Task<IResult> CreateCustomer([FromBody] CreateCustomerRequest customer,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var req = customer.MapToCreateCustomerCommand();

        // For better performance you can return a custom result object from your services
        // (also there are some libraries to facilitate this process like OneOf) but in this project,
        // I prefer this simple try-catch block for simplicity
        try
        {
            var res = await mediator.Send(req, cancellationToken);
            return Results.Created($"/{CustomerEndpointPath}/{res.ID}", CustomerResponse.CreateFromCustomer(res));
        }
        catch(BaseException ex)
        {
            return Results.Problem(ex.Message, statusCode: 400);
        }
    }

    private static async Task<IResult> GetCustomer([FromRoute] Guid id,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var req = new GetCustomerQuery { ID = id };
        var res = await mediator.Send(req, cancellationToken);
        return res is not null
            ? Results.Ok(CustomerResponse.CreateFromCustomer(res))
            : Results.NotFound();
    }
}
