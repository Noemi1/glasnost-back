using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("Cliente_Responsavel")]
    public class Cliente_Responsavel
    {
        public Cliente_Responsavel()
        {

        }

        public int Id { get; set; }
        public int Cliente_Id { get; set; }
        public string Account_Id { get; set; }

        public virtual Account Account { get; set; }
        public virtual Cliente Cliente { get; set; }


    }
}