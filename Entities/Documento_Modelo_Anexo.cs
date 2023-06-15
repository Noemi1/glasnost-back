using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("Documento_Modelo_Anexo")]
    public class Documento_Modelo_Anexo
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string NomeAzure { get; set; }

        public string IdAzure { get; set; }

        public string Descricao { get; set; }

        public int Documento_Modelo_Id { get; set; }

        public virtual Documento_Modelo Documento_Modelo { get; set; }

    }
}