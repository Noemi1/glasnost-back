namespace glasnost_back.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AspNetUserRoles
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string RoleId { get; set; }

        public virtual AspNetRoles AspNetRoles { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
