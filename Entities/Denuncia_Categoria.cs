using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace glasnost_back.Entities
{
    public partial class Denuncia_Categoria
    {
        public Denuncia_Categoria()
        {
            Denuncia = new HashSet<Denuncia>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(75)]
        public string Nome { get; set; }

        public virtual ICollection<Denuncia> Denuncia { get; set; }

    }
}
