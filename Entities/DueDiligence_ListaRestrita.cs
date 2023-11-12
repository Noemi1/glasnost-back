using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("DueDiligence_ListaRestrita")]
    public class DueDiligence_ListaRestrita
    {

        public DueDiligence_ListaRestrita()
        {
            DueDiligence_Consulta_Resultado = new HashSet<DueDiligence_Consulta_Resultado>();
            DueDiligence_ListaRestrita_Dados = new HashSet<DueDiligence_ListaRestrita_Dados>();
        }
        public int Id { get; set; }

        public string Nome { get; set; }

        public long Documento { get; set; }

        public string Detalhes { get; set; }

        public DateTime IncluidoEm { get; set; }

        public DateTime? ExcluidoEm { get; set; }

        public int DueDiligence_ListaRestrita_Origem_Id { get; set; }

        public virtual DueDiligence_ListaRestrita_Origem DueDiligence_ListaRestrita_Origem { get; set; }

        public ICollection<DueDiligence_Consulta_Resultado> DueDiligence_Consulta_Resultado { get; set; }
        public ICollection<DueDiligence_ListaRestrita_Dados> DueDiligence_ListaRestrita_Dados { get; set; }

    }
}