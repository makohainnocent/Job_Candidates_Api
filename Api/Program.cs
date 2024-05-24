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
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.RegisterEndpointdefinitions();


app.Run();


