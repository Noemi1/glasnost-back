using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace glasnost_back.Entities
{
    [Table("Acionista")]
    public partial class Acionista
    {

        public Acionista()
        {
            Socios = new HashSet<Acionista>();
        }

        public int Id { get; set; }

        public int? Acionista_Id { get; set; }

        public int Pessoa_Id { get; set; }

        public int Cliente_Id { get; set; }

        public virtual Empresa Cliente { get; set; }

        public virtual Acionista SocioDe { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public virtual ICollection<Acionista> Socios { get; set; }
    }
}
