using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiNotesAlffas.Interfaces;
using SenaiNotesAlffas.Models;

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
        public IActionResult Listar()
        {
            return Ok(_tagRepository.ListarTodos());
        }
        [HttpGet("/buscar/{nome}")]
        public IActionResult BuscarTagPorNome(string nome)
        {
            return Ok(_tagRepository.BuscarTagPorNome(nome));
        }
        [HttpPost]
        public IActionResult CadastrarTag(Tag tag)
        {
            //1-Coloco o Produto no Banco de Dados
            _tagRepository.Cadastrar(tag);
            //2-Retorno o resutado
            //201-Created
            return Created();
        }
        [HttpPut("{nome}")]
        public IActionResult Editar(int id, Tag tag)
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
        [HttpDelete("{nome}")]
        public IActionResult Deletar(int tag)
        {
            try
            {
                _tagRepository.Deletar(tag);
                return NoContent();
            }
            //caso der erro 
            catch (Exception ex)
            {
                return NotFound("Tag não encontrada");
            }
        }
    }
}
