using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    public class Comunicado_Account_Rel
    {
        public int Id { get; set; }
        public int Comunicado_Id { get; set; }
        public int Account_Id { get; set; }

        public virtual Comunicado Comunicado { get; set; }
        public virtual Account Account { get; set; }
    }
}