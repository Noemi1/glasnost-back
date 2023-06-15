using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace glasnost_back.Entities
{
    public partial class Denuncia_Validacao
    {
        public Denuncia_Validacao()
        {
            Denuncia = new HashSet<Denuncia>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        public virtual ICollection<Denuncia> Denuncia { get; set; }
    }
}
