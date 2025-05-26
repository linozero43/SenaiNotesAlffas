using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiNotesAlffas.DTO;
using SenaiNotesAlffas.Interfaces;
using SenaiNotesAlffas.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace SenaiNotesAlffas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private ITagRepository _tagRepository;

        public TagController(ITagRepository tag)
        {
            _tagRepository = tag;
        }


        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar todas as Tags",
            Description = "Lista as tags cadastradas pelo nome."
            )]
        public IActionResult Listar()
        {
            return Ok(_tagRepository.ListarTodos());
        }


        [HttpGet("/buscar/{nome}")]
        [SwaggerOperation(
            Summary = "Busca a Tag pelo nome",
            Description = "Lista todas as anotações que usam essa tag."
            )]
        public IActionResult BuscarTagPorNome(string nome)
        {
            return Ok(_tagRepository.BuscarTagPorNome(nome));
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Criar uma nova Tag",
            Description = "Cria uma tag apenas pelo nome."
            )]
        public IActionResult CadastrarTag(CadastrarTagDto tag)
        {
            //1-Coloco o Produto no Banco de Dados
            _tagRepository.Cadastrar(tag);
            //2-Retorno o resutado
            //201-Created
            return Created();
        }

        [HttpPut("editar/{id}")]
        [SwaggerOperation(
            Summary = "Edita o nome da Tag",
            Description = "Edita a tag pelo ID recebido."
            )]
        public IActionResult Editar(int id, CadastrarTagDto tag)
        {
            try
            {
                _tagRepository.Atualizar(id, tag);
                return Ok(tag);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deleta a Tag",
            Description = "Deleta a tag pelo ID recebido."
            )]
        public IActionResult Deletar(int id)
        {
            try
            {
                _tagRepository.Deletar(id);
                return NoContent();
            }
            //caso der erro 
            catch (ArgumentNullException ex)
            {
                return NotFound("Tag não encontrada");
            }
        }
    }
}
