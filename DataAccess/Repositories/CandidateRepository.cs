using Application.Abstractions;
using Domain.Models;
using Dapper;


namespace DataAccess.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly IDbConnectionProvider _dbConnectionProvider;

        public CandidateRepository(IDbConnectionProvider dbConnectionProvider)
        {
            _dbConnectionProvider = dbConnectionProvider;
        }

        public async Task<Candidate> CreateCandidate(Candidate candidate)
        {
            const string sql = @"
                INSERT INTO Candidates (FirstName, LastName, Email, PhoneNumber, PreferredCallTime, LinkedInProfileUrl, GitHubProfileUrl, FreeTextComment)
                VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @PreferredCallTime, @LinkedInProfileUrl, @GitHubProfileUrl, @FreeTextComment);
                SELECT LAST_INSERT_ID();";

            using (var connection = _dbConnectionProvider.CreateConnection())
            {
                var candidateId = await connection.QueryFirstOrDefaultAsync<int>(sql, candidate);
                candidate.Id = candidateId;
                return candidate;
            }
        }

        public async Task DeleteCandidate(int id)
        {
            const string sql = "DELETE FROM Candidates WHERE Id = @Id";

            using (var connection = _dbConnectionProvider.CreateConnection())
            {
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<Candidate> GetCandidate(int id)
        {
            const string sql = "SELECT * FROM Candidates WHERE Id = @Id";

            using (var connection = _dbConnectionProvider.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Candidate>(sql, new { Id = id });
            }
        }

        public async Task<ICollection<Candidate>> GetCandidates()
        {
            const string sql = "SELECT * FROM Candidates";

            using (var connection = _dbConnectionProvider.CreateConnection())
            {
                return (await connection.QueryAsync<Candidate>(sql)).ToList();
            }
        }

        public async Task<Candidate> UpdateCandidate(Candidate candidate)
        {
            const string sql = @"
                UPDATE Candidates 
                SET FirstName = @FirstName, 
                    LastName = @LastName, 
                    Email = @Email, 
                    PhoneNumber = @PhoneNumber, 
                    PreferredCallTime = @PreferredCallTime, 
                    LinkedInProfileUrl = @LinkedInProfileUrl, 
                    GitHubProfileUrl = @GitHubProfileUrl, 
                    FreeTextComment = @FreeTextComment
                WHERE Id = @Id";

            using (var connection = _dbConnectionProvider.CreateConnection())
            {
                await connection.ExecuteAsync(sql, candidate);
                return await GetCandidate(candidate.Id);
            }
        }

        public Task<Candidate> UpdateCandidate(string updatedContent, int id)
        {
            throw new NotImplementedException();
        }
    }
}
