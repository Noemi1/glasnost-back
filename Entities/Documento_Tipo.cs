using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("Documento_Tipo")]
    public class Documento_Tipo
    {
        public Documento_Tipo()
        {
            Documento = new HashSet<Documento>();
            Documento_Modelo = new HashSet<Documento_Modelo>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Arquivo { get; set; }

        public int? Numero { get; set; }

        public string Tipo { get; set; }

        public string Publicacao { get; set; }

        public bool Ativo { get; set; }

        public int Documento_Tipo_Categoria_Id { get; set; }

        public virtual Documento_Tipo_Categoria Documento_Tipo_Categoria { get; set; }

        public virtual ICollection<Documento> Documento { get; set; }
        public virtual ICollection<Documento_Modelo> Documento_Modelo { get; set; }

    }
}