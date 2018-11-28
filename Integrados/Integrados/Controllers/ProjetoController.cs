using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repositorio.Entidades;
using Repositorio.DAL.Repositorios.Base;
using Repositorio.DAL.Repositorios;


namespace Integrados.Controllers
{
    public class ProjetoController : Controller
    {
        private ProjetoRepositorio PR = new ProjetoRepositorio();
        private AlunoRepositorio ALR = new AlunoRepositorio();
        private ProfessorRepositorio PRR = new ProfessorRepositorio();
        private AvaliadorRepositorio AVR = new AvaliadorRepositorio();

        // GET: /Projeto/
        public ActionResult Index()
        {
            if (Session["tipoUsuario"] == null)
            {
                return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Faça seu login no sistema antes de acessar recursos" });
            }
            try
            {
                var projeto = PR.BuscarTodos();
                return View(projeto);
            }

            catch (Exception e)
            {
                ViewBag.Exception = e.ToString();
                return View();
            }
        }

        // GET: /Projeto/Details/5
        public ActionResult Detalhes(int? id)
        {
            //if (usuario.LOTipoUsuario != null) //  qualquer um logado pode acessar
            //{
            try
            {
                Projeto projeto = PR.BuscarPorID(id);
                return View(projeto);
            }

            catch (Exception e)
            {
                ViewBag.Exception = e.ToString();
            }
            //}
            return View();
        }

        // GET: /Projeto/Create
        public ActionResult Cadastrar()
        {
            ViewBag.PRorientador = new SelectList(PRR.BuscarTodosComCondicao(pr => pr.PRtipoProfessor == 3 || pr.PRtipoProfessor == 4), "PRIDprofessor", "PRNome");

            return View();
        }

        // POST: /Projeto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Projeto projeto)
        {
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 2 || LOTipoUsuario == 5) //   2 -> aluno lider , 5 -> adm
            {
                try
                {
                    int LOLogin = Int32.Parse((string)Session["LoginUsuario"]);

                    projeto.PRalunoLider = ALR.BuscarAlunoPorRA(LOLogin).ALIDaluno;

                    if (PR.BuscarAlunoLider(projeto.PRalunoLider) == null)
                    {

                        projeto.PRdescricao = "Resposta1;Resposta2;Resposta3;Resposta4;Resposta5;Resposta6;Resposta7;Resposta8";
                        projeto.PRStatusProjeto = "A";
                        PR.Adicionar(projeto);

                        Professor prof = new Professor();
                        prof = PRR.BuscarPorID(projeto.PRorientador);

                        prof.PRtipoProfessor = 4;
                        PRR.Atualizar(prof);

                        PR.RelacionarAlunoLiderProjeto(projeto.PRIDprojeto, projeto.PRalunoLider);
                        PR.RelacionarOrientadorProjeto(projeto.PRIDprojeto, projeto.PRorientador);
                    }
                    else
                    {
                        ViewBag.PRorientador = new SelectList(PRR.BuscarTodosComCondicao(pr => pr.PRtipoProfessor == 3 || pr.PRtipoProfessor == 4), "PRIDprofessor", "PRNome");
                        ViewBag.Exception = "O Aluno Lider já possui projeto ativo criado";
                        return View(projeto);
                    }


                    return RedirectToAction("Index");
                }

                catch (Exception e)
                {
                    ViewBag.PRorientador = new SelectList(PRR.BuscarTodosComCondicao(pr => pr.PRtipoProfessor == 3 || pr.PRtipoProfessor == 4), "PRIDprofessor", "PRNome");
                    ViewBag.Exception = e.ToString();
                    return View(projeto);
                }
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Aluno Lider ou Administradores tem acesso a esse recurso" });
        }

        // GET: /Projeto/Create
        public ActionResult Responder(int? id)
        {
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 2) //   2 -> aluno lider 
            {
                TempData["ProjetoID"] = id;
                return View();
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Aluno Lider tem acesso a esse recurso" });
        }

