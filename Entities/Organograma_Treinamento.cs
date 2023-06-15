using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace glasnost_back.Entities
{
    [Table("Organograma_Treinamento")]
    [Serializable]
    public partial class Organograma_Treinamento
    {
        public Organograma_Treinamento()
        {
            Organograma_Treinamento_Acesso = new HashSet<Organograma_Treinamento_Acesso>();
            Organograma_Treinamento_Envio = new HashSet<Organograma_Treinamento_Envio>();
        }

        public int Id { get; set; }

        public int Organograma_Id { get; set; }

        public int Treinamento_Id { get; set; }

        public DateTime? DataRealizacao { get; set; }

        public DateTime? DataVencimento { get; set; }

        public int? Acertos { get; set; }

        public DateTime? HoraComeco { get; set; }

        public DateTime? HoraFim { get; set; }

        public bool Pendente { get; set; }
        public bool? Ativo { get; set; }

        [NotMapped]
        public bool AcaoNegada { get; set; }

        [NotMapped]
        public int AcertosAcesso { get; set; }

        public virtual Organograma Organograma { get; set; }

        public virtual Treinamento Treinamento { get; set; }

        public ICollection<Organograma_Treinamento_Acesso> Organograma_Treinamento_Acesso { get; set; }
        public ICollection<Organograma_Treinamento_Envio> Organograma_Treinamento_Envio { get; set; }

    }

    [Table("Organograma_Treinamento_List")]
    public partial class Organograma_Treinamento_List
    {
        public int Id { get; set; }
        public int Cliente_Id { get; set; }
        public string Cliente { get; set; }
        public string Colaborador { get; set; }
        public string Funcao { get; set; }
        public string Treinamento { get; set; }
        public string Realizacao { get; set; }
        public string Validade { get; set; }

    }
}