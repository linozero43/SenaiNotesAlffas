using Microsoft.EntityFrameworkCore;
using SenaiNotesAlffas.Context;
using SenaiNotesAlffas.DTO;
using SenaiNotesAlffas.Interfaces;
using SenaiNotesAlffas.Models;
using SenaiNotesAlffas.ViewModels;

namespace SenaiNotesAlffas.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly NoteSenaiContext _context;

        public TagRepository(NoteSenaiContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, CadastrarTagDto tag)
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

        public List<ListarTagViewModel> ListarTodos()
        {
            return _context.Tags.Select(t => new ListarTagViewModel
            {
                Nome = t.Nome,

            }).ToList();
        }

        public Tag BuscarTagPorNome(string nome)
        {
            
            var listaTags = _context.Tags.FirstOrDefault(t => t.Nome == nome);

            return listaTags;
        }

        public void Cadastrar(CadastrarTagDto tag)
        {

            var novaTag = new Tag
            {
                Nome = tag.Nome,
            };
            _context.Tags.Add(novaTag);
            _context.SaveChanges();

        }

        public void Deletar(int id)
        {
            Tag t = _context.Tags.Find(id);
            // Caso não encontre o produto, lanço um erro
            if (t == null)
            {
                throw new ArgumentNullException();
            }
            // Caso eu encontre o produto, removo ele
            _context.Tags.Remove(t);
            _context.SaveChanges();
        }

    }
}
