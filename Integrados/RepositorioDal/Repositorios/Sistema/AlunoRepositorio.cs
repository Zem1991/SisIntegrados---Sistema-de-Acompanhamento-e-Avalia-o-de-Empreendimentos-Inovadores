using Repositorio.DAL.Repositorios.Base;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.DAL.Repositorios
{
    public class AlunoRepositorio : Repositorio<Aluno>
    {
        private IntegradosDBEntity db = new IntegradosDBEntity();

        public Aluno BuscarAlunoPorRA(int RegistroAcademico)
        {
            var query = db.Aluno.Where(c => c.ALIDaluno.Equals(RegistroAcademico)).FirstOrDefault();
            return query;
        }
    }
}
