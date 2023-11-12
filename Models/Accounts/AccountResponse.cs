using glasnost_back.Entities;
using System;

namespace glasnost_back.Models.Accounts
{
    public class AccountResponse
    {
        public int Id { get; set; }
        public int Empresa_Id { get; set; }
        public int PerfilAcesso_Id { get; set; }
        public string Name { get; set; }
        public long TelefoneCelular { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool IsVerified { get; set; }
        public DateTime? DataDesativado { get; set; }
        public virtual AccountPerfilAcesso PerfilAcesso { get; set; }
    }
}