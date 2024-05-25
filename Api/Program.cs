using Api.Extensions;
using Application.Abstractions;
using Domain.Models;
using SQLitePCL;

Batteries.Init();

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandlingMiddleware();
    //app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandlingMiddleware(); 
}

app.RegisterEndpointdefinitions();


app.Run();


public partial class Program { }