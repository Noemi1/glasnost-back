using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace glasnost_back.Entities
{
    public partial class Denuncia_Acao
    {
        public Denuncia_Acao()
        {
            Denuncia = new HashSet<Denuncia>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<Denuncia> Denuncia { get; set; }
    }
}
