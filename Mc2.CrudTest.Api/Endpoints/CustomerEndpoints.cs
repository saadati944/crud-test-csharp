namespace Mc2.CrudTest.Api.Endpoints;

public static class CustomerEndpoints
{
    private const string CustomersEndpointPath = "Customers";

    public static void MapCustomerEndpoints(this WebApplication app)
    {
        app.MapPost($"/{CustomersEndpointPath}", CreateCustomer);
        app.MapGet($"/{CustomersEndpointPath}/{{ID}}", GetCustomer);
        app.MapGet($"/{CustomersEndpointPath}", GetCustomers);
        app.MapPut($"/{CustomersEndpointPath}/{{ID}}", UpdateCustomer);
        app.MapDelete($"/{CustomersEndpointPath}/{{ID}}", DeleteCustomer);
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
            return Results.Created($"/{CustomersEndpointPath}/{res.ID}", CustomerResponse.Create(res));
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
            ? Results.Ok(CustomerResponse.Create(res))
            : Results.NotFound();
    }

    private static async Task<IResult> GetCustomers(
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken,
        [FromQuery] int page = 0, [FromQuery] int pageSize = 10)
    {
        var req = new GetCustomersQuery
        {
            Page = page,
            PageSize = pageSize
        };
        
        var res = await mediator.Send(req, cancellationToken);

        return Results.Ok(CustomersResponse.Create(page, pageSize, res));
    }

    private static async Task<IResult> UpdateCustomer([FromRoute] Guid id, [FromBody] UpdateCustomerRequest customer,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var req = customer.MapToUpdateCustomerCommand();
        req.ID = id;

        try
        {
            _ = await mediator.Send(req, cancellationToken);
            return Results.Ok();
        }
        // A PUT endpoint either updates an already available record or creates new one but for simplicity my endpoint only can perform updates.
        catch (CustomerNotFoundException)
        {
            return Results.NotFound();
        }
        catch (BaseException ex)
        {
            return Results.Problem(ex.Message, statusCode: 400);
        }
    }

    private static async Task<IResult> DeleteCustomer([FromRoute] Guid id,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var req = new DeleteCustomerCommand { ID = id };

        try
        {
            _ = await mediator.Send(req, cancellationToken);
            return Results.NoContent();
        }
        catch (CustomerNotFoundException)
        {
            return Results.NotFound();
        }
    }
}
