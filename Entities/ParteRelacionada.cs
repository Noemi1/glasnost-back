using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("ParteRelacionada")]
    public class ParteRelacionada
    {
        public int Id { get; set; }

        public string Exigencias { get; set; }

        public int Cliente_Id { get; set; }

        public int Pessoa_Id { get; set; }

        public int ParteRelacionada_Tipo_Id { get; set; }

        public virtual Empresa Cliente { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public virtual ParteRelacionada_Tipo ParteRelacionada_Tipo { get; set; }

    }
}