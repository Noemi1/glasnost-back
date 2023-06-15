using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace glasnost_back.Entities
{
    public partial class Denuncia_Gravidade
    {
        public Denuncia_Gravidade()
        {
            Denuncia = new HashSet<Denuncia>();
        }

        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public virtual ICollection<Denuncia> Denuncia { get; set; }
    }
}
