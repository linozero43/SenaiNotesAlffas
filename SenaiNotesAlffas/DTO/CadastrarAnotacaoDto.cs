using SenaiNotesAlffas.Models;

namespace SenaiNotesAlffas.DTO
{
    public class CadastrarAnotacaoDto
    {
        
        public int Idusuario { get; set; }

        public string Titulo { get; set; } = null!;

        public string? Texto { get; set; }

        public string Idstatus { get; set; } = null!;

    }
}
