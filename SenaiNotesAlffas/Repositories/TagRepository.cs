using SenaiNotesAlffas.Context;
using SenaiNotesAlffas.Interfaces;
using SenaiNotesAlffas.Models;

namespace SenaiNotesAlffas.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly NoteSenaiContext _context;

        public TagRepository(NoteSenaiContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Tag tag)
        {
            throw new NotImplementedException();
        }

        public Tag BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Tag tag)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tag> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
