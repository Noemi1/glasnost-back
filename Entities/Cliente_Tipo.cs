using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
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