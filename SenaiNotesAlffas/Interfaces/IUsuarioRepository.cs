using SenaiNotesAlffas.DTO;
using SenaiNotesAlffas.Models;
using SenaiNotesAlffas.ViewModels;

namespace SenaiNotesAlffas.Interfaces
{
    public interface IUsuarioRepository
    {
        List<ListarUsuarioViewModel> ListarTodos();

        void Cadastrar (CadastrarUsuarioDto usuario);

        Usuario? Atualizar(int id, CadastrarUsuarioDto usuario);

        Usuario? Deletar (int id);

        ListarUsuarioViewModel? ListarPorId(int id);

        Usuario BuscarPorEmailSenha(string email, string senha);
    }
}
