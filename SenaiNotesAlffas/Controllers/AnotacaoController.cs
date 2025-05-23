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

        private IAnotacaoRepository _anotacaoRepository;

        public AnotacaoController(IAnotacaoRepository anotacaoRepository)
        {
            _anotacaoRepository = anotacaoRepository;

        }

        
        [HttpPost]
        [SwaggerOperation(Summary = "Cadastrar",
            Description = "Esse endpoint cadastra uma anotação"
            )]

        public IActionResult CadastrarAnotacao(CadastrarAnotacaoDto anotacao)
        {
            _anotacaoRepository.CadastrarAnotacao(anotacao);
            return Created();
        }


        [HttpGet]
        [SwaggerOperation(Summary = "Listar",
            Description = "Esse endpoint lista todas as anotações"
            )]
        public IActionResult ListarAnotacao()
        {
            return Ok(_anotacaoRepository.ListarTodos());
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Editar",
            Description = "Esse endpoint edita uma anotação"
            )]
        public IActionResult Editar(int id, CadastrarAnotacaoDto anotacao)
        {
            var anotacaoAtualizada = _anotacaoRepository.Atualuzar(id, anotacao);

            if (anotacaoAtualizada == null)
            {
                return NotFound();
            }

            return Ok(anotacaoAtualizada);
        }


        [HttpGet("Buscar/{nome}")]
        [SwaggerOperation(Summary = "BuscarPorNome",
            Description = "Esse endpoint busca uma anotação pelo nome"
            )]
        public IActionResult BuscarPornome(string nome)

        {
            return Ok(_anotacaoRepository.BuscarAnotacaoPorNome(nome));
        }

        [HttpPut("Arquivar/{id}")]
        [SwaggerOperation(Summary = "Arquivar",
            Description = "Esse endpoint arquiva uma anotação"
            )]
        public IActionResult ArquivarAnotacao(int id)
        {
            var anotacaoArquivada = _anotacaoRepository.ArquivarAnotacao(id);

            if (anotacaoArquivada == null)
            {
                return NotFound();
            }

            return Ok(anotacaoArquivada);

        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "BuscarPorId",
            Description = "Esse endpoint busca uma anotação pelo id"
            )]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_anotacaoRepository.ListarPorId(id));
        }
        
        [HttpDelete("Deletar/{id}")]
        [SwaggerOperation(Summary = "Deletar",
            Description = "Esse endpoint deleta uma anotação"
            )]
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
