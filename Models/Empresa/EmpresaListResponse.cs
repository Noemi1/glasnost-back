namespace glasnost_back.Models
{
    public class EmpresaListResponse
    {
        public int Id { get; set; }
        public long CNPJ { get; set; }
        public string RazaoSocial { get; set; } = string.Empty;
        public DateTime? DataDesativado { get; set; }
    }
}
