using Repositorio.DAL.Repositorios.Base;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.DAL.Repositorios
{
    public class ProjetoRepositorio : Repositorio<Projeto>
    {
        private IntegradosDBEntity db = new IntegradosDBEntity();

        public void RelacionarAlunoLiderProjeto(int projetoID, int registroAcademico)
        {
            Aluno_Projeto alunoProjeto = new Aluno_Projeto();

            alunoProjeto.ALPRIDaluno = registroAcademico;
            alunoProjeto.ALPRIDprojeto = projetoID;
            alunoProjeto.ALPRAlunoLider = registroAcademico;

            db.Set<Aluno_Projeto>().Add(alunoProjeto);
            db.SaveChanges();
        }

        public void RelacionarAlunoProjeto(int projetoID, int registroAcademico, int alunoLider)
        {
            Aluno_Projeto alunoProjeto = new Aluno_Projeto();

            alunoProjeto.ALPRIDaluno = registroAcademico;
            alunoProjeto.ALPRIDprojeto = projetoID;
            alunoProjeto.ALPRAlunoLider = alunoLider;

            db.Set<Aluno_Projeto>().Add(alunoProjeto);
            db.SaveChanges();
        }
        public void RelacionarOrientadorProjeto(int projetoID, int professorID)
        {
            Orientador_Projeto orientador = new Orientador_Projeto();

            orientador.ORPRIDprofessor = professorID;
            orientador.ORPRIDprojeto = projetoID;

            db.Set<Orientador_Projeto>().Add(orientador);
            db.SaveChanges();
        }
        public void RelacionarAvaliadorrProjeto(int projetoID, int avaliadorID)
        {
            Avaliador_Projeto avaliador = new Avaliador_Projeto();

            avaliador.AVPRIDavaliador = avaliadorID;
            avaliador.AVPRIDprojeto = projetoID;

            db.Set<Avaliador_Projeto>().Add(avaliador);
            db.SaveChanges();
        }
        public Aluno_Projeto BuscarAlunoLider(int idAluno)
        {

            var query = db.Aluno_Projeto.Where(c => c.ALPRAlunoLider == idAluno).FirstOrDefault();

            var statusProjeto = db.Projeto.Where(p => p.PRStatusProjeto.Equals("A") || p.PRStatusProjeto.Equals("E")).FirstOrDefault();

            if (statusProjeto != null)
            {
                //aluno lider tem projeto ativo
                return query;
            }

            return null;
        }
        public Aluno_Projeto BuscarProjetosAluno(int idAluno)
        {
            var query = db.Aluno_Projeto.Where(c => c.ALPRIDaluno == idAluno).FirstOrDefault();
            return query;
        }
        public Avaliador_Projeto BuscarProjetosAvaliador(int avaliadorID)
        {
            var query = db.Avaliador_Projeto.Where(c => c.AVPRIDavaliador == avaliadorID).FirstOrDefault();
            return query;
        }
        public Orientador_Projeto BuscarProjetosProfessor(int professorID)
        {
            var query = db.Orientador_Projeto.Where(c => c.ORPRIDprofessor == professorID).FirstOrDefault();
            return query;
        }

        public void DesRelacionarAlunoLiderProjeto(int projetoID, int registroAcademico)
        {
            var query = db.Aluno_Projeto.Where(c => c.ALPRID == projetoID && c.ALPRAlunoLider == registroAcademico).FirstOrDefault();

            db.Set<Aluno_Projeto>().Remove(query);
            db.SaveChanges();
        }

        public void DesRelacionarAlunoProjeto(int? projetoID)
        {
            var alunosProjeto = db.Aluno_Projeto.Where(p => p.ALPRIDprojeto == projetoID).Select(a => a.ALPRIDaluno);

            foreach(var item in alunosProjeto)
            {
                var query = db.Aluno_Projeto.Where(c => c.ALPRID == projetoID && c.ALPRIDaluno == item.Value).FirstOrDefault();

                db.Set<Aluno_Projeto>().Remove(query);
                db.SaveChanges();
            }
            
        }
        public void DesRelacionarOrientadorProjeto(int projetoID, int professorID)
        {
            var query = db.Orientador_Projeto.Where(c => c.ORPRIDprojeto == projetoID && c.ORPRIDprofessor == professorID).FirstOrDefault();

            db.Set<Orientador_Projeto>().Remove(query);
            db.SaveChanges();
        }
        public void DesRelacionarAvaliadorProjeto(int projetoID)
        {
            var query = db.Avaliador_Projeto.Where(c => c.AVPRIDprojeto == projetoID).FirstOrDefault();

            db.Set<Avaliador_Projeto>().Remove(query);
            db.SaveChanges();
        }

    }
}
