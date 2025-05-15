using Microsoft.EntityFrameworkCore;
using SenaiNotesAlffas.Context;
using SenaiNotesAlffas.DTO;
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
            Tag ntag = _context.Tags.Find(id);
            if (ntag == null)
            {
                throw new Exception();
            }
            ntag.Nome = tag.Nome;

            _context.SaveChanges(); ;
        }

        public Tag BuscarPorId(int id)
        {
            return _context.Tags.FirstOrDefault(t => t.Idtag == id);
        }

        public List<Tag> BuscarTagPorNome(string nome)
        {
            //Where - Traz todos que atendem EXATAMENTE uma Condição 
            var listaTags = _context.Tags.Where(t => t.Nome == nome).ToList();
            return listaTags;
        }

        public void Cadastrar(CadastrarTagDto tag)
        {
            Tag novaTag = new Tag
            {
                Nome = tag.Nome,
            };
        }

        public void Deletar(int id)
        {
            Tag t = _context.Tags.Find(id);
            // Caso não encontre o produto, lanço um erro
            if (t == null)
            {
                throw new Exception();
            }
            // Caso eu encontre o produto, removo ele
            _context.Tags.Remove(t);
            _context.SaveChanges();
        }

        public List<Tag> ListarTodos()
        {
            return _context.Tags.Include(p => p.Anotacoes).ToList();
        }
    }
}
