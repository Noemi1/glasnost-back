using System;
using System.Collections.Generic;

#nullable disable

namespace glasnost_back.Entities
{
    public partial class AccountPerfilAcesso : BaseEntity
    {
        public AccountPerfilAcesso()
        {
            Account = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string Perfil { get; set; }

        public virtual ICollection<Account> Account { get; set; }
    }

    public enum AccountRole
    {
        Admin = 1,
        Master = 2,
        ComplianceOfficer = 3
    }
}
