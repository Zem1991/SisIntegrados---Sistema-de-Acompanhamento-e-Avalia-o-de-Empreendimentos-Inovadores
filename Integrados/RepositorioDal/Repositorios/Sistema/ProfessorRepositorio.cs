using Repositorio.DAL.Repositorios.Base;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.DAL.Repositorios
{
    public class ProfessorRepositorio : Repositorio<Professor>
    {
        private IntegradosDBEntity db = new IntegradosDBEntity();

        public Professor BuscarProfessorPorEmail(string Email)
        {
            var query = db.Professor.Where(c => c.PRemail.Equals(Email)).FirstOrDefault();
            return query;
        }
    }
}
