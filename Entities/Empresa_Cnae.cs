using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    public class Empresa_Cnae
    {

        public Empresa_Cnae()
        {
            Empresa_Cnae_Rel = new HashSet<Empresa_Cnae_Rel>();
        }
        public int Id { get; set; }

        public string Codigo { get; set; } = String.Empty;

        public string Descricao { get; set; } = String.Empty;

        public virtual ICollection<Empresa_Cnae_Rel> Empresa_Cnae_Rel { get; set; }

    }
}