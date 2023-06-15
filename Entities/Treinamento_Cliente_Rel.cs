using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("Treinamento_Cliente")]
    public class Treinamento_Cliente_Rel
    {
        public int Id { get; set; }
        public int Cliente_Id { get; set; }
        public int Treinamento_Id { get; set; }
        public virtual Treinamento Treinamento { get; set; }
        public virtual Cliente Cliente { get; set; }

        [NotMapped]
        public virtual IEnumerable<Treinamento> Treinamentos { get; set; }
    }
}