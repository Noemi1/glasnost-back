using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("Cidade")]
    public class Cidade
    {
        public Cidade()
        {
            Prospect = new HashSet<Prospect>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public int Estado_Id { get; set; }

        public virtual Estado Estado { get; set; }

        public ICollection<Prospect> Prospect { get; set; }

    }
}