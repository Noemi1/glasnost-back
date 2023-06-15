using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace glasnost_back.Entities
{
    public partial class Denuncia_Canal
    {
        public Denuncia_Canal()
        {
            Denuncia = new HashSet<Denuncia>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public virtual ICollection<Denuncia> Denuncia { get; set; }
    }
}
