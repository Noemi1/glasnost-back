using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace glasnost_back.Entities
{
    [Table("Treinamento_Area")]
    public partial class Treinamento_Area
    {
        public Treinamento_Area()
        {

        }

        public int Id { get; set; }

        public int Treinamento_Id { get; set; }

        public int Area_Id { get; set; }

        public virtual Area Area { get; set; }

        public virtual Treinamento Treinamento { get; set; }

    }
}
