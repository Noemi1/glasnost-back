using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace glasnost_back.Entities
{
    public partial class Denuncia_Denunciante
    {
        public int Id { get; set; }

        public int Denuncia_Id { get; set; }

        [StringLength(150)]
        public string Nome { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(150)]
        public string Telefone { get; set; }

        [StringLength(150)]
        public string Empresa { get; set; }

        public virtual Denuncia Denuncia { get; set; }
    }
}
