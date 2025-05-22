using SenaiNotesAlffas.Models;

namespace SenaiNotesAlffas.DTO
{
    public class CadastrarAnotacaoDto
    {

        public int Idusuario { get; set; }

        public int? Idtag { get; set; }

        public string Titulo { get; set; } = null!;

        public string? Texto { get; set; }

        public bool? Arquivado { get; set; }

        public DateTime? CriadorAt { get; set; }

        public DateTime? AtualizadorAt { get; set; }

        public List<string> Tags { get; set; } 

    }
}
