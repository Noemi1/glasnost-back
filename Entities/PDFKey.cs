using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace glasnost_back.Entities
{
    [Table("PDFKey")]
    public class PDFKey
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public DateTime DataUtilizacao { get; set; }

    }
}