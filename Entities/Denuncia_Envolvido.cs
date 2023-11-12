using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace glasnost_back.Entities
{
    public partial class Denuncia_Envolvido
    {
        public int Id { get; set; }

        public int Denuncia_Id { get; set; }

        [StringLength(150)]
        public string Nome { get; set; }

        [StringLength(50)]
        public string Cargo { get; set; }

        public int? Denuncia_Envolvido_Acao_Id { get; set; }

        public string Comentarios { get; set; }

        public virtual Denuncia Denuncia { get; set; }

        public virtual Denuncia_Envolvido_Acao Denuncia_Envolvido_Acao { get; set; }
    }
}
