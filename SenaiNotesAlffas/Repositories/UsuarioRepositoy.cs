using SenaiNotesAlffas.Context;
using SenaiNotesAlffas.Interfaces;
using SenaiNotesAlffas.Models;

namespace SenaiNotesAlffas.Repositories
{
    public class UsuarioRepositoy : IUsuarioRepository
    {
        private readonly NoteSenaiContext _context;

        public UsuarioRepositoy(NoteSenaiContext context)
        {
            _context = context;
        }

        public Usuario? Atualizar(int id, Usuario usuario)
        {
            var usuarioEncontrado = _context.Usuarios.Find(id);

            if(usuarioEncontrado == null)
            {
                return null;
            }

            usuarioEncontrado.Nome = usuario.Nome;
            usuarioEncontrado.Email = usuario.Email;
            usuarioEncontrado.Telefone = usuario.Telefone;
            usuarioEncontrado.Senha = usuario.Senha;
            
            _context.SaveChanges();
            return usuarioEncontrado;

        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
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

        public Usuario? ListarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Idusuario == id);    
        }

        public List<Usuario> ListarTodos()
        {
            return _context.Usuarios.ToList();
        }
    }
}
