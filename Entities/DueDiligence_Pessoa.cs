using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("DueDiligence_Pessoa")]
    public class DueDiligence_Pessoa
    {
        public DueDiligence_Pessoa()
        {
            DueDiligence_Consulta = new HashSet<DueDiligence_Consulta>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public long Documento { get; set; }

        public string Relacionamento { get; set; }

        public string IdAzure { get; set; }

        public string NomeAzure { get; set; }

        public int Cliente_Id { get; set; }

        public bool PJ { get; set; }

        public string Observacoes { get; set; }

        public virtual Empresa Cliente { get; set; }

        public ICollection<DueDiligence_Consulta> DueDiligence_Consulta { get; set; }

    }
}