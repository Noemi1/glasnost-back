using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace glasnost_back.Entities
{
    public partial class Empresa
    {
        public Empresa()
        {
            Acionista = new HashSet<Acionista>();
            Account = new HashSet<Account>();
            Empresa_Cnae_Rel = new HashSet<Empresa_Cnae_Rel>();
            Empresa_Responsavel = new HashSet<Empresa_Responsavel>();
            Comunicado = new HashSet<Comunicado>();
            Denuncia = new HashSet<Denuncia>();
            Documento = new HashSet<Documento>();
            Documento_Modelo = new HashSet<Documento_Modelo>();
            DueDiligence_Pessoa = new HashSet<DueDiligence_Pessoa>();
            Estatutario = new HashSet<Estatutario>();
            Organograma = new HashSet<Organograma>();
            Pessoa = new HashSet<Pessoa>();
            ParteRelacionada = new HashSet<ParteRelacionada>();
            Pessoa_Qualificada = new HashSet<Pessoa_Qualificada>();
            Procurador = new HashSet<Procurador>();
            Relatorio_Denuncias = new HashSet<Relatorio_Denuncias>();
            Treinamento = new HashSet<Treinamento>();
            Treinamento_Cliente = new HashSet<Treinamento_Cliente_Rel>();
        }

        public int Id { get; set; }

        public long CNPJ { get; set; }

        public string RazaoSocial { get; set; } = String.Empty;

        public string NomeFantasia { get; set; } = String.Empty;

        public string Logradouro { get; set; } = String.Empty;

        public string Numero { get; set; } = String.Empty;

        public string Bairro { get; set; } = String.Empty;

        public string Cidade { get; set; } = String.Empty;

        public string Estado { get; set; } = String.Empty;

        public long CEP { get; set; }

        public string Complemento { get; set; } = String.Empty;

        public string IdAzureCronogramaImplantacao { get; set; } = String.Empty;

        public string NomeAzureCronogramaImplantacao { get; set; } = String.Empty;

        public string IdAzureLogo { get; set; } = String.Empty;

        public string NomeAzureLogo { get; set; } = String.Empty;

        public string EscopoResumido { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string TelefoneComercial { get; set; } = String.Empty;

        public string Celular { get; set; } = String.Empty;

        public string Contato { get; set; } = String.Empty;

        public bool DiligenciaPrevia { get; set; }

        public int RiscoCompliance_Id { get; set; }

        public int? Tipo_Id { get; set; }
        public DateTime? DataDesativado { get; set; }

        public virtual RiscoCompliance RiscoCompliance { get; set; }

        public virtual Empresa_Tipo Tipo { get; set; }

        public virtual ICollection<Acionista> Acionista { get; set; }
        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<Empresa_Cnae_Rel> Empresa_Cnae_Rel { get; set; }
        public virtual ICollection<Empresa_Responsavel> Empresa_Responsavel { get; set; }
        public virtual ICollection<Comunicado> Comunicado { get; set; }
        public virtual ICollection<Denuncia> Denuncia { get; set; }
        public virtual ICollection<Documento> Documento { get; set; }
        public virtual ICollection<Documento_Modelo> Documento_Modelo { get; set; }
        public virtual ICollection<DueDiligence_Pessoa> DueDiligence_Pessoa { get; set; }
        public virtual ICollection<Estatutario> Estatutario { get; set; }
        public virtual ICollection<Organograma> Organograma { get; set; }
        public virtual ICollection<Pessoa> Pessoa { get; set; }
        public virtual ICollection<ParteRelacionada> ParteRelacionada { get; set; }
        public virtual ICollection<Pessoa_Qualificada> Pessoa_Qualificada { get; set; }
        public virtual ICollection<Procurador> Procurador { get; set; }
        public virtual ICollection<Relatorio_Denuncias> Relatorio_Denuncias { get; set; }
        public virtual ICollection<Treinamento> Treinamento { get; set; }
        public virtual ICollection<Treinamento_Cliente_Rel> Treinamento_Cliente { get; set; }

    }
    public class Endereco
    {
        public string logradouro { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }

    }

}
