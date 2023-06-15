using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    public class Documento_Anexo
    {
        [Key]
        public int Id { get; set; }
        public string IdAzure { get; set; }
        public string NomeAzure { get; set; }
        public string Nome { get; set; }
        public int Documento_Id { get; set; }
        public virtual Documento Documento { get; set; }

    }
}