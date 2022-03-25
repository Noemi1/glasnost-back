using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace glasnost_back.Models
{
    //[Table("AspNetUsers")]
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            //AspNetUserClaims = new HashSet<AspNetUserClaims>();
            //AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            Cliente_Responsavel = new HashSet<Cliente_Responsavel>();
            //Comunicado_AspNetUsers_Rel = new HashSet<Comunicado_AspNetUsers_Rel>();
            //Comunicado_Criacao = new HashSet<Comunicado>();
            //Comunicado_Envio = new HashSet<Comunicado>();
            //Denuncia = new HashSet<Denuncia>();
            //Denuncia_Relatorio = new HashSet<Denuncia_Relatorio>();

            //DocumentoCriados = new HashSet<Documento>();
            //DocumentoAprovados = new HashSet<Documento>();
            //DocumentoRevisados = new HashSet<Documento>();
            //Documento_Aprovacao = new HashSet<Documento_Aprovacao>();
            //DueDiligence_Consulta = new HashSet<DueDiligence_Consulta>();

            //Log = new HashSet<Log>();
            //Prospect = new HashSet<Prospect>();
            //Prospect_Arquivo = new HashSet<Prospect_Arquivo>();
            //Organograma_Treinamento_Envio = new HashSet<Organograma_Treinamento_Envio>();
            //Relatorio_Denuncias = new HashSet<Relatorio_Denuncias>();
        }

        public string Id { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public bool? Ativo { get; set; }

        public int? Pessoa_Id { get; set; }

        public int? Cliente_Id { get; set; }

        public Pessoa Pessoa { get; set; }

        public Cliente Cliente { get; set; }

        //public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }

        //public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }

        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }

        public virtual ICollection<Cliente_Responsavel> Cliente_Responsavel { get; set; }

        //public virtual ICollection<Comunicado> Comunicado_Criacao { get; set; }

        //public virtual ICollection<Comunicado> Comunicado_Envio { get; set; }

        //public virtual ICollection<Denuncia> Denuncia { get; set; }

        //public virtual ICollection<Denuncia_Relatorio> Denuncia_Relatorio { get; set; }

        //public virtual ICollection<Documento> DocumentoCriados { get; set; }

        //public virtual ICollection<Documento> DocumentoRevisados { get; set; }

        //public virtual ICollection<Documento> DocumentoAprovados { get; set; }

        //public virtual ICollection<Documento_Aprovacao> Documento_Aprovacao { get; set; }

        //public virtual ICollection<DueDiligence_Consulta> DueDiligence_Consulta { get; set; }

        //public virtual ICollection<Log> Log { get; set; }

        //public virtual ICollection<Organograma_Treinamento_Envio> Organograma_Treinamento_Envio { get; set; }

        //public virtual ICollection<Prospect> Prospect { get; set; }

        //public virtual ICollection<Prospect_Arquivo> Prospect_Arquivo { get; set; }

        //public virtual ICollection<Relatorio_Denuncias> Relatorio_Denuncias { get; set; }

        //public virtual ICollection<Comunicado_AspNetUsers_Rel> Comunicado_AspNetUsers_Rel { get; set; }

        [NotMapped]
        public virtual ICollection<AspNetRoles> roles { get; set; }


    }
}
