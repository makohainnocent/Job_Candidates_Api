using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Candidate
    {
        public int Id { get; set; }

        
        [Required(ErrorMessage = "FirstName is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Comment is required.")]
        public string FreeTextComment { get; set; }

        
        public string? PhoneNumber { get; set; } 

        public string? PreferredCallTime { get; set; }

        [Url(ErrorMessage = "Please enter a valid URL for the LinkedIn profile (e.g., https://www.linkedin.com/in/username).")]
        public string? LinkedInProfileUrl { get; set; }

        [Url(ErrorMessage = "Please enter a valid URL for the GitHub profile (e.g., https://github.com/username).")]
        public string? GitHubProfileUrl { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? LastUpdated { get; set; }
    }
}
