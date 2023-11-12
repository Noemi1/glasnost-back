namespace glasnost_back.Models
{
    public class PessoaResponse
    {
        public int Id { get; set; }
        public int Empresa_Id { get; set; }
        public bool PJ { get; set; }
        public long Documento { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Estrangeiro { get; set; }
        public DateTime? DataDesativado { get; set; }
    }
}
