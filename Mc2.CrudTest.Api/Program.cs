using Mc2.CrudTest.Api.Endpoints;
using Mc2.CrudTest.Application;
using Mc2.CrudTest.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterDatabase(builder.Configuration.GetConnectionString("CrudTestConnectionString")!);
builder.Services.RegisterServices();
builder.Services.RegisterMediatR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapCustomerEndpoints();

app.Run();