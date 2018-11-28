using Repositorio.DAL.Repositorios.Base;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.DAL.Repositorios
{
    public class AvaliadorRepositorio : Repositorio<Avaliador>
    {
        private IntegradosDBEntity db = new IntegradosDBEntity();

        public Avaliador BuscarAvaliadorPorEmail(string Email)
        {
            var query = db.Avaliador.Where(c => c.AVemail.Equals(Email)).FirstOrDefault();
            return query;
        }
    }
}
