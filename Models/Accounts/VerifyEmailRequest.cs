using System.ComponentModel.DataAnnotations;

namespace glasnost_back.Models.Accounts
{
    public class VerifyEmailRequest
    {
        [Required]
        public string Token { get; set; }
    }
}