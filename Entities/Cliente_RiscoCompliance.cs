using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("Cliente_RiscoCompliance")]
    public class Cliente_RiscoCompliance
    {
        public Cliente_RiscoCompliance()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int Id { get; set; }
        public string Nome{ get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}