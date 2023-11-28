namespace glasnost_back.Models
{
    public class EmpresaResponse
    {
        public int Id { get; set; }
        public long CNPJ { get; set; }
        public string RazaoSocial { get; set; } = string.Empty;
        public string NomeFantasia { get; set; } = String.Empty;
        public string? TelefoneComercial { get; set; }
        public string? Celular { get; set; }
        public string? Contato { get; set; }
        public string? Email { get; set; }
        public int Tipo_Id { get; set; }
        public bool DiligenciaPrevia { get; set; }
        public int RiscoCompliance_Id { get; set; }
        public string? EscopoResumido { get; set; }
        public int CEP { get; set; }
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;
        public List<int> Cnaes { get; set; } = new List<int>() { };
        public DateTime? DataDesativado { get; set; }
    }
}
