using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace glasnost_back.Entities
{
    [Table("Estatutario")]
    public partial class Estatutario
    {

        public int Id { get; set; }

        public string Cargo { get; set; }

        public int Cliente_Id { get; set; }

        public int Pessoa_Id { get; set; }

        public int Area_Id { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public virtual Area Area { get; set; }

        [NotMapped]
        public bool AcaoNegada { get; set; }
    }
}
