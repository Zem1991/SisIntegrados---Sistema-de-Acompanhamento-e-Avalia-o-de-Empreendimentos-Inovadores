using Repositorio.DAL.Repositorios;
using Repositorio.DAL.Repositorios.Base;
using Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integrados.Controllers
{
    public class LoginUsuariosController : Controller
    {
        private AlunoRepositorio ALR = new AlunoRepositorio();
        private ProfessorRepositorio PRR = new ProfessorRepositorio();
        private AvaliadorRepositorio AVR = new AvaliadorRepositorio();
        private TipoUsuarioRepositorio TUR = new TipoUsuarioRepositorio();
        private LoginRepositorio LR = new LoginRepositorio();


        public ActionResult Entrar(string erro = "")
        {
            if(!erro.Equals(""))
            {
                ViewBag.Exception = erro;
            }
            ViewBag.LOTipoUsuario = new SelectList(TUR.BuscarTodos(), "TUIDusuario", "TUdescricao");
            return View();
        }

        public JsonResult Logar(string LOLogin = "", string LOSenha = "", int LOTipoUsuario = 0)
        {
            var result = false;
            try
            {
                LoginUsuarios login = new LoginUsuarios();
                string LoginUsuario = LOLogin;
                string Senha = LOSenha;
                int tipoUsuario = LOTipoUsuario;

                var tu = TUR.BuscarTodosComCondicao(w => w.TUIDusuario == tipoUsuario);

                login.LOLogin = LoginUsuario;
                login.LOSenha = Senha;
                login.LOTipoUsuario = tipoUsuario;

                if (LR.VerificarLogin(LoginUsuario, Senha, tipoUsuario).LOLogin != null)//se for verdadeiro, guarda na seção
                {
                    Session["tipoUsuario"] = login.LOTipoUsuario;
                    Session["LoginUsuario"] = login.LOLogin;

                    result = true;
                    return Json(result, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception e)
            {
                ViewBag.Exception = e.ToString();
            }
            
            ViewBag.Exception = "Login ou Senha incorretas! Caso não esteja cadastrado no sistema, clique em Cadastrar";
            ViewBag.LOTipoUsuario = new SelectList(TUR.BuscarTodos(), "TUIDusuario", "TUdescricao");
            result = false;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Cadastrar()
        {
            ViewBag.LOTipoUsuario = new SelectList(TUR.BuscarTodos(), "TUIDusuario", "TUdescricao");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(FormCollection login)
        {
            try
            {
                if(login["LOTipoUsuario"] == null)
                {
                    ViewBag.Exception = "Selecione o seu tipo de usuário antes de clicar em cadastrar";
                    return View();
                }
                int tipoUsuario = Int32.Parse(login["LOTipoUsuario"]);

                if(tipoUsuario < 3)
                {
                    Session["tipoUsuario"] = tipoUsuario;
                    //usuário é um aluno
                    return RedirectToAction("Cadastrar", "Aluno");
                }
                if (tipoUsuario == 3 || tipoUsuario == 4)
                {
                    Session["tipoUsuario"] = tipoUsuario;
                    //usuário é um professor
                    return RedirectToAction("Cadastrar", "Professor");
                }
                if (tipoUsuario == 5)
                {
                    Session["tipoUsuario"] = tipoUsuario;
                    //usuário é um administrador
                    return RedirectToAction("Cadastrar", "Administrador");
                }
                if (tipoUsuario == 6)
                {
                    Session["tipoUsuario"] = tipoUsuario;
                    //usuário é um avaliador
                    return RedirectToAction("Cadastrar", "Avaliador");
                }
            }
            catch (Exception e)
            {
                ViewBag.Exception = e.ToString();
            }
            ViewBag.LOTipoUsuario = new SelectList(TUR.BuscarTodos(), "TUIDusuario", "TUdescricao");
            return View();
        }
    }
}