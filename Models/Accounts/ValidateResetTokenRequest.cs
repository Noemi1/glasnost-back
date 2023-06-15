using System.ComponentModel.DataAnnotations;

namespace glasnost_back.Models.Accounts
{
    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}