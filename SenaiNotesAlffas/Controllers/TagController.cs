﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiNotesAlffas.DTO;
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
        public IActionResult CadastrarTag(CadastrarTagDto tag)
        {
            //1-Coloco o Produto no Banco de Dados
            _tagRepository.Cadastrar(tag);
            //2-Retorno o resutado
            //201-Created
            return Created();
        }

        [HttpPut("editar/{id}")]
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
