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
     
    public class HomeController : Controller
    {
        private AlunoRepositorio ALR = new AlunoRepositorio();
        private ProfessorRepositorio PRR = new ProfessorRepositorio();
        private AvaliadorRepositorio AVR = new AvaliadorRepositorio();
        private TipoUsuarioRepositorio TUR = new TipoUsuarioRepositorio();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}