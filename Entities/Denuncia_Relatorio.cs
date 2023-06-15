using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    public class Denuncia_Relatorio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeAzure { get; set; }
        public string IdAzure { get; set; }
        public string Account_Id { get; set; }
        public DateTime Data { get; set; }
        public int Denuncia_Id { get; set; }
        public virtual Account Account { get; set; }
        public virtual Denuncia Denuncia { get; set; }

    }
}