using System.ComponentModel.DataAnnotations;

namespace glasnost_back.Models.Accounts
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}