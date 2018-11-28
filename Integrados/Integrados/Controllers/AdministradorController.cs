using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repositorio.DAL.Repositorios.Base;
using Repositorio.Entidades;
using Repositorio.DAL.Repositorios;

namespace Integrados.Controllers
{
    public class AdministradorController : Controller
    {
        private AdministradorRepositorio ADMR = new AdministradorRepositorio();
        private LoginRepositorio LR = new LoginRepositorio();
        // GET: /Administrador/
        public ActionResult Index()
        {
            if (Session["tipoUsuario"] == null)
            {
                return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Administradores já cadastrados tem acesso a esse recurso" });
            }
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5) //  5 -> adm
            {
                try
                {
                    var administrador = ADMR.BuscarTodos();
                    return View(administrador);
                }

                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();

                }
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Administradores já cadastrados tem acesso a esse recurso" });
        }

        // GET: /Administrador/Details/5
        public ActionResult Detalhes(int? id)
        {
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5) //  5 -> adm
            {
                try
                {
                    Administrador administrador = ADMR.BuscarPorID(id);
                    return View(administrador);
                }

                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                }
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Administradores já cadastrados tem acesso a esse recurso" });
        }

        // GET: /Administrador/Create
        public ActionResult Cadastrar()
        {
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5) //  5 -> adm
            {
                return View();
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Administradores já cadastrados podem Cadastrar novos administradores" });
        }

        // POST: /Administrador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Administrador administrador)
        {
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5) //  5 -> adm
            {
                try
                {
                    ADMR.Adicionar(administrador);

                    LoginUsuarios login = new LoginUsuarios();

                    login.LOLogin = administrador.ADLogin;
                    login.LOSenha = administrador.ADSenha;
                    login.LOTipoUsuario = 5;

                    LR.Adicionar(login);

                    return RedirectToAction("Index");
                }

                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();

                }
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Administradores já cadastrados podem Cadastrar novos administradores" }); ;
        }

        // GET: /Administrador/Edit/5
        public ActionResult Editar(int? id)
        {
            Administrador administrador = new Administrador();

            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5) //  5 -> adm
            {
                try
                {
                    administrador = ADMR.BuscarPorID(id);
                    return View(administrador);
                }
                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                    return View(administrador);
                }
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Administradores já cadastrados tem acesso a esse recurso" });
        }

        // POST: /Administrador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Administrador administrador)
        {
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5) //  5 -> adm
            {
                try
                {
                    ADMR.Atualizar(administrador);
                    return RedirectToAction("Index");
                }

                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                    return View(administrador);
                }
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Administradores já cadastrados tem acesso a esse recurso" });
        }

        // GET: /Administrador/Delete/5
        public ActionResult Deletar(int? id)
        {
            Administrador administrador = new Administrador();
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5) //  5 -> adm
            {
                try
                {
                    administrador = ADMR.BuscarPorID(id);
                    return View(administrador);
                }
                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                }
                return View(administrador);
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Administradores já cadastrados tem acesso a esse recurso" });
        }

        // POST: /Administrador/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administrador administrador = new Administrador();
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5) //  5 -> adm
            {
                try
                {
                    administrador = ADMR.BuscarPorID(id);
                    ADMR.Excluir(administrador);
                    return RedirectToAction("Index");
                }

                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                }
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                ADMR.Dispose();
            }
            catch (Exception e)
            {
                ViewBag.Exception = e.ToString();
            }
        }
    }
}
