using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("Prospect_Arquivo")]
    public class Prospect_Arquivo
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string NomeAzure { get; set; }

        public string CaminhoAzure { get; set; }

        public DateTime DataCadastro { get; set; }

        public string Account_Id { get; set; }

        public int Prospect_Id { get; set; }

        public virtual Account Account { get; set; }

        public virtual Prospect Prospect { get; set; }

    }
}