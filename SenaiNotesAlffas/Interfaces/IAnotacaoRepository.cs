using SenaiNotesAlffas.Models;

namespace SenaiNotesAlffas.Interfaces
{
    public interface IAnotacaoRepository
    {
        List<Anotacao> ListarTodos();
        Anotacao BuscarPorId(int id);
        List<Anotacao> BuscarData(DateTime data);
        void Cadastrar(Anotacao anotacao);
        Anotacao? Atualuzar(int id, Anotacao anotacao);
        public object? Deletar(int id);
        List<Anotacao> BuscarAnotacaoPorNome(string nome);
        
    }
}
