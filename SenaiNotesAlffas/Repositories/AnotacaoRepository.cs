using Microsoft.VisualBasic;
using SenaiNotesAlffas.Context;
using SenaiNotesAlffas.DTO;
using SenaiNotesAlffas.Interfaces;
using SenaiNotesAlffas.Models;
using SenaiNotesAlffas.ViewModels;

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
                Idstatus = anotacao.Idstatus,
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
            var listaDataAnotacoes = _context.Anotacoes.Where(d => d.CriadorAt == data).ToList();

            return listaDataAnotacoes;
        }

        public ListarAnotacaoViewModel ListarPorId(int id)
        {
            var anotacao = _context.Anotacoes.Find(id);
            if (anotacao == null)
            {
                return null;
            }

            var anotacaoId = new ListarAnotacaoViewModel
            {
                Idanotacoes = anotacao.Idanotacoes,
                Idusuario = anotacao.Idusuario,
                Titulo = anotacao.Titulo,
                Texto = anotacao.Texto,
                AtualizadorAt = anotacao.AtualizadorAt,
                Idstatus = anotacao.Idstatus,
            };

            return anotacaoId;
        }


        public object? Deletar(int id)
        {
            var categoria = _context.Anotacoes.Find(id);
            if (categoria == null) return null;
            return categoria;
        }

        public List<ListarAnotacaoViewModel> ListarTodos()
        {
            {
                return _context.Anotacoes.Select(a => new ListarAnotacaoViewModel
                {
                    Idanotacoes = a.Idanotacoes,
                    Idusuario = a.Idusuario,
                    Titulo = a.Titulo,
                    Texto = a.Texto,
                    AtualizadorAt = a.AtualizadorAt,
                    Idstatus = a.Idstatus,

                }).ToList();
            }

        }

    }
}
