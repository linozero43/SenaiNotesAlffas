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
        private readonly ITagRepository _tagRepository = new TagRepository(context);

        public AnotacaoRepository(NoteSenaiContext context, ITagRepository tagRepository)
        {
            _context = context;
        }
        private readonly NoteSenaiContext _context = context;
        private object item;

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

        public CadastrarAnotacaoDto? CadastrarAnotacao(CadastrarAnotacaoDto anotacao)
        {
            //1 percorrer a lista de tags
            //2 verificar se a tag existe
            //3 se não existir, cadastrar a tag
            //4 adicionar a tag na anotacao
            List<int> idTags = new List<int>();

            foreach (var tag in anotacao.Tags)
            {

                var tagEncontrada = _tagRepository.BuscarTagPorNome(anotacao.Idusuario, item);

                if (tag == null)
                { 

                }

            }
            {
                
            }
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
        public Anotacao? ArquivarAnotacao(int id)
        {
            var anotacao = _context.Anotacoes.Find(id);
            if (anotacao is null) return null;

            anotacao.Arquivado = !anotacao.Arquivado;

            _context.SaveChanges();
            return anotacao;
        }

        public object? Deletar(int id)
        {
            var anotacaoDeletada = _context.Anotacoes.Find(id);

            if (anotacaoDeletada == null) return null;
           
            _context.Anotacoes.Remove(anotacaoDeletada);
            _context.SaveChanges();

            return anotacaoDeletada;
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
