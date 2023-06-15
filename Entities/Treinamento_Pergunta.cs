using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace glasnost_back.Entities
{
    [Table("Treinamento_Pergunta")]
    public class Treinamento_Pergunta
    {
        public Treinamento_Pergunta()
        {
            Treinamento_Pergunta_Resposta = new HashSet<Treinamento_Pergunta_Resposta>();

        }

        public int Id { get; set; }
        
        public string Pergunta { get; set; }

        public int Treinamento_Id { get; set; }

        public virtual Treinamento Treinamento { get; set; }

        public ICollection<Treinamento_Pergunta_Resposta> Treinamento_Pergunta_Resposta { get; set; }
    }
}