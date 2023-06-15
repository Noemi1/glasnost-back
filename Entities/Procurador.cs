namespace glasnost_back.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Procurador")]
    public partial class Procurador
    {
        public int Id { get; set; }

        public string Cargo { get; set; }

        public int Area_Id { get; set; }

        public int Pessoa_Id { get; set; }

        public int Cliente_Id { get; set; }

        public virtual Area Area { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Pessoa Pessoa { get; set; }

    }
}
