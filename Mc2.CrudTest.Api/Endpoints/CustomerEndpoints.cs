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
            return Results.BadRequest(ErrorResponse.CreateFromException(ex));
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
        [FromQuery] int Page = 0,
        [FromQuery] int PageSize = 10,
        [FromQuery] string FirstName = null,
        [FromQuery] string LastName = null,
        [FromQuery] DateTime? DateOfBirth = null,
        [FromQuery] string Email = null,
        [FromQuery] string PhoneNumber = null,
        [FromQuery] string BankAccountNumber = null)
    {
        var req = GetCustomersQuery.CreateWithParameters(
            Page,
            PageSize,
            FirstName,
            LastName,
            DateOfBirth,
            Email,
            PhoneNumber,
            BankAccountNumber
        );

        var res = await mediator.Send(req, cancellationToken);

        return Results.Ok(CustomersResponse.Create(Page, PageSize, res));
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
            return Results.BadRequest(ErrorResponse.CreateFromException(ex));
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
