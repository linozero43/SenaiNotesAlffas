using Microsoft.VisualBasic;
using SenaiNotesAlffas.Context;
using SenaiNotesAlffas.DTO;
using SenaiNotesAlffas.Interfaces;
using SenaiNotesAlffas.Models;

namespace SenaiNotesAlffas.Repositories
{
    public class AnotacaoRepository(NoteSenaiContext context) : IAnotacaoRepository
    {
        private readonly NoteSenaiContext _context = context;

        public Anotacao? Atualuzar(int id, CadastrarAnotacaoDto anotacao)
        {
            var anotacaoEncontrada = _context.Anotacoes.FirstOrDefault(c =>
            c.Idanotacoes == id);

            if (anotacaoEncontrada == null)
            {
                return null;
            }

            anotacaoEncontrada.Idusuario = anotacao.Idusuario;
            anotacaoEncontrada.Titulo = anotacao.Titulo;
            anotacaoEncontrada.Texto = anotacao.Texto;
    
            _context.SaveChanges();
            return anotacaoEncontrada;

        }

        public void Cadastrar(CadastrarAnotacaoDto anotacao)
        {

            Anotacao anotacaoCadastrada = new()
            {
                Idusuario = anotacao.Idusuario,
                Titulo = anotacao.Titulo,
                Texto = anotacao.Texto,
            };

            _context.Anotacoes.Add(anotacaoCadastrada);
            _context.SaveChanges();
            
        }

        public List<Anotacao> BuscarAnotacaoPorNome(string nome)
        {
            {
                var listaAnotacoes = _context.Anotacoes.Where( n => n.Titulo == nome).ToList();

                return listaAnotacoes;
            }
        }

        public List <Anotacao> BuscarData(DateTime data)
        {
            var listaDataAnotacoes = _context.Anotacoes.Where(d => d.CreatedAt == data).ToList();

            return listaDataAnotacoes;
        }

        public Anotacao BuscarPorId(int id)
        {
            return _context.Anotacoes.FirstOrDefault(a => a.Idanotacoes == id);
        }


        public object? Deletar(int id)
        {
            var categoria = _context.Anotacoes.Find(id);
            if (categoria == null) return null;
            return categoria;
        }

        public List<Anotacao> ListarTodos()
        {
            {
                return _context.Anotacoes.ToList();
            }

        }

    }
}
