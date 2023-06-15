using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    [Table("Prospect")]
    public class Prospect
    {
        public Prospect()
        {
            Prospect_Arquivo = new HashSet<Prospect_Arquivo>();
        }

        public int Id { get; set; }

        public string RazaoSocial { get; set; }

        public string Fantasia { get; set; }

        public long CNPJ { get; set; }

        public string Observacoes { get; set; }

        public string Contato { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataFollowUp { get; set; }

        public string TermoIntencao_Pessoa { get; set; }

        public decimal? TermoIntencao_TxImplantacao { get; set; }

        public decimal? TermoIntencao_TxServico { get; set; }

        public int? TermoIntencao_DiaVencimento { get; set; }

        public DateTime? TermoIntencao_DataInicio { get; set; }

        public DateTime? TermoIntencao_DataAceite { get; set; }

        public string AspNetUser_Id { get; set; }

        public int Prospect_Status_Id { get; set; }

        public int Cidade_Id { get; set; }
        public string CanalVendasLead { get; set; }
        public string MensagemLead { get; set; }

        public virtual Cidade Cidade { get; set; }

        public virtual Prospect_Status Prospect_Status { get; set; }

        public ICollection<Prospect_Arquivo> Prospect_Arquivo { get; set; }

    }
}