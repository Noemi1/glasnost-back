using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("Comunicado")]
    public class Comunicado
    {
        public Comunicado()
        {
            Comunicado_Account_Rel = new HashSet<Comunicado_Account_Rel>();
        }
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataEnvio { get; set; }
        public string UserCriacao_Id { get; set; }
        public string UserEnvio_Id { get; set; }
        public string Corpo { get; set; }
        public string Assunto { get; set; }
        public int Cliente_Id { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Account UserCriacao { get; set; }
        public virtual Account UserEnvio { get; set; }

        public virtual ICollection<Comunicado_Account_Rel> Comunicado_Account_Rel { get; set; }
    }
}