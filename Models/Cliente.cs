using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace glasnost_back.Models
{
    [Table("Cliente")]
    public partial class Cliente
    {
        public Cliente()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
            //Acionista = new HashSet<Acionista>();
            Cliente_Cnae_Rel = new HashSet<Cliente_Cnae_Rel>();
            Cliente_Responsavel = new HashSet<Cliente_Responsavel>();
            //Comunicado = new HashSet<Comunicado>();
            //Denuncia = new HashSet<Denuncia>();
            //Documento = new HashSet<Documento>();
            //Documento_Modelo = new HashSet<Documento_Modelo>();
            //DueDiligence_Pessoa = new HashSet<DueDiligence_Pessoa>();
            //Estatutario = new HashSet<Estatutario>();
            //Organograma = new HashSet<Organograma>();
            Pessoa = new HashSet<Pessoa>();
            //ParteRelacionada = new HashSet<ParteRelacionada>();
            //Pessoa_Qualificada = new HashSet<Pessoa_Qualificada>();
            //Procurador = new HashSet<Procurador>();
            //Relatorio_Denuncias = new HashSet<Relatorio_Denuncias>();
            //Treinamento = new HashSet<Treinamento>();
            //Treinamento_Cliente = new HashSet<Treinamento_Cliente_Rel>();

        }

        public int Id { get; set; }

        public string CNPJ { get; set; }

        public string Nome { get; set; }

        public string Apelido { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string CEP { get; set; }

        public string Complemento { get; set; }

        public string IdAzureCronogramaImplantacao { get; set; }

        public string NomeAzureCronogramaImplantacao { get; set; }

        public string IdAzureLogo { get; set; }

        public string NomeAzureLogo { get; set; }

        public string EscopoResumido { get; set; }

        public string Email { get; set; }

        public string TelefoneComercial { get; set; }

        public string Celular { get; set; }

        public string Contato { get; set; }

        public bool DiligenciaPrevia { get; set; }

        public int RiscoCompliance_Id { get; set; }
        public int? Cliente_Tipo_Id { get; set; }
        public virtual Cliente_Tipo Cliente_Tipo { get; set; }
        public virtual Cliente_RiscoCompliance Cliente_RiscoCompliance { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }

        //public virtual ICollection<Acionista> Acionista { get; set; }
        public virtual ICollection<Cliente_Cnae_Rel> Cliente_Cnae_Rel { get; set; }
        public virtual ICollection<Cliente_Responsavel> Cliente_Responsavel { get; set; }

        //public virtual ICollection<Comunicado> Comunicado { get; set; }
        //public virtual ICollection<Denuncia> Denuncia { get; set; }
        //public virtual ICollection<Documento> Documento { get; set; }
        //public virtual ICollection<Documento_Modelo> Documento_Modelo { get; set; }
        //public virtual ICollection<DueDiligence_Pessoa> DueDiligence_Pessoa { get; set; }
        //public virtual ICollection<Estatutario> Estatutario { get; set; }
        //public virtual ICollection<Organograma> Organograma { get; set; }
        public virtual ICollection<Pessoa> Pessoa { get; set; }
        //public virtual ICollection<ParteRelacionada> ParteRelacionada { get; set; }
        //public virtual ICollection<Pessoa_Qualificada> Pessoa_Qualificada { get; set; }
        //public virtual ICollection<Procurador> Procurador { get; set; }
        //public virtual ICollection<Relatorio_Denuncias> Relatorio_Denuncias { get; set; }
        //public virtual ICollection<Treinamento> Treinamento { get; set; }
        //public virtual ICollection<Treinamento_Cliente_Rel> Treinamento_Cliente { get; set; }



        [NotMapped]
        public List<AspNetUsers> users_Responsaveis { get; set; }

        [NotMapped]
        public List<Cliente_Cnae> cnaes { get; set; }


    }
    public class Endereco
    {
        public string logradouro { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }

    }

}
