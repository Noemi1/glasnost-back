using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("ParteRelacionada_Tipo")]

    public class ParteRelacionada_Tipo
    {
        public ParteRelacionada_Tipo()
        {
            ParteRelacionada = new HashSet<ParteRelacionada>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public ICollection<ParteRelacionada> ParteRelacionada { get; set; }
    }
}