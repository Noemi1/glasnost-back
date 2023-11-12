using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace glasnost_back.Entities
{
    [Table("Area")]
    public partial class Area
    {
        public Area()
        {
            Estatutario = new HashSet<Estatutario>();
            Pessoa_Qualificada = new HashSet<Pessoa_Qualificada>();
            Procurador = new HashSet<Procurador>();
            Treinamento_Area = new HashSet<Treinamento_Area>();
            Organograma = new HashSet<Organograma>();
            Denuncia = new HashSet<Denuncia>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public ICollection<Estatutario> Estatutario { get; set; }

        public ICollection<Procurador> Procurador { get; set; }

        public ICollection<Treinamento_Area> Treinamento_Area { get; set; }

        public ICollection<Pessoa_Qualificada> Pessoa_Qualificada { get; set; }

        public ICollection<Organograma> Organograma { get; set; }

        public ICollection<Denuncia> Denuncia { get; set; }
    }
}