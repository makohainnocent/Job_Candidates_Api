using FakeItEasy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Application.Abstractions;
using Domain.Models;

namespace Job_Candidates_Api.Tests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var fakeCandidateRepository = A.Fake<ICandidateRepository>();

                
                A.CallTo(() => fakeCandidateRepository.CreateCandidate(A<Candidate>.Ignored))
                    .ReturnsLazily((Candidate c) => Task.FromResult(c));

                services.AddSingleton(fakeCandidateRepository);
            });
        }
    }
}
