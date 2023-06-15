using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("DueDiligence_Consulta_Resultado")]
    public class DueDiligence_Consulta_Resultado
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public int DueDiligence_Consulta_Id { get; set; }
        public int DueDiligence_ListaRestrita_Origem_Id { get; set; }
        public int? DueDiligence_ListaRestrita_Id { get; set; }

        public virtual DueDiligence_Consulta DueDiligence_Consulta { get; set; }
        public virtual DueDiligence_ListaRestrita DueDiligence_ListaRestrita { get; set; }
        public virtual DueDiligence_ListaRestrita_Origem DueDiligence_ListaRestrita_Origem { get; set; }
    }
}