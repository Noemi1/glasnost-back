using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("Organograma_Treinamento_Acesso")]

    public class Organograma_Treinamento_Acesso
    {

        public int Id { get; set; }

        public int Organograma_Treinamento_Id { get; set; }

        public DateTime DataHora { get; set; }

        public virtual Organograma_Treinamento Organograma_Treinamento { get; set; }

    }
}