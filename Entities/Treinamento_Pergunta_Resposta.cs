using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("Treinamento_Pergunta_Resposta")]
    public class Treinamento_Pergunta_Resposta
    {

        public int Id { get; set; }

        public int Treinamento_Pergunta_Id { get; set; } 

        public string Resposta { get; set; }

        public bool Certo { get; set; }

        public virtual Treinamento_Pergunta Treinamento_Pergunta { get; set; }

    }
}