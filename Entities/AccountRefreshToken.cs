using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace glasnost_back.Entities
{
    //[Owned]
    public class RefreshToken : BaseEntity
    {
        //[Key]
        public int Id { get; set; }
        public int Account_Id { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime Created { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
        public bool IsActiveByIp { get; set; }
        
        public Account Account { get; set; }

    }
}
