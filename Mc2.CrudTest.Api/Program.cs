using Mc2.CrudTest.Api.Endpoints;
using Mc2.CrudTest.Application;
using Mc2.CrudTest.Infrastructure;
using Mc2.CrudTest.Infrastructure.Data;
using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

const string CorsPolicy = "CORS_policy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterDatabase(builder.Configuration.GetConnectionString("CrudTestConnectionString"));
builder.Services.RegisterServices();
builder.Services.RegisterMediatR();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsPolicy,
        policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowAnyOrigin();
        });
});

// Configure the HTTP request pipeline.
var app = builder.Build();

app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = Application.Json;

        await context.Response.WriteAsJsonAsync("InternalServerError");
    });
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(CorsPolicy);
app.MapCustomerEndpoints();

await app.Services.CreateScope().ServiceProvider.GetRequiredService<CrudTestsContext>().Database.EnsureCreatedAsync();

app.Run();