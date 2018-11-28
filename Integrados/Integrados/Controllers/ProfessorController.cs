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
namespace Integrados.Controllers
{
    public class ProfessorController : Controller
    {
        private ProfessorRepositorio PRR = new ProfessorRepositorio();
        private TipoUsuarioRepositorio TUR = new TipoUsuarioRepositorio();
        private LoginRepositorio LR = new LoginRepositorio();
        private ProjetoRepositorio PR = new ProjetoRepositorio();

        // GET: /Professor/
        public ActionResult Index()
        {
            if (Session["tipoUsuario"] == null)
            {
                return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Faça seu login no sistema antes de acessar recursos" });
            }
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5) //  5 -> adm
            {
                try
                {
                    var professor = PRR.BuscarTodos();
                    return View(professor);
                }

                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                    return View();
                }
            }
            if (LOTipoUsuario == 3 || LOTipoUsuario == 4) //  3 4 -> professor
            {
                string LoginUsuario = (string)Session["LoginUsuario"];

                return RedirectToAction("Detalhes", "Professor", new { id = PRR.BuscarProfessorPorEmail(LoginUsuario).PRIDprofessor });
            }
            return View();

        }

        // GET: /Professor/Details/5
        public ActionResult Detalhes(int id = 0)
        {
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];

            string LoginUsuario = (string)Session["LoginUsuario"];

            if (LOTipoUsuario == 5 || LOTipoUsuario == 3 || LOTipoUsuario == 4) //  3 4 -> professor, 5 -> adm
            {
                try
                {
                    Professor professor = new Professor();
                    if (id == 0)
                    {
                        professor = PRR.BuscarProfessorPorEmail(LoginUsuario);
                    }
                    else
                    {
                        professor = PRR.BuscarPorID(id);
                    }

                    if (professor.PRValido.Equals("N"))
                    {
                        ViewBag.Exception = "Seu Cadastro está inativo - Entre em contato com os administradores do sistema";
                        return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Seu Cadastro está inativo - Entre em contato com os administradores do sistema" });

                    }

                    return View(professor);
                }

                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                }
            }
            return View();
        }

        // GET: /Professor/Create
        public ActionResult Cadastrar()
        {
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5 || LOTipoUsuario == 3 || LOTipoUsuario == 4) //  3 4 -> professor, 5 -> adm
            {
                ViewBag.PRtipoProfessor = new SelectList(TUR.BuscarTodosComCondicao(pr => pr.TUIDusuario >= 3 && pr.TUIDusuario < 5), "TUIDusuario", "TUdescricao");
                return View();
            }
            return RedirectToAction("Entrar", "Login", new { erro = "Apenas Administradores ou Professores tem acesso a esse recurso" });

        }

        // POST: /Professor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Professor professor)
        {

            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5 || LOTipoUsuario == 3 || LOTipoUsuario == 4) //  3 4 -> professor, 5 -> adm
            {
                try
                {
                    professor.PRValido = "N";
                    PRR.Adicionar(professor);

                    LoginUsuarios login = new LoginUsuarios();

                    login.LOLogin = professor.PRemail;
                    login.LOSenha = professor.PRsenha;
                    login.LOTipoUsuario = professor.PRtipoProfessor;

                    LR.Adicionar(login);

                    Session["tipoUsuario"] = login.LOTipoUsuario;
                    Session["LoginUsuario"] = login.LOLogin;

                    return RedirectToAction("Index");
                }

                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                }
            }

            ViewBag.PRtipoProfessor = new SelectList(TUR.BuscarTodosComCondicao(pr => pr.TUIDusuario >= 3 && pr.TUIDusuario < 5), "TUIDusuario", "TUdescricao");
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Administradores ou Professores tem acesso a esse recurso" });
        }

        // GET: /Professor/Edit/5
        public ActionResult Editar(int? id)
        {
            Professor professor = new Professor();

            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5 || LOTipoUsuario == 3 || LOTipoUsuario == 4) //  3 4 -> professor, 5 -> adm
            {
                try
                {
                    professor = PRR.BuscarPorID(id);
                    ViewBag.PRtipoProfessor = new SelectList(TUR.BuscarTodosComCondicao(pr => pr.TUIDusuario >= 3 && pr.TUIDusuario < 5), "TUIDusuario", "TUdescricao");
                    ViewBag.PRValido = ListasRepositorio.AtivoInativo();
                    return View(professor);
                }
                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                    ViewBag.PRtipoProfessor = new SelectList(TUR.BuscarTodosComCondicao(pr => pr.TUIDusuario >= 3 && pr.TUIDusuario < 5), "TUIDusuario", "TUdescricao");

                    return View(professor);
                }
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Administradores ou Professores tem acesso a esse recurso" });
        }

        // POST: /Professor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Professor professor)
        {
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5 || LOTipoUsuario == 3 || LOTipoUsuario == 4) //  3 4 -> professor, 5 -> adm
            {
                try
                {
                    PRR.Atualizar(professor);

                    LoginUsuarios login = new LoginUsuarios();

                    login = LR.BuscarLoginPorEmail(professor.PRemail);

                    login.LOLogin = professor.PRemail;
                    login.LOSenha = professor.PRsenha;
                    login.LOTipoUsuario = professor.PRtipoProfessor;

                    LR.Atualizar(login);

                    return RedirectToAction("Index");
                }

                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                    ViewBag.PRValido = ListasRepositorio.AtivoInativo();
                    ViewBag.PRtipoProfessor = new SelectList(TUR.BuscarTodosComCondicao(pr => pr.TUIDusuario >= 3 && pr.TUIDusuario < 5), "TUIDusuario", "TUdescricao");
                    return View(professor);
                }
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Administradores ou Professores tem Acesso a esse recurso" });
        }

        // GET: /Professor/Delete/5
        public ActionResult Deletar(int? id)
        {
            Professor professor = new Professor();

            try
            {
                professor = PRR.BuscarPorID(id);
                return View(professor);
            }
            catch (Exception e)
            {
                ViewBag.Exception = e.ToString();
            }
            return View(professor);
        }

        // POST: /Professor/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Professor professor = null;
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5 || LOTipoUsuario == 3 || LOTipoUsuario == 4) //  3 4 -> professor, 5 -> adm
            {
                try
                {
                    professor = PRR.BuscarPorID(id);


                    Orientador_Projeto projeto = new Orientador_Projeto();
                    projeto = PR.BuscarProjetosProfessor(id);

                    if (projeto != null)
                    {
                        PR.DesRelacionarOrientadorProjeto(projeto.ORPRIDprojeto, projeto.ORPRIDprofessor);
                    }

                    PRR.Excluir(professor);
                    return RedirectToAction("Index");
                }

                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();

                }
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Administradores ou Professores tem Acesso a esse recurso" });
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                PRR.Dispose();
                TUR.Dispose();
            }
            catch (Exception e)
            {
                ViewBag.Exception = e.ToString();
            }
        }
    }
}
