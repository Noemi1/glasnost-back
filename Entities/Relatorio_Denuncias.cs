using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    public class Relatorio_Denuncias
    {
        public int Id { get; set; }
        public int Cliente_Id { get; set; }
        public string NomeAzure { get; set; }
        public string IdAzure { get; set; }
        public DateTime DataCriacao { get; set; }
        public string UserCriacao_Id { get; set; }
        public int AnoRef { get; set; }
        public int MesRef { get; set; }

        public virtual Empresa Cliente { get; set; }
    }
}