using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Web;

namespace glasnost_back.Entities
{
    [Table("Treinamento")]
    public partial class Treinamento
    {
        public Treinamento()
        {
            Treinamento_Area = new HashSet<Treinamento_Area>();
            Organograma_Treinamento = new HashSet<Organograma_Treinamento>();
            Treinamento_Pergunta = new HashSet<Treinamento_Pergunta>();
            Treinamento_Pagina = new HashSet<Treinamento_Pagina>();
            Treinamento_Cliente = new HashSet<Treinamento_Cliente_Rel>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public int PrazoValidadeEmMeses { get; set; }

        public bool Ativo { get; set; }

        public int TreinamentoTipo_Id { get; set; }

        public int? Cliente_Id { get; set; }

        public string LinkZoom { get; set; }

        public DateTime? Data { get; set; }

        public string NomeAzureMaterial { get; set; }

        public string IdAzureMaterial { get; set; }

        public string NomeAzureVideo { get; set; }

        public string IdAzureVideo { get; set; }

        public virtual Empresa Cliente { get; set; }

        public virtual Treinamento_Tipo Treinamento_Tipo { get; set; }

        public ICollection<Treinamento_Area> Treinamento_Area { get; set; }

        public ICollection<Organograma_Treinamento> Organograma_Treinamento { get; set; }

        public ICollection<Treinamento_Pergunta> Treinamento_Pergunta { get; set; }

        public ICollection<Treinamento_Pagina> Treinamento_Pagina { get; set; }

        public ICollection<Treinamento_Cliente_Rel> Treinamento_Cliente { get; set; }
    }
}