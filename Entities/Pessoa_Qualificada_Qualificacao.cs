using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace glasnost_back.Entities
{
    [Table("Pessoa_Qualificada_Qualificacao")]
    public class Pessoa_Qualificada_Qualificacao
    {
        public Pessoa_Qualificada_Qualificacao()
        {
            Pessoa_Qualificada_Qualificacao_Rel = new HashSet<Pessoa_Qualificada_Qualificacao_Rel>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public ICollection<Pessoa_Qualificada_Qualificacao_Rel> Pessoa_Qualificada_Qualificacao_Rel { get; set; }


    }
}
