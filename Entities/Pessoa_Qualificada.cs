namespace glasnost_back.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public class Pessoa_Qualificada
    {
        public Pessoa_Qualificada()
        {
            Pessoa_Qualificada_Qualificacao_Rel = new HashSet<Pessoa_Qualificada_Qualificacao_Rel>();
        }

        public int Id { get; set; }

        public string Cargo { get; set; }

        public int Area_Id { get; set; }

        public int Cliente_Id { get; set; }

        public int Pessoa_Id { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public virtual Area Area { get; set; }

        public virtual ICollection<Pessoa_Qualificada_Qualificacao_Rel> Pessoa_Qualificada_Qualificacao_Rel { get; set; }

    }
}
