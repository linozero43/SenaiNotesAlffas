using SenaiNotesAlffas.DTO;
using SenaiNotesAlffas.Models;

namespace SenaiNotesAlffas.Interfaces
{
    public interface ITagRepository
    {
        List<Tag> ListarTodos();

        Tag BuscarPorId(int id);

        void Cadastrar(CadastrarTagDto tag);

        void Atualizar(int id, Tag tag);

        void Deletar(int id);

        List<Tag> BuscarTagPorNome(string nome);
    }
}
