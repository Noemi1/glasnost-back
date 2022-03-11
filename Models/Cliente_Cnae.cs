using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace glasnost_back.Models
{
    public class Cliente_Cnae
    {
        public Cliente_Cnae()
        {
            Cliente_Cnae_Rel = new HashSet<Cliente_Cnae_Rel>();
        }
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<Cliente_Cnae_Rel> Cliente_Cnae_Rel { get; set; }

    }
}
