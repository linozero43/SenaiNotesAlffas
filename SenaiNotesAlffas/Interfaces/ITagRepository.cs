using SenaiNotesAlffas.DTO;
using SenaiNotesAlffas.Models;
using SenaiNotesAlffas.ViewModels;

namespace SenaiNotesAlffas.Interfaces
{
    public interface ITagRepository
    {

        Tag BuscarPorId(int id);

        List<ListarTagViewModel> ListarTodos();
        List<Tag> BuscarTagPorNome(string nome);

        void Cadastrar(CadastrarTagDto tag);

        void Atualizar(int id, CadastrarTagDto tag);

        void Deletar(int id);

    }
}
