using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    public class Organograma_Treinamento_Envio
    {

        public int Id { get; set; }
        public int Organograma_Treinamento_Id { get; set; }
        public string Account_Id { get; set; }
        public DateTime Data { get; set; }

        public virtual Account Account_Organograma_Treinamento_Envio { get; set; }
        public virtual Organograma_Treinamento Organograma_Treinamento { get; set; }
    }


}