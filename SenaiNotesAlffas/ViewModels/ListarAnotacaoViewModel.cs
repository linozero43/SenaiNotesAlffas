namespace SenaiNotesAlffas.ViewModels
{
    public class ListarAnotacaoViewModel
    {
        public int Idanotacoes { get; set; }

        public int Idusuario { get; set; }

        public List <ListarTagViewModel> listarTags { get; set; }

        public string Titulo { get; set; } = null!;

        public string? Texto { get; set; }
        public DateTime? AtualizadorAt { get; set; }
        public string Idstatus { get; set; } = null!;
    }
}
