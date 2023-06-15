using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace glasnost_back.Entities
{
    public partial class Denuncia_Historico_Status
    {
        public int Id { get; set; }

        public int Denuncia_Id { get; set; }

        public int Status_Id { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public virtual Denuncia Denuncia { get; set; }

        public virtual Denuncia_Status Denuncia_Status { get; set; }
    }
}
