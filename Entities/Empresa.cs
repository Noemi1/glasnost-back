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
            Empresa_Cnae_Rel = new HashSet<Empresa_Cnae_Rel>();
            Pessoa = new HashSet<Pessoa>();
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

        public virtual ICollection<Empresa_Cnae_Rel> Empresa_Cnae_Rel { get; set; }
        public virtual ICollection<Pessoa> Pessoa { get; set; }



    }
    public class Endereco
    {
        public string logradouro { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }

    }

}
