using Microsoft.AspNetCore.Http.HttpResults;
using SenaiNotesAlffas.Context;
using SenaiNotesAlffas.DTO;
using SenaiNotesAlffas.Interfaces;
using SenaiNotesAlffas.Models;
using SenaiNotesAlffas.Services;
using SenaiNotesAlffas.ViewModels;

namespace SenaiNotesAlffas.Repositories
{
    public class UsuarioRepositoy : IUsuarioRepository
    {
        private readonly NoteSenaiContext _context;

        public UsuarioRepositoy(NoteSenaiContext context)
        {
            _context = context;
        }

        public Usuario? Atualizar(int id, CadastrarUsuarioDto usuario)
        {
            var usuarioEncontrado = _context.Usuarios.Find(id);

            var password = new PasswordService();

            if (usuarioEncontrado == null)
            {
                return null;
            }

            usuarioEncontrado.Nome = usuario.Nome;
            usuarioEncontrado.Email = usuario.Email;
            usuarioEncontrado.Telefone = usuario.Telefone;
            usuarioEncontrado.Senha = usuario.Senha;

            usuarioEncontrado.Senha = password.HashPassword(usuarioEncontrado);

            _context.SaveChanges();
            return usuarioEncontrado;

        }

        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            var usuarioEncontrado = _context.Usuarios.FirstOrDefault(u => u.Email == email);

            if(usuarioEncontrado == null)
            {
                return null;
            }

            var passwordService = new PasswordService();

            //verificar se a senha do usuario retorna o mesmo hash
            var resultado = passwordService.VerificarSenha(usuarioEncontrado, senha);

            if (resultado == true)
            {
                return usuarioEncontrado;
            }

            return null;
        }



        public void Cadastrar(CadastrarUsuarioDto usuario)
        {
            var password = new PasswordService();

            Usuario usuarioCadastrado = new Usuario
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                Senha = usuario.Senha
            };

            usuarioCadastrado.Senha = password.HashPassword(usuarioCadastrado);

            //tratar erro quando email cadastrado ja existe, firstordefault
            var emailCadastrado = _context.Usuarios.FirstOrDefault(u => u.Email ==  usuario.Email);
            
            if(emailCadastrado != null)
            {
                throw new EmailJaCadastradoException("");
            }

            _context.Usuarios.Add(usuarioCadastrado);
            _context.SaveChanges();
        }

        public Usuario? Deletar(int id)
        {
            var usuarioEncontrado = _context.Usuarios.Find(id);

            if (usuarioEncontrado == null)
            {
                return null;
            }

            _context.Usuarios.Remove(usuarioEncontrado);
            _context.SaveChanges();

            return usuarioEncontrado;
        }

        public ListarUsuarioViewModel? ListarPorId(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return null;
            }

            var usuarioId =  new ListarUsuarioViewModel
            {
                Idusuario = usuario.Idusuario,
                Nome = usuario.Nome,
                Telefone = usuario.Telefone,
                Email = usuario.Email
            };

            return usuarioId;
        }

        public List<ListarUsuarioViewModel> ListarTodos()
        {
            return _context.Usuarios.Select(u => new ListarUsuarioViewModel
            {
                Idusuario = u.Idusuario,
                Nome = u.Nome,
                Telefone = u.Telefone,
                Email = u.Email
            }).ToList();
        }
    }
}
