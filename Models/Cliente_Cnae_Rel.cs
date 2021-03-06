using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace glasnost_back.Models
{
    [Table("Cliente_Cnae_Rel")]
    public class Cliente_Cnae_Rel
    {
        public int Id { get; set; }
        public int Cliente_Id { get; set; }
        public int Cnae_Id { get; set; }
        public virtual Cliente_Cnae Cnae { get; set; }
        public virtual Cliente Cliente { get; set; }

        [NotMapped]
        public bool Excluir { get; set; }

    }
}
