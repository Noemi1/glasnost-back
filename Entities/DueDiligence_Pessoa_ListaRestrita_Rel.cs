using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("DueDiligence_Pessoa_ListaRestrita_Rel")]
    public class DueDiligence_Pessoa_ListaRestrita_Rel
    {
        public int Id { get; set; }

        public int DueDiligence_Pessoa_Id { get; set; }

        public int DueDiligence_ListaRestrita_Id { get; set; }

        public string Comentario { get; set; }

        public virtual DueDiligence_Pessoa DueDiligence_Pessoa { get; set; }

        public virtual DueDiligence_ListaRestrita DueDiligence_ListaRestrita { get; set; }

    }
}