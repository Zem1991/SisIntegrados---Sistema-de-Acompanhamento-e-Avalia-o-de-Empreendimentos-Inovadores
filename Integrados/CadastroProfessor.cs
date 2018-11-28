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
    public partial class CadastroProfessor : Form
    {
        private ProfessorRepositorio PR = new ProfessorRepositorio();
        private LoginRepositorio LR = new LoginRepositorio();

        public CadastroProfessor()
        {
            InitializeComponent();
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
            professor.PRValido = "S";

            try
            {
                PR.Adicionar(professor);
            }
            catch
            {
                Error erro = new Error();
                erro.GetError = "Não foi possível realizar sua operação - Valor Inválido em algum dos campos!";
                this.Hide();
                erro.Show();
            }
            

            LoginUsuarios login = new LoginUsuarios();
            login.LOLogin = professor.PRemail;
            login.LOSenha = professor.PRsenha;
            login.LOTipoUsuario = professor.PRtipoProfessor;

            LR.Adicionar(login);

            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void CadastroProfessor_Load(object sender, EventArgs e)
        {

        }
    }
}
