using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Models
{
    [Table("Pessoa")]
    public class Pessoa
    {
        public Pessoa()
        {
            //Acionista = new HashSet<Acionista>();
            AspNetUsers = new HashSet<AspNetUsers>();
            //Estatutario = new HashSet<Estatutario>();
            //ParteRelacionada = new HashSet<ParteRelacionada>();
            //Pessoa_Qualificada = new HashSet<Pessoa_Qualificada>();
            //Procurador = new HashSet<Procurador>();
            //Organograma = new HashSet<Organograma>();
        }

        public int Id { get; set; }

        public int Cliente_Id { get; set; }

        public bool PJ { get; set; }

        public long? CPFCNPJ { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public bool Estrangeiro { get; set; }

        public virtual Cliente Cliente { get; set; }

        //public virtual ICollection<Acionista> Acionista { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }

        //public virtual ICollection<Estatutario> Estatutario { get; set; }

        //public virtual ICollection<ParteRelacionada> ParteRelacionada { get; set; }

        //public virtual ICollection<Pessoa_Qualificada> Pessoa_Qualificada { get; set; }

        //public virtual ICollection<Procurador> Procurador { get; set; }

        //public virtual ICollection<Organograma> Organograma { get; set; }

       
    }
}