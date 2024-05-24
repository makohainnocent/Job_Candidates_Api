using Api.Abstractions;
using Application.Abstractions;
using Domain.Models;
using Microsoft.AspNetCore.Builder;

namespace Api.EndPointDefinitions
{
    using Application.Abstractions;
    using Domain.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    namespace Api.EndPointDefinitions
    {
        public class CandidateEndpointDefinition : IEndpointDefinition
        {
            public void RegisterEndpoints(WebApplication app)
            {
                var candidateGroup = app.MapGroup("/api/candidates");

                candidateGroup.MapGet("/{id}", GetCandidateById).WithName("GetCandidateById");
                candidateGroup.MapPost("/", CreateCandidate);
            }

            private  async Task<IResult> GetCandidateById(ICandidateRepository candidateRepository, int id)
            {
                var candidate = await candidateRepository.GetCandidate(id);
                return candidate is not null ? TypedResults.Ok(candidate) : Results.NotFound();
            }

            private  async Task<IResult> CreateCandidate(ICandidateRepository candidateRepository, Candidate candidate)
            {
                var createdCandidate = await candidateRepository.CreateCandidate(candidate);
                return Results.CreatedAtRoute("GetCandidateById", new { id = createdCandidate.Id }, createdCandidate);
            }
        }
    }

}

