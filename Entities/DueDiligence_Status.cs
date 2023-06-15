using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("DueDiligence_Status")]
    public class DueDiligence_Status
    {
        public DueDiligence_Status()
        {
            DueDiligence_Consulta = new HashSet<DueDiligence_Consulta>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<DueDiligence_Consulta> DueDiligence_Consulta { get; set; }

    }
}