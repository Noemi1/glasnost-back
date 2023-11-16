using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace glasnost_back.Entities
{
    public class EmpresaCnae_Rel
    {
        public int Id { get; set; }

        public int Empresa_Id { get; set; }

        public int Cnae_Id { get; set; }

        public virtual EmpresaCnae Cnae { get; set; }

        public virtual Empresa Empresa { get; set; }

    }
}