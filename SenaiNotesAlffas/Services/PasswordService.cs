using Microsoft.AspNetCore.Identity;
using SenaiNotesAlffas.Models;

namespace SenaiNotesAlffas.Services
{
    public class PasswordService
    {
        // PasswordHasher - Classe pronta do .Net - PBKDF2 algoritmo usado por essa classe
        private readonly PasswordHasher<Usuario> _hasher = new();

        //Método para gerar um Hash
        public string HashPassword(Usuario usuario)
        {
            return _hasher.HashPassword(usuario, usuario.Senha);
        }

        //Método para verificar o Hash
        public bool VerificarSenha(Usuario usuario, string senhaInformada)
        {
            var resultado = _hasher.VerifyHashedPassword(usuario, usuario.Senha, senhaInformada);
            //retorna verdadeiro se as hash forem iguais e falso caso sejam diferentes
            return resultado == PasswordVerificationResult.Success;
        }
    }
}
