using Application.Abstractions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        public Task<Candidate> CreateCandidate(Candidate candidate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCandidate(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Candidate> GetCandidate(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Candidate>> GetCandidates()
        {
            throw new NotImplementedException();
        }

        public Task<Candidate> UpdateCandidate(string updatedContent, int id)
        {
            throw new NotImplementedException();
        }
    }
}
