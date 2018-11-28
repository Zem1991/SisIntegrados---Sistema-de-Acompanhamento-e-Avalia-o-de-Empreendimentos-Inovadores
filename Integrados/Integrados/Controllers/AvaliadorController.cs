using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repositorio.DAL.Repositorios;
using Repositorio.Entidades;
using Repositorio.DAL.Repositorios.Base;


namespace Integrados.Controllers
{
    public class AvaliadorController : Controller
    {
        private AvaliadorRepositorio AVR = new AvaliadorRepositorio();
        private LoginRepositorio LR = new LoginRepositorio();
        private ProjetoRepositorio PR = new ProjetoRepositorio();
        // GET: /Avaliador/
        public ActionResult Index()
        {
            if (Session["tipoUsuario"] == null)
            {
                return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Faça seu login no sistema antes de acessar recursos" });
            }
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5) //  6 -> avaliador, 5 -> adm
            {
                try
                {
                    var avaliador = AVR.BuscarTodos();
                    return View(avaliador);
                }

                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                }
            }
            if (LOTipoUsuario == 6) //  6-> avaliador
            {
                string LoginUsuario = (string)Session["LoginUsuario"];
                return RedirectToAction("Detalhes", "Avaliador", new { id = AVR.BuscarAvaliadorPorEmail(LoginUsuario).AVIDavaliador });
            }
            return View();
        }

        // GET: /Avaliador/Details/5
        public ActionResult Detalhes(int id = 0)
        {
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];

            string LoginUsuario = (string)Session["LoginUsuario"];
            if (LOTipoUsuario == 5 || LOTipoUsuario == 6) //  6 -> avaliador, 5 -> adm
            {
                try
                {
                    Avaliador avaliador = new Avaliador();
                    if (id == 0)
                    {
                        avaliador = AVR.BuscarAvaliadorPorEmail(LoginUsuario);
                    }
                    else
                    {
                        avaliador = AVR.BuscarPorID(id);
                    }

                    if (avaliador.AVValido.Equals("N"))
                    {
                        ViewBag.Exception = "Seu Cadastro está inativo - Entre em contato com os administradores do sistema";
                        return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Seu Cadastro está inativo - Entre em contato com os administradores do sistema" });

                    }

                    return View(avaliador);
                }

                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                    return View();
                }
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Administradores já cadastrados tem acesso a esse recurso" });

        }

        // GET: /Avaliador/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: /Avaliador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Avaliador avaliador)
        {
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5 || LOTipoUsuario == 6) //  6 -> avaliador, 5 -> adm
            {
                try
                {
                    avaliador.AVValido = "N";
                    AVR.Adicionar(avaliador);

                    LoginUsuarios login = new LoginUsuarios();

                    login.LOLogin = avaliador.AVemail;
                    login.LOSenha = avaliador.AVsenha;
                    login.LOTipoUsuario = 6;

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
            return View();
        }

        // GET: /Avaliador/Edit/5
        public ActionResult Editar(int? id)
        {
            Avaliador avaliador = new Avaliador(); ;

            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5 || LOTipoUsuario == 6) //  6 -> avaliador, 5 -> adm
            {
                try
                {
                    avaliador = AVR.BuscarPorID(id); 
                    ViewBag.AVValido = ListasRepositorio.AtivoInativo();
                    return View(avaliador);
                }

                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                }
            }
            return View(avaliador);
        }

        // POST: /Avaliador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Avaliador avaliador)
        {
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5 || LOTipoUsuario == 6) //  6 -> avaliador, 5 -> adm
            {
                try
                {
                    AVR.Atualizar(avaliador);
                    return RedirectToAction("Index");
                }

                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                }
            }
            ViewBag.PRValido = ListasRepositorio.AtivoInativo();
            return View(avaliador);
        }

        // GET: /Avaliador/Delete/5
        public ActionResult Deletar(int? id)
        {
            Avaliador avaliador = new Avaliador();

            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5 || LOTipoUsuario == 6) //  6 -> avaliador, 5 -> adm
            {
                try
                {
                    avaliador = AVR.BuscarPorID(id);
                    return View(avaliador);
                }
                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                }
            }
            return View(avaliador);
        }

        // POST: /Avaliador/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Avaliador avaliador = new Avaliador();
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5 || LOTipoUsuario == 6) //  6 -> avaliador, 5 -> adm
            {
                try
                {
                    avaliador = AVR.BuscarPorID(id);

                    Avaliador_Projeto projeto = new Avaliador_Projeto();
                    projeto = PR.BuscarProjetosAvaliador(id);

                    if (projeto != null)
                    {
                        PR.DesRelacionarAvaliadorProjeto(projeto.AVPRIDprojeto);
                    }

                    AVR.Excluir(avaliador);
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
                AVR.Dispose();
            }
            catch (Exception e)
            {
                ViewBag.Exception = e.ToString();
            }
        }
    }
}
