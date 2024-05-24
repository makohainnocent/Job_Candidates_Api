using Application.Abstractions;
using DataAccess.DbConnection;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Connections;
using SQLitePCL;

Batteries.Init();

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDbConnectionProvider, DbConnection>();
builder.Services.AddTransient<ICandidateRepository, CandidateRepository>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.MapGet("/api/candidates/{id}", async (ICandidateRepository candidateRepository,int id) => { 
    var candidate = await candidateRepository.GetCandidate(id);
    return Results.Ok(candidate);

});

app.Run();


