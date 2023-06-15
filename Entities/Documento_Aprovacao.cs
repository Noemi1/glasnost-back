using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("Documento_Aprovacao")]
    public class Documento_Aprovacao
    {

        public Documento_Aprovacao()
        {
        }

        [Key]
        public int Id { get; set; }
        public int Versao { get; set; }
        public int Documento_Id { get; set; }
        public string IdAzure { get; set; }
        public string NomeAzure { get; set; }
        public string UsuarioAprovacao_Id { get; set; }
        public DateTime DataAprovacao { get; set; }

        public virtual Documento Documento { get; set; }
    }
}