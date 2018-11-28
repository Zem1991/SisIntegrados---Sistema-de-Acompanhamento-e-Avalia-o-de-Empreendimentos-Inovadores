using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Repositorio.Entidades;

namespace Repositorio.DAL.Repositorios.Base
{
    public abstract class Repositorio<TEntity> : IDisposable,
       IRepositorio<TEntity> where TEntity : class
    {
        private IntegradosDBEntity db = new IntegradosDBEntity();

        public IQueryable<TEntity> BuscarTodos()
        {
            return db.Set<TEntity>();
        }
        
        public IQueryable<TEntity> BuscarTodosComCondicao(Func<TEntity, bool> predicate)
        {
            return BuscarTodos().Where(predicate).AsQueryable();
        }

        public TEntity BuscarPorID(params object[] key)
        {
            return db.Set<TEntity>().Find(key);
        }

        public void Atualizar(TEntity obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void SalvarTodos()
        {
            db.SaveChanges();
        }

        public void Adicionar(TEntity obj)
        {
            db.Set<TEntity>().Add(obj);
            db.SaveChanges();
        }

        public void Excluir(TEntity obj)
        {

            db.Set<TEntity>().Remove(obj);
            db.SaveChanges();
           
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}

