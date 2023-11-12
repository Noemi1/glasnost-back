using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("Denuncia")]
    public partial class Denuncia
    {
        public Denuncia()
        {
            Denuncia_Arquivo = new HashSet<Denuncia_Arquivo>();
            Denuncia_Denunciante = new HashSet<Denuncia_Denunciante>();
            Denuncia_Envolvido = new HashSet<Denuncia_Envolvido>();
            Denuncia_Historico_Status = new HashSet<Denuncia_Historico_Status>();
            Denuncia_Relatorio = new HashSet<Denuncia_Relatorio>();
        }

        public int Id { get; set; }

        public bool Anonima { get; set; }

        public DateTime DataEntrada { get; set; }

        public DateTime? DataEncerramento { get; set; }

        public string Relato { get; set; }

        public string Parecer { get; set; }

        public string Account_Id { get; set; }

        public int? Cliente_Id { get; set; }

        public int? DenunciaAcao_Id { get; set; }

        public int? DenunciaCanal_Id { get; set; }

        public int? DenunciaCategoria_Id { get; set; }

        public int? DenunciaGravidade_Id { get; set; }

        public int? DenunciaStatus_Id { get; set; }

        public int? DenunciaUrgencia_Id { get; set; }

        public int? DenunciaValidacao_Id { get; set; }

        public int? ClienteArea_Id { get; set; }

        public int Protocolo { get; set; }

        public bool Denuncia_Teste { get; set; }

        public DateTime? DataExclusao { get; set; }

        public virtual Account Account { get; set; }

        public virtual Area Area { get; set; }

        public virtual Empresa Cliente { get; set; }

        public virtual Denuncia_Acao Denuncia_Acao { get; set; }

        public virtual Denuncia_Canal Denuncia_Canal { get; set; }

        public virtual Denuncia_Categoria Denuncia_Categoria { get; set; }

        public virtual Denuncia_Gravidade Denuncia_Gravidade { get; set; }

        public virtual Denuncia_Status Denuncia_Status { get; set; }

        public virtual Denuncia_Urgencia Denuncia_Urgencia { get; set; }

        public virtual Denuncia_Validacao Denuncia_Validacao { get; set; }

        public virtual ICollection<Denuncia_Arquivo> Denuncia_Arquivo { get; set; }

        public virtual ICollection<Denuncia_Denunciante> Denuncia_Denunciante { get; set; }

        public virtual ICollection<Denuncia_Envolvido> Denuncia_Envolvido { get; set; }

        public virtual ICollection<Denuncia_Historico_Status> Denuncia_Historico_Status { get; set; }

        public virtual ICollection<Denuncia_Relatorio> Denuncia_Relatorio { get; set; }

    }
}
