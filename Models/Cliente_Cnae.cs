using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace glasnost_back.Models
{
    //[Table("Cliente_Cnae")]
    public class Cliente_Cnae
    {
        public Cliente_Cnae()
        {
            Cliente_Cnae_Rel = new HashSet<Cliente_Cnae_Rel>();
        }

        //[Required(ErrorMessage = "Id é um campo obrigatório")]
        public int Id { get; set; }

        //[Required(ErrorMessage = "Código é um campo obrigatório")]
        public string Codigo { get; set; }

        //[Required(ErrorMessage = "Descrição é um campo obrigatório")]
        public string Descricao { get; set; }

        public virtual ICollection<Cliente_Cnae_Rel> Cliente_Cnae_Rel { get; set; }


    }
}
