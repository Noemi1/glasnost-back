using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace glasnost_back.Entities
{
    [Table("Pessoa_Qualificada_Qualificacao_Rel")]
    public class Pessoa_Qualificada_Qualificacao_Rel
    {
        public Pessoa_Qualificada_Qualificacao_Rel()
        {
            Pessoa_Qualificada_Qualificacao_Certificado = new HashSet<Pessoa_Qualificada_Qualificacao_Certificado>();
        }

        public int Id { get; set; }

        public int Pessoa_Qualificada_Id { get; set; }

        public int Pessoa_Qualificada_Qualificacao_Id { get; set; }

        public virtual Pessoa_Qualificada Pessoa_Qualificada { get; set; }

        public virtual Pessoa_Qualificada_Qualificacao Pessoa_Qualificada_Qualificacao { get; set; }

        public ICollection<Pessoa_Qualificada_Qualificacao_Certificado> Pessoa_Qualificada_Qualificacao_Certificado { get; set; }

    }
}
