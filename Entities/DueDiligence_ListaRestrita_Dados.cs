using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("DueDiligence_ListaRestrita_Dados")]
    public class DueDiligence_ListaRestrita_Dados
    {
        public DueDiligence_ListaRestrita_Dados()
        {
            CamposFilhos = new HashSet<DueDiligence_ListaRestrita_Dados>();
        }
        public int Id { get; set; }
        public int DueDiligence_ListaRestrita_Id { get; set; }
        public int DueDiligence_ListaRestrita_Dados_Alias_Id { get; set; }
        public string Valor { get; set; }
        public string Tipo { get; set; }
        public int? CampoPai_Id { get; set; }

        public virtual DueDiligence_ListaRestrita DueDiligence_ListaRestrita { get; set; }
        public virtual DueDiligence_ListaRestrita_Dados CampoPai { get; set; }
        public virtual DueDiligence_ListaRestrita_Dados_Alias DueDiligence_ListaRestrita_Dados_Alias { get; set; }
        public virtual ICollection<DueDiligence_ListaRestrita_Dados> CamposFilhos { get; set; }

    }
}