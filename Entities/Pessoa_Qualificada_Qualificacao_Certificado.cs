using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace glasnost_back.Entities
{
    [Table("Pessoa_Qualificada_Qualificacao_Certificado")]
    public class Pessoa_Qualificada_Qualificacao_Certificado
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string IdAzure { get; set; }

        public string NomeAzure { get; set; }

        public int Pessoa_Qualificada_Qualificacao_Rel_Id { get; set; }

        public virtual Pessoa_Qualificada_Qualificacao_Rel Pessoa_Qualificada_Qualificacao_Rel { get; set; }


    }
}
