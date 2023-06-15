using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("Treinamento_Tipo")]
    public class Treinamento_Tipo
    {
        public Treinamento_Tipo()
        {

            Treinamento = new HashSet<Treinamento>();
        }
        public int Id { get; set; }
        public string Tipo { get; set; }
        public virtual ICollection<Treinamento> Treinamento { get; set; }

    }
}