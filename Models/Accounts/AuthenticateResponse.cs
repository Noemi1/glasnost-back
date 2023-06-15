using Planner.Entities;
using System;
using System.Text.Json.Serialization;

namespace glasnost_back.Models.Accounts
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public int Empresa_Id { get; set; }
        public int PerfilAcesso_Id { get; set; }
        public string Name { get; set; }
        public long TelefoneCelular { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool IsVerified { get; set; }
        public string JwtToken { get; set; }

        [JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual AccountPerfilAcesso PerfilAcesso { get; set; }
    }
}