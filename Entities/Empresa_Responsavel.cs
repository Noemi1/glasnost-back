using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    public class Empresa_Responsavel
    {
        public int Id { get; set; }
        public int Empresa_Id { get; set; }
        public string Account_Id { get; set; }

        public virtual Account Account { get; set; }
        public virtual Empresa Empresa { get; set; }


    }
}