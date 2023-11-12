namespace glasnost_back.Models
{
    public class PessoaListResponse
    {
        public int Id { get; set; }
        public bool PJ { get; set; }
        public long Documento { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime? DataDesativado { get; set; }
    }
}
