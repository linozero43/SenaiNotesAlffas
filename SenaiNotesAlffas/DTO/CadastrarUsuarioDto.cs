namespace SenaiNotesAlffas.DTO
{
    public class CadastrarUsuarioDto
    {
        public string Nome { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Telefone { get; set; }

        public string Senha { get; set; } = null!;

    }
}
