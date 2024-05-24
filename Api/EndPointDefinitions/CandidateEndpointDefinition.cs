using Api.Abstractions;
using Application.Abstractions;
using Domain.Models;

namespace Api.EndPointDefinitions
{
    public class CandidateEndpointDefinition:IEndpointDefinition
    {
       public  void RegisterEndpoints(WebApplication app)
        {
            app.MapGet("/api/candidates/{id}", async (ICandidateRepository candidateRepository, int id) => {
                var candidate = await candidateRepository.GetCandidate(id);
                return candidate is not null ? Results.Ok(candidate) : Results.NotFound();

            }).WithName("GetCandidateById");

            app.MapPost("/api/candidates", async (ICandidateRepository candidateRepository, Candidate candidate) =>
            {
                var createdCandidate = await candidateRepository.CreateCandidate(candidate);
                return Results.CreatedAtRoute("GetCandidateById", new { createdCandidate.Id }, createdCandidate);

            });
        }
    }
}
