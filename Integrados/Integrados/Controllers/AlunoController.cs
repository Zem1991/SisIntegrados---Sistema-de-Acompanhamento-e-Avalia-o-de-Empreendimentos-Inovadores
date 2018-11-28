using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repositorio.Entidades;
using Repositorio.DAL.Repositorios;
using Repositorio.DAL.Repositorios.Base;
using Repositorio.Entidades;

namespace Integrados.Controllers
{
    public class AlunoController : Controller
    {
        private AlunoRepositorio ALR = new AlunoRepositorio();
        private TipoUsuarioRepositorio TUR = new TipoUsuarioRepositorio();
        private LoginRepositorio LR = new LoginRepositorio();
        private ProjetoRepositorio PR = new ProjetoRepositorio();

        // GET: /Aluno/
        public ActionResult Index()
        {
            if (Session["tipoUsuario"] == null)
            {
                return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Faça seu login no sistema antes de acessar recursos" });
            }
            try
            {
                int LOTipoUsuario = (Int32)Session["tipoUsuario"];
                if (LOTipoUsuario == 5) //  5 -> adm
                {
                    // aluno repositorio -> buscar AlunoPorLogin(usuario.LOLogin)
                    var aluno = ALR.BuscarTodos();
                    return View(aluno);
                }
                if (LOTipoUsuario < 3) //  0 - 2 -> aluno
                {
                    string LoginUsuario = (string)Session["LoginUsuario"];
                    return RedirectToAction("Detalhes", "Aluno", new { id = ALR.BuscarAlunoPorRA(Int32.Parse(LoginUsuario)).ALIDaluno });
                }
            }
            catch (Exception e)
            {
                ViewBag.Exception = e.ToString();
                
            }
            return View();
        }

        // GET: /Aluno/Details/5
        public ActionResult Detalhes(int id = 0)
        {
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];

            string LoginUsuario = (string)Session["LoginUsuario"];
            try
            {
                Aluno aluno = new Aluno();
                if (LOTipoUsuario < 3 || LOTipoUsuario == 5) // 0 a 3 -> aluno. 5 -> adm
                {
                    if (id == 0)
                    {
                        aluno = ALR.BuscarAlunoPorRA(Int32.Parse(LoginUsuario));
                    }
                    else
                    {
                        aluno = ALR.BuscarPorID(id);
                    }

                    return View(aluno);
                }
            }
            catch (Exception e)
            {
                ViewBag.Exception = e.ToString();
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Administradores ou Alunos já cadastrados tem acesso a esse recurso" });
        }

        // GET: /Aluno/Create
        public ActionResult Cadastrar()
        {
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario < 3 || LOTipoUsuario == 5) // 0 a 3 -> aluno. 5 -> adm
            {
                ViewBag.ALtipoAluno = new SelectList(TUR.BuscarTodosComCondicao(a => a.TUIDusuario < 3), "TUIDusuario", "TUdescricao");
                return View();
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Administradores ou Alunos tem acesso a esse recurso" });
        }

        // POST: /Aluno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Aluno aluno)
        {
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario < 3 || LOTipoUsuario == 5) // 0 a 2 -> aluno. 5 -> adm
            {
                try
                {

                    ALR.Adicionar(aluno);

                    LoginUsuarios login = new LoginUsuarios();
                    login.LOLogin = aluno.ALIDaluno.ToString();
                    login.LOSenha = aluno.ALsenha;
                    login.LOTipoUsuario = aluno.ALtipoAluno;

                    LR.Adicionar(login);

                    Session["tipoUsuario"] = login.LOTipoUsuario;
                    Session["LoginUsuario"] = login.LOLogin;

                    return RedirectToAction("Index");
                }

                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                }
                ViewBag.ALtipoAluno = new SelectList(TUR.BuscarTodosComCondicao(al => al.TUIDusuario <= 3), "TUIDusuario", "TUdescricao", aluno.ALtipoAluno);
                return View(aluno);
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Administradores ou Alunos já cadastrados tem acesso a esse recurso" });

        }

        // GET: /Aluno/Edit/5
        public ActionResult Editar(int? id)
        {
            Aluno aluno = new Aluno();

            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario < 3 || LOTipoUsuario == 5) // 0 a 2 -> aluno. 5 -> adm
            {
                try
                {
                    aluno = ALR.BuscarPorID(id);
                    ViewBag.ALtipoAluno = new SelectList(TUR.BuscarTodosComCondicao(al => al.TUIDusuario < 3), "TUIDusuario", "TUdescricao");
                    return View(aluno);
                }
                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                    return View(aluno);
                }
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Administradores ou Alunos já cadastrados tem acesso a esse recurso" });
        }

        // POST: /Aluno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Aluno aluno)
        {
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario < 3 || LOTipoUsuario == 5) // 0 a 3 -> aluno. 5 -> adm
            {
                try
                {
                    ViewBag.ALtipoAluno = new SelectList(TUR.BuscarTodosComCondicao(al => al.TUIDusuario < 3), "TUIDusuario", "TUdescricao");
                    ALR.Atualizar(aluno);
                    return RedirectToAction("Index");
                }

                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                    return View(aluno);
                }
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Administradores ou Alunos já cadastrados tem acesso a esse recurso" });
        }

        // GET: /Aluno/Delete/5
        public ActionResult Deletar(int? id)
        {
            Aluno aluno = new Aluno();

            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario < 3 || LOTipoUsuario == 5) // 0 a 3 -> aluno. 5 -> adm
            {
                try
                {
                    aluno = ALR.BuscarPorID(id);
                    return View(aluno);
                }

                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                    return View(aluno);
                }
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Administradores ou Alunos já cadastrados tem acesso a esse recurso" });
        }

        // POST: /Aluno/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluno aluno = new Aluno();
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario < 3 || LOTipoUsuario == 5) // 0 a 3 -> aluno. 5 -> adm
            {
                try
                {
                    aluno = ALR.BuscarPorID(id);

                    Aluno_Projeto projeto = new Aluno_Projeto();
                    projeto = PR.BuscarProjetosAluno(id);

                    if (projeto != null)
                    {
                        PR.DesRelacionarAlunoProjeto(projeto.ALPRIDaluno);
                    }

                    ALR.Excluir(aluno);
                    return RedirectToAction("Index");
                }

                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                    return View();
                }
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Administradores ou Alunos já cadastrados tem acesso a esse recurso" });
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                ALR.Dispose();
                TUR.Dispose();
            }
            catch (Exception e)
            {
                ViewBag.Exception = e.ToString();
            }
        }
    }
}
