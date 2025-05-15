using SenaiNotesAlffas.Models;

namespace SenaiNotesAlffas.Interfaces
{
    public interface IAnotacaoRepository
    {
        List<Anotacao> ListarTodos();
        Anotacao BuscarPorId(int id);
        Anotacao BuscarData(DateTime data);

        void Cadastrar(Anotacao anotacao);

        void Atualuzar(int id, Anotacao amotacao);
 
        void Deletar(int id);
        List<Anotacao> BuscarAnotacaoPorNome(string nome);
    }
}
