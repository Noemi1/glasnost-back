using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("Documento_Modelo")]
    public partial class Documento_Modelo
    {
        public Documento_Modelo()
        {
            Documento_Modelo_Anexo = new HashSet<Documento_Modelo_Anexo>();
        }
        [Key]
        public int Id { get; set; }

        public int Cliente_Id { get; set; }

        public int Documento_Tipo_Id { get; set; }

        public string IdAzure { get; set; }

        public string NomeAzure { get; set; }

        public virtual Empresa Cliente { get; set; }

        public virtual Documento_Tipo Documento_Tipo { get; set; }

        public virtual ICollection<Documento_Modelo_Anexo> Documento_Modelo_Anexo { get; set; }

    }
}