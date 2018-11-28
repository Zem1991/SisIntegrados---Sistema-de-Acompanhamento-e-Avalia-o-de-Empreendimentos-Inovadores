using System;
using System.Linq;

// interface para definir metodos padroes para todos os tipos de repositorio
namespace Repositorio.DAL.Repositorios.Base
{
    interface IRepositorio<TEntity> where TEntity : class
    { 
        // Buscar Todos Os Resultados
        IQueryable<TEntity> BuscarTodos();

        // Buscar Todos Os Resultados Com Condições. Ex.: BuscarTodosComCondicao(a => a.USNome.Equals('Klaus'))
        IQueryable<TEntity> BuscarTodosComCondicao(Func<TEntity, bool> predicate);

        // Buscar Por ID. Ex.: BuscarPorID(1)
        TEntity BuscarPorID(params object[] key);

        // Atualizar alterações feitas no objeto. Ex.: Atualizar(usuario)
        void Atualizar(TEntity obj);

        // Salvar todas as alterações. Ex.: 
        // Atualizar(usuario);
        // SalvarTodos();
        void SalvarTodos();


        // Adicionar um objeto da DB. Ex.: 
        // Adicionar(usuario);
        // SalvarTodos();
        void Adicionar(TEntity obj);


        // Excluir um objeto do DB. Ex.:
        // Usuario usuario = repositorio.BuscarPorID(id); 
        // repositorio.Excluir(c => c == cliente);
        void Excluir(TEntity obj);
    }
}
