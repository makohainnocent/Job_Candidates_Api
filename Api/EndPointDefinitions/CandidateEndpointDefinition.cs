using Api.Abstractions;
using Application.Abstractions;
using Domain.Models;
using Microsoft.AspNetCore.Builder;

namespace Api.EndPointDefinitions
{
    public class CandidateEndpointDefinition : IEndpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var candidateGroup = app.MapGroup("/api/candidates");

            candidateGroup.MapGet("/{id}", async (ICandidateRepository candidateRepository, int id) =>
            {
                var candidate = await candidateRepository.GetCandidate(id);
                return candidate is not null ? Results.Ok(candidate) : Results.NotFound();
            }).WithName("GetCandidateById");

            candidateGroup.MapPost("/", async (ICandidateRepository candidateRepository, Candidate candidate) =>
            {
                var createdCandidate = await candidateRepository.CreateCandidate(candidate);
                return Results.CreatedAtRoute("GetCandidateById", new { id = createdCandidate.Id }, createdCandidate);
            });
        }
    }
}

