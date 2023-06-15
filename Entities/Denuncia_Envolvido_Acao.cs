using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace glasnost_back.Entities
{
    public partial class Denuncia_Envolvido_Acao
    {
        public Denuncia_Envolvido_Acao()
        {
            Denuncia_Envolvido = new HashSet<Denuncia_Envolvido>();
        }

        public int Id { get; set; }

        [StringLength(60)]
        public string Nome { get; set; }

        public virtual ICollection<Denuncia_Envolvido> Denuncia_Envolvido { get; set; }
    }
}
