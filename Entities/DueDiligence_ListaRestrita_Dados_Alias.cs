using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    public class DueDiligence_ListaRestrita_Dados_Alias
    {
        public DueDiligence_ListaRestrita_Dados_Alias()
        {
            DueDiligence_ListaRestrita_Dados = new HashSet<DueDiligence_ListaRestrita_Dados>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Alias { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<DueDiligence_ListaRestrita_Dados> DueDiligence_ListaRestrita_Dados { get; set; }
    }
}