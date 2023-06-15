using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("Documento")]
    public class Documento
    {
        public Documento()
        {
            Documento_Anexo = new HashSet<Documento_Anexo>();
            Documento_Aprovacao = new HashSet<Documento_Aprovacao>();
        }

        [Key]
        public int Id { get; set; }

        public int Cliente_Id { get; set; }

        public string UsuarioCriacao_Id { get; set; }
        public DateTime DataCriacao { get; set; }

        public string UsuarioRevisao_Id { get; set; }
        public DateTime? DataRevisao { get; set; }

        public string UsuarioAprovacao_Id { get; set; }
        public DateTime? DataAprovacao { get; set; }

        public DateTime? DataRevisaoPrevista { get; set; }
        public DateTime? DataAprovacaoPrevista { get; set; }

        public int Versao { get; set; }
        public string Numero { get; set; }

        public string IdAzure { get; set; }
        public string NomeAzure { get; set; }

        public string Nome { get; set; }

        public DateTime? DataContrato { get; set; }

        public int Documento_Tipo_Id { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Documento_Tipo Documento_Tipo { get; set; }

        public virtual Account UsuarioCriacao { get; set; }

        public virtual Account UsuarioRevisao { get; set; }

        public virtual Account UsuarioAprovacao { get; set; }

        public virtual ICollection<Documento_Aprovacao> Documento_Aprovacao { get; set; }

        public virtual ICollection<Documento_Anexo> Documento_Anexo  { get; set; }

    }
}