using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repositorio.Entidades;
using Repositorio.DAL.Repositorios.Base;
using Repositorio.DAL.Repositorios;

namespace Integrados
{
    public partial class EditarProfessor : Form
    {
        private ProfessorRepositorio PR = new ProfessorRepositorio();
        private LoginRepositorio LR = new LoginRepositorio();

        private string loginUsuario;

        public string GetLogin
        {
            get { return loginUsuario; }
            set { loginUsuario = value; }
        }

        public EditarProfessor()
        {
            InitializeComponent();
        }

        private void EditarProfessor_Load(object sender, EventArgs e)
        {
            Professor professor = new Professor();
           


            try
            {
                professor = PR.BuscarProfessorPorEmail(loginUsuario);
                if(professor == null)
                {
                    Error erro = new Error();
                    erro.GetError = "Não foi possível realizar sua operação";
                    this.Hide();
                    erro.Show();
                }
            }
            catch
            {
                
            }

            Nome.Text = professor.PRnome;
            Email.Text = professor.PRemail;
            Senha.Text =  professor.PRsenha;
            Departamento.Text = professor.PRdepartamento;
            Disciplina.Text = professor.PRdisciplinaPrincipal;          
        }

        private void Cadastrar_Click(object sender, EventArgs e)
        {
            Professor professor = new Professor();
            professor.PRnome = Nome.Text;
            professor.PRemail = Email.Text;
            professor.PRsenha = Senha.Text;
            professor.PRdepartamento = Departamento.Text;
            professor.PRdisciplinaPrincipal = Disciplina.Text;
            professor.PRtipoProfessor = 3;
            professor.PRValido = Stat.SelectedText.Substring(0, 1);


            try
            {
                PR.Atualizar(professor);
            }
            catch
            {
                Error erro = new Error();
                erro.GetError = "Não foi possível realizar sua operação - Informação Inválida em Algum dos Campos!";
                this.Hide();
                erro.Show();
            }
            

            LoginUsuarios login = new LoginUsuarios();
            login.LOLogin = professor.PRemail;
            login.LOSenha = professor.PRsenha;

            LR.Atualizar(login);

            Home home = new Home();
            this.Hide();
            home.Show();
        }
    }
}
