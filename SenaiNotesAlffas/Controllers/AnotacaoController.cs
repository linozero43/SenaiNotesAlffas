using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiNotesAlffas.Context;
using SenaiNotesAlffas.Interfaces;
using SenaiNotesAlffas.Models;
using SenaiNotesAlffas.Repositories;

namespace SenaiNotesAlffas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnotacaoController : ControllerBase
    {
        private readonly NoteSenaiContext _context;
        private readonly IAnotacaoRepository _anotacaoRepository;

        public AnotacaoController(NoteSenaiContext context)
        {
            _context = context;
            _anotacaoRepository = new AnotacaoRepository(_context);
        }

        [HttpGet("/buscar{nome}")]
        public IActionResult BuscarPornome(string nome)

        {
            return Ok(_anotacaoRepository.BuscarAnotacaoPorNome(nome));
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_anotacaoRepository.BuscarPorId(id));
        }

        [HttpGet]
        public IActionResult ListarCliente()
        {
            return Ok(_anotacaoRepository.ListarTodos());
        }

        //POST
        [HttpPost]

        public IActionResult CadastrarAnotacao(Anotacao anotacao)
        {
            object? anotacao1 = null;
            _anotacaoRepository.Cadastrar(anotacao);
            return Created();
        }


    }
}
