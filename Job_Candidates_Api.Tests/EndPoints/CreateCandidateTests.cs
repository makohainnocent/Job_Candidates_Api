using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using Domain.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Job_Candidates_Api.Tests.EndPoints
{
    public class CreateCandidateTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public CreateCandidateTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateCandidate_ReturnsCreatedResponse()
        {
            // Arrange
            var newCandidate = new Candidate
            {
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane.doe@example.com",
                FreeTextComment = "Test Comment"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/candidates", newCandidate);

            // Assert
            response.EnsureSuccessStatusCode();
            var createdCandidate = await response.Content.ReadFromJsonAsync<Candidate>();
            Assert.NotNull(createdCandidate);
            Assert.Equal(newCandidate.FirstName, createdCandidate.FirstName);
            Assert.Equal(newCandidate.LastName, createdCandidate.LastName);
            Assert.Equal(newCandidate.Email, createdCandidate.Email);
            Assert.Equal(newCandidate.FreeTextComment, createdCandidate.FreeTextComment);
        }
    }
}
