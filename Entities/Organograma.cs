using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace glasnost_back.Entities
{
    [Table("Organograma")]
    public partial class Organograma
    {
        public Organograma()
        {
            OrgSubordinado = new HashSet<Organograma>();
            Organograma_Treinamento = new HashSet<Organograma_Treinamento>();
        }

        public int Id { get; set; }

        public int? Area_Id { get; set; }

        public bool Ativo { get; set; }

        public bool EhArea { get; set; }
 
        public int Cliente_Id { get; set; }

        public int? Cliente_Organograma_Id { get; set; }

        public int? Pessoa_Id { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public virtual Organograma OrgSuperior { get; set; }

        public virtual Area Area { get; set; }

        public virtual ICollection<Organograma> OrgSubordinado { get; set; }

        public virtual ICollection<Organograma_Treinamento> Organograma_Treinamento { get; set; }

        [NotMapped]
        public bool AcaoNegada { get; set; }
        
        [NotMapped]
        public string AreaNome { get; set; }
    }
}
