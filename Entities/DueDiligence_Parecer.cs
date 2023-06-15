using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("DueDiligence_Parecer")]
    public class DueDiligence_Parecer
    {
        public DueDiligence_Parecer()
        {
            DueDiligence_Consulta = new HashSet<DueDiligence_Consulta>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<DueDiligence_Consulta> DueDiligence_Consulta { get; set; }

    }
}