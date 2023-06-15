using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("DueDiligence_ListaRestrita_Origem")]
    public class DueDiligence_ListaRestrita_Origem
    {
        public DueDiligence_ListaRestrita_Origem()
        {
            DueDiligence_ListaRestrita = new HashSet<DueDiligence_ListaRestrita>();
            DueDiligence_Consulta_Resultado = new HashSet<DueDiligence_Consulta_Resultado>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }
        public int Source_Id { get; set; }

        public ICollection<DueDiligence_ListaRestrita> DueDiligence_ListaRestrita { get; set; }
        public ICollection<DueDiligence_Consulta_Resultado> DueDiligence_Consulta_Resultado { get; set; }

    }
}