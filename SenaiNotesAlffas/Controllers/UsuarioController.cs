using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiNotesAlffas.Context;
using SenaiNotesAlffas.DTO;
using SenaiNotesAlffas.Interfaces;
using SenaiNotesAlffas.Models;
using SenaiNotesAlffas.Repositories;
using SenaiNotesAlffas.Services;
using SenaiNotesAlffas.ViewModels;
using Swashbuckle.AspNetCore.Annotations;

namespace SenaiNotesAlffas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        private readonly NoteSenaiContext _context;

       
        public UsuarioController(IUsuarioRepository repository, NoteSenaiContext context)
        {
            _repository = repository;
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar usuários",
            Description = "Lista os usuários cadastrados no sistema."
            )]
        public IActionResult ListarTodos()
        {
            return Ok(_repository.ListarTodos());
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Listar usuário pelo ID",
            Description = "Retorna o usuário correspondente ao ID informado"
            )]
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
        [SwaggerOperation(
            Summary = "Cadastrar usuário",
            Description = "Cadastra usuário no sistema"
            )]
        public IActionResult Cadastrar(CadastrarUsuarioDto usuario)
        {
            try
            {
                _repository.Cadastrar(usuario);
                return Created();
            }
            catch (EmailJaCadastradoException)
            {
                return Conflict("E-mail informado já está cadastrado.");
            }
            
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Editar usuário",
            Description = "Permite alterar informações do usuário no sistema, a partir de seu ID"
            )]

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
        [SwaggerOperation(
            Summary = "Deletar usuário",
            Description = "Deleta o usuário do sistema, a partir do ID informado"
            )]

        public IActionResult Deletar(int id)
        {
            var usuarioDeletado = _repository.Deletar(id);

            if (usuarioDeletado == null)
            {
                return NotFound();
            }

            return Ok(usuarioDeletado);


        }

        [HttpPost("login/{id}")]
        [SwaggerOperation(
            Summary = "Login de usuário",
            Description = "Confere e-mail e senha informados pelo usuário e caso ok, retorna token de acesso e usuário"
            )]

        public IActionResult Login(LoginDto login, int id)
        {
            var usuario = _repository.BuscarPorEmailSenha(login.Email, login.Senha);
            var usuarioEncontrado = _repository.ListarPorId(id);            

            if (usuario == null)
            {
                return Unauthorized("Email ou senha inválidos.");
            }

            var tokenService = new TokenService();

            var token = tokenService.GenerateToken(usuario.Email);

            var resposta = new List<object>{usuarioEncontrado, token};

            return Ok(resposta);
           
        }
    }

}
