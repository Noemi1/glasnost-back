using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("DueDiligence_Consulta")]
    public class DueDiligence_Consulta
    {
        public DueDiligence_Consulta()
        {
            DueDiligence_Consulta_Resultado = new HashSet<DueDiligence_Consulta_Resultado>();
        }
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }
        public int DueDiligence_Pessoa_Id { get; set; }
        public int Parecer_Id { get; set; }
        public int Status_Id { get; set; }
        public string ParecerCompliance { get; set; }
        public string Account_Id { get; set; }

        public int Search_Id { get; set; } // campo API
        public decimal Progress { get; set; } // campo API
        public string Status { get; set; } // campo API

        public string Report_Url { get; set; } // campo API

        public virtual Account Account { get; set; }
        public virtual DueDiligence_Pessoa DueDiligence_Pessoa { get; set; }
        public virtual DueDiligence_Parecer DueDiligence_Parecer { get; set; }
        public virtual DueDiligence_Status DueDiligence_Status { get; set; }

        public virtual ICollection<DueDiligence_Consulta_Resultado> DueDiligence_Consulta_Resultado { get; set; }
    }
}