using SenaiNotesAlffas.DTO;
using SenaiNotesAlffas.Models;

namespace SenaiNotesAlffas.Interfaces
{
    public interface IAnotacaoRepository
    {
        List<Anotacao> ListarTodos();
        Anotacao BuscarPorId(int id);
        List<Anotacao> BuscarData(DateTime data);
        void Cadastrar(CadastrarAnotacaoDto anotacao);
        Anotacao? Atualuzar(int id, CadastrarAnotacaoDto anotacao);
        public object? Deletar(int id);
        List<Anotacao> BuscarAnotacaoPorNome(string nome);
        
    }
}