        // POST: /Projeto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Responder(FormCollection form)
        {
            Projeto projeto = new Projeto();
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 2) //   2 -> aluno lider 
            {
                try
                {
                    projeto.PRIDprojeto = Int32.Parse(TempData["ProjetoID"].ToString());

                    projeto = PR.BuscarPorID(projeto.PRIDprojeto);

                    projeto.PRdescricao = "";

                    var aux = "pergunta";
                    for (int i = 1 ; i < 10 ; i++ )
                    {
                        aux = "pergunta" + i;
                        if (form[aux] != null && !form[aux].Equals(""))
                        {
                            projeto.PRdescricao += form[aux] + ";";
                        }
                        if (form[aux] == null || form[aux].Equals(""))
                        {
                            projeto.PRdescricao += " " + ";";
                        }
                    }
                    projeto.PRStatusProjeto = "E";
                    projeto.PRComentarios = "";
                    PR.Atualizar(projeto);
                    return RedirectToAction("Index");
                }

                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                }
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Aluno Lider tem acesso a esse recurso" });
        }

        // GET: /Projeto/Edit/5
        public ActionResult Editar(int? id)
        {
            Projeto projeto = new Projeto();

            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 2) //  0 - 2 -> alunos
            {
                try
                {
                    projeto = PR.BuscarPorID(id);
                    return View(projeto);
                }
                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                    return View(projeto);
                }
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas o Aluno Lider tem acesso a esse recurso" });

        }

        // POST: /Projeto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Projeto projeto)
        {

            if (ModelState.IsValid)
            {
                int LOTipoUsuario = (Int32)Session["tipoUsuario"];
                if (LOTipoUsuario == 2) //  0 - 2 -> alunos
                {
                    try
                    {
                        PR.Atualizar(projeto);
                        return RedirectToAction("Index");
                    }

                    catch (Exception e)
                    {
                        ViewBag.Exception = e.ToString();
                    }
                }
                return View(projeto);
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas o Aluno Lider tem acesso a esse recurso" });
        }

        // GET: /Projeto/Delete/5
        public ActionResult Deletar(int id = 0)
        {
            Projeto projeto = new Projeto();

            try
            {
                projeto = PR.BuscarPorID(id);
                return View(projeto);
            }
            catch (Exception e)
            {
                ViewBag.Exception = e.ToString();
            }
            return View(projeto);
        }

        // POST: /Projeto/Delete/5
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projeto projeto = new Projeto();

            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario < 3 || LOTipoUsuario == 5) //  0 - 2 -> alunos , 5 -> administrador
            {
                try
                {
                    projeto = PR.BuscarPorID(id);

                    PR.DesRelacionarAlunoLiderProjeto(projeto.PRIDprojeto,projeto.PRalunoLider);
                    PR.DesRelacionarAlunoProjeto(projeto.PRIDprojeto);
                    PR.DesRelacionarAvaliadorProjeto(projeto.PRIDprojeto);
                    PR.DesRelacionarOrientadorProjeto(projeto.PRIDprojeto, projeto.PRorientador);
                    
                    PR.Excluir(projeto);
                    return RedirectToAction("Index");
                }

                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                    return View(projeto);
                }
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Alunos tem acesso a esse recurso" });
        }


        // GET: /Projeto/Create
        public ActionResult EscolherAvaliador(int id = 0)
        {
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5) //  0 - 2 -> alunos , 5 -> administrador
            {
                Avaliador ava = new Avaliador();
                ViewBag.PRavaliadorExterno = new SelectList(AVR.BuscarTodosComCondicao(av => av.AVValido.Equals("A")), "AVIDavaliador", "AVnome");

                Projeto projeto = new Projeto();
                projeto = PR.BuscarPorID(id);
                return View(projeto);
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas o Administrador tem acesso a esse recurso" });
        }

        // POST: /Projeto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EscolherAvaliador(FormCollection form)
        {
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5) //  5 -> adm
            {
                try
                {
                    Projeto projeto = new Projeto();

                    projeto = PR.BuscarPorID(Int32.Parse(form["PRIDprojeto"]));

                    projeto.PRavaliadorExterno = form["PRavaliadorExterno"].ToString();
                    PR.Atualizar(projeto);

                    Avaliador_Projeto avaliadorProjeto = new Avaliador_Projeto();
                    avaliadorProjeto.AVPRIDprojeto = Int32.Parse(form["PRIDprojeto"]);
                    avaliadorProjeto.AVPRIDavaliador = Int32.Parse(form["PRavaliadorExterno"]);

                    PR.RelacionarAvaliadorrProjeto(Int32.Parse(form["PRIDprojeto"]), Int32.Parse(form["PRavaliadorExterno"]));

                    return RedirectToAction("Index");
                }

                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                }
            }
            ViewBag.PRavaliadorExterno = new SelectList(AVR.BuscarTodosComCondicao(av => av.AVValido.Equals("A")), "AVIDavaliador", "AVnome");
            return View();
        }

        // GET: /Projeto/Create
        public ActionResult Comentar(int id = 0)
        {
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 1 || LOTipoUsuario == 4) //  1 -> aluno membro , 4 -> orientador
            {
                Projeto projeto = new Projeto();
                projeto = PR.BuscarPorID(id);

                if (projeto.PRdescricao.Equals(null) || projeto.PRdescricao.Equals(""))
                {
                    return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "O aluno lider deste projeto ainda não respondeu a nenhuma pergunta" });
                }
                string[] perguntas = projeto.PRdescricao.Split(';');

                ViewBag.pergunta1 = perguntas[0];
                ViewBag.pergunta2 = perguntas[1];
                ViewBag.pergunta3 = perguntas[2];
                ViewBag.pergunta4 = perguntas[3];
                ViewBag.pergunta5 = perguntas[4];
                ViewBag.pergunta6 = perguntas[5];
                ViewBag.pergunta7 = perguntas[6];
                ViewBag.pergunta8 = perguntas[7];

                return View(projeto);
            }
            return RedirectToAction("Entrar", "LoginUsuarios", new { erro = "Apenas Alunos Membros e o Professor Orientador tem acesso a esse recurso" });
        }

        // POST: /Projeto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Comentar(FormCollection form)
        {
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5) //  5 -> adm
            {
                try
                {
                    Projeto projeto = new Projeto();

                    projeto = PR.BuscarPorID(Int32.Parse(form["PRIDprojeto"]));



                    PR.Atualizar(projeto);
                    return RedirectToAction("Index");
                }

                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                }
            }
            ViewBag.PRavaliadorExterno = new SelectList(AVR.BuscarTodosComCondicao(av => av.AVValido.Equals("A")), "AVIDavaliador", "AVnome");
            return View();
        }


        public JsonResult Finalizar(int PRIDprojeto = 0)
        {
            var result = false;
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 2) //   2 -> aluno lider 
            {
                try
                {
                    Projeto projeto = new Projeto();

                    projeto = PR.BuscarPorID(PRIDprojeto);

                    projeto.PRStatusProjeto = "F";

                    PR.Atualizar(projeto);

                    result = true;
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                }
            }
            result = false;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Aprovar(int PRIDprojeto = 0)
        {
            var result = false;
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5) //   5 -> adm
            {
                try
                {
                    Projeto projeto = new Projeto();

                    projeto = PR.BuscarPorID(PRIDprojeto);

                    projeto.PRStatusProjeto = "P";

                    PR.Atualizar(projeto);

                    result = true;
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                }
            }
            result = false;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Reprovar(int PRIDprojeto = 0)
        {
            var result = false;
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario == 5) //   5 -> adm
            {
                try
                {
                    Projeto projeto = new Projeto();

                    projeto = PR.BuscarPorID(PRIDprojeto);

                    projeto.PRStatusProjeto = "R";

                    PR.Atualizar(projeto);

                    result = true;
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                }
            }
            result = false;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult JuntarAProjeto(int PRIDprojeto = 0)
        {
            var result = false;
            int LOTipoUsuario = (Int32)Session["tipoUsuario"];
            if (LOTipoUsuario < 2) //  0,  1 -> aluno membro ou sem projeto
            {
                try
                {
                    int LoginUsuario = (Int32)Session["LoginUsuario"];
                    Projeto projeto = new Projeto();

                    projeto = PR.BuscarPorID(PRIDprojeto);

                    PR.RelacionarAlunoProjeto(PRIDprojeto, LoginUsuario, projeto.PRalunoLider);

                    result = true;
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    ViewBag.Exception = e.ToString();
                }
            }
            result = false;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            try
            {
                ALR.Dispose();
                PR.Dispose();
                PRR.Dispose();
                AVR.Dispose();
            }
            catch (Exception e)
            {
                ViewBag.Exception = e.ToString();
            }
        }
    }
}
