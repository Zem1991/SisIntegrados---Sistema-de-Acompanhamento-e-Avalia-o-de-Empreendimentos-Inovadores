using Repositorio.DAL.Repositorios.Base;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.DAL.Repositorios
{
    public class LoginRepositorio : Repositorio<LoginUsuarios>
    {
        private IntegradosDBEntity db = new IntegradosDBEntity();

        public LoginUsuarios VerificarLogin(string LoginUsuario, string Senha, int tipoUsuario)
        {
            //tipoUsuario < 3 -> aluno, 3 e 4 -> professor.  5 adm, 6 avaliador

            if(tipoUsuario < 3)
            {
                tipoUsuario = 1;
            }
            if(tipoUsuario == 3 || tipoUsuario == 4)
            {
                tipoUsuario = 3;
            }

            var query = db.LoginUsuarios.Where(c => c.LOLogin.Equals(LoginUsuario) && c.LOSenha.Equals(Senha) && c.LOTipoUsuario == tipoUsuario).FirstOrDefault();
            return query;
        }
        public LoginUsuarios BuscarLoginPorEmail(string Email)
        {
            var query = db.LoginUsuarios.Where(c => c.LOLogin.Equals(Email)).FirstOrDefault();
            return query;
        }
    }
}
