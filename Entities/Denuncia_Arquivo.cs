namespace glasnost_back.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class Denuncia_Arquivo
    {
        public int Id { get; set; }

        public int Denuncia_Id { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(75)]
        public string NomeAzure { get; set; }

        [StringLength(250)]
        public string IdAzure { get; set; }

        public virtual Denuncia Denuncia { get; set; }


    }
}
