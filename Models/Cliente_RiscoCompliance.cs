using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace glasnost_back.Models
{
    [Table("Cliente_RiscoCompliance")]
    public class Cliente_RiscoCompliance
    {
        public Cliente_RiscoCompliance()
        {
            Cliente = new HashSet<Cliente>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
