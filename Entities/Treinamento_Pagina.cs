using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace glasnost_back.Entities
{
    [Table("Treinamento_Pagina")]
    public class Treinamento_Pagina
    {
        public int Id { get; set; }

        public int Treinamento_Id { get; set; }

        public int Ordem { get; set; }

        public string Pagina { get; set; }

        public string TipoPagina { get; set; }

        public string Width { get; set; }

        public string Height { get; set; }

        public string Arquivo { get; set; }

        public string Url { get; set; }

        public virtual Treinamento Treinamento { get; set; }


    }
}