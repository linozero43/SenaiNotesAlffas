using SenaiNotesAlffas.Context;
using SenaiNotesAlffas.Interfaces;
using SenaiNotesAlffas.Models;

namespace SenaiNotesAlffas.Repositories
{
    public class AnotacaoRepository : IAnotacaoRepository
    {
        private readonly NoteSenaiContext _context;

        public AnotacaoRepository (NoteSenaiContext context)
        {
            _context = context;
        }

        public void Atualuzar(int id, Anotacao amotacao)
        {
            throw new NotImplementedException();
        }

        public List<Anotacao> BuscarAnotacaoPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public Anotacao BuscarData(string data)
        {
            throw new NotImplementedException();
        }

        public Anotacao BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Anotacao anotacao)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Anotacao> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
