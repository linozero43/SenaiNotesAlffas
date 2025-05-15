using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiNotesAlffas.DTO;
using SenaiNotesAlffas.Interfaces;
using SenaiNotesAlffas.Models;
using SenaiNotesAlffas.Repositories;

namespace SenaiNotesAlffas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_repository.ListarTodos());
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            var usuario = _repository.ListarPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarUsuarioDto usuario)
        {
            _repository.Cadastrar(usuario);
            return Created();
        }

        [HttpPut("{id}")]

        public IActionResult Editar(int id, CadastrarUsuarioDto usuario)
        {
            var usuarioAtualizado = _repository.Atualizar(id, usuario);

            if (usuarioAtualizado == null)
            {
                return NotFound();
            }

            return Ok(usuarioAtualizado);
        }


        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            var usuarioDeletado = _repository.Deletar(id);

            if (usuarioDeletado == null)
            {
                return NotFound();
            }

            return Ok(usuarioDeletado);


        }
    }

}
