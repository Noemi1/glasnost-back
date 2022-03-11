using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace glasnost_back.Models
{
    [Table("Cliente_Tipo")]
    public class Cliente_Tipo
    {
        public Cliente_Tipo()
        {
            Cliente = new HashSet<Cliente>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Cliente> Cliente { get; set; }
    }
}
