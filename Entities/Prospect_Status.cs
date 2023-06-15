using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("Prospect_Status")]
    public class Prospect_Status
    {
        public Prospect_Status()
        {
            Prospect = new HashSet<Prospect>();
        }
        public int Id { get; set; }

        public string Nome { get; set; }

        public ICollection<Prospect> Prospect { get; set; }
    }
}