using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace glasnost_back.Models
{

    [Table("Cliente_Responsavel")]
    public class Cliente_Responsavel
    {
        public Cliente_Responsavel()
        {

        }
        public int Id { get; set; }
        public int Cliente_Id { get; set; }
        public string User_Id { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual AspNetUsers User { get; set; }


    }
}
