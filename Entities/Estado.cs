using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("Estado")]
    public class Estado
    {

        public Estado()
        {
            Cidade = new HashSet<Cidade>();
        }

        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Nome { get; set; }

        public ICollection<Cidade> Cidade { get; set; }

    }
}