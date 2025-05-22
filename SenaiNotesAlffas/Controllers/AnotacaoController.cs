using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiNotesAlffas.Context;
using SenaiNotesAlffas.DTO;
using SenaiNotesAlffas.Interfaces;
using SenaiNotesAlffas.Models;
using SenaiNotesAlffas.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace SenaiNotesAlffas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnotacaoController : ControllerBase
    {

        private readonly NoteSenaiContext _context;

        private IAnotacaoRepository _anotacaoRepository;

        public AnotacaoController(NoteSenaiContext context)
        {
            _context = context;
            _anotacaoRepository = new AnotacaoRepository(_context);

        }

        //POST
        [HttpPost ("Cadastrar")]

        public IActionResult CadastrarAnotacao(CadastrarAnotacaoDto anotacao)
        {
            _anotacaoRepository.Cadastrar(anotacao);
            return Created();
        }


        [HttpGet("Listar Todos")]
        public IActionResult ListarAnotacao()
        {
            return Ok(_anotacaoRepository.ListarTodos());
        }

        [HttpPut("Editar/{id}")]
        public IActionResult Editar(int id, CadastrarAnotacaoDto anotacao)
        {
            var anotacaoAtualizada = _anotacaoRepository.Atualuzar(id, anotacao);

            if (anotacaoAtualizada == null)
            {
                return NotFound();
            }

            return Ok(anotacaoAtualizada);
        }


        [HttpGet]
        [SwaggerOperation(Summary = "Buscar por nome",
            Description = "Esse endpoint busca uma anotação pelo nome"
            )]
        public IActionResult BuscarPornome(string nome)

        {
            return Ok(_anotacaoRepository.BuscarAnotacaoPorNome(nome));
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Buscar por id",
            Description = "Esse endpoint busca uma anotação pelo id"
            )]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_anotacaoRepository.ListarPorId(id));
        }


        
        [HttpDelete]

        public IActionResult Deletar(int id)
        {
            var anotacaoDeletada = _anotacaoRepository.Deletar(id);

            if (anotacaoDeletada == null)
            {
                return NotFound();
            }

            return Ok(anotacaoDeletada);


        }


    }
}
