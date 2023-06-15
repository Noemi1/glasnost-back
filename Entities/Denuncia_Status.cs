using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace glasnost_back.Entities
{
    public partial class Denuncia_Status
    {
        public Denuncia_Status()
        {
            Denuncia = new HashSet<Denuncia>();
            Denuncia_Historico_Status = new HashSet<Denuncia_Historico_Status>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public virtual ICollection<Denuncia> Denuncia { get; set; }

        public virtual ICollection<Denuncia_Historico_Status> Denuncia_Historico_Status { get; set; }
    }
}
