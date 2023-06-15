using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("Documento_Tipo_Categoria")]
    public class Documento_Tipo_Categoria
    {
        public Documento_Tipo_Categoria()
        {
            Documento_Tipo = new HashSet<Documento_Tipo>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<Documento_Tipo> Documento_Tipo { get; set; }

    }
}