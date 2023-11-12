using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("Pessoa")]
    public class Pessoa
    {
        public Pessoa()
        {
            Account = new HashSet<Account>();
            Acionista = new HashSet<Acionista>();
            Estatutario = new HashSet<Estatutario>();
            ParteRelacionada = new HashSet<ParteRelacionada>();
            Pessoa_Qualificada = new HashSet<Pessoa_Qualificada>();
            Procurador = new HashSet<Procurador>();
            Organograma = new HashSet<Organograma>();
        }

        public int Id { get; set; }

        public int Empresa_Id { get; set; }

        public bool PJ { get; set; }

        public long Documento { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public bool Estrangeiro { get; set; }

        public DateTime? DataDesativado { get; set; }

        public virtual Empresa Empresa { get; set; }

        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<Acionista> Acionista { get; set; }
        public virtual ICollection<Estatutario> Estatutario { get; set; }
        public virtual ICollection<ParteRelacionada> ParteRelacionada { get; set; }
        public virtual ICollection<Pessoa_Qualificada> Pessoa_Qualificada { get; set; }
        public virtual ICollection<Procurador> Procurador { get; set; }
        public virtual ICollection<Organograma> Organograma { get; set; }
    }
}