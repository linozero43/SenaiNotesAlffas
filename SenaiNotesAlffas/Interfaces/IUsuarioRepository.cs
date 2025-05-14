using SenaiNotesAlffas.Models;

namespace SenaiNotesAlffas.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> ListarTodos();

        void Cadastrar (Usuario usuario);

        Usuario? Atualizar(int id, Usuario usuario);

        Usuario? Deletar (int id);

        Usuario? ListarPorId(int id);
    }
}
