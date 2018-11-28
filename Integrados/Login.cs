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
    public partial class Login : Form
    {
        private AlunoRepositorio ALR = new AlunoRepositorio();
        private ProfessorRepositorio PRR = new ProfessorRepositorio();
        private AvaliadorRepositorio AVR = new AvaliadorRepositorio();
        private TipoUsuarioRepositorio TUR = new TipoUsuarioRepositorio();
        private LoginRepositorio LR = new LoginRepositorio();

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'integradosDBDataSet.TipoUsuario' table. You can move, or remove it, as needed.
            this.tipoUsuarioTableAdapter.Fill(this.integradosDBDataSet.TipoUsuario);

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                LoginUsuarios log = new LoginUsuarios();
                string LoginUsuario = nomeUser.Text; //nomeUser é o nome do textBox
                string Senha = senha.Text;
                int tipoUsuario = Int32.Parse(tipoUser.SelectedValue.ToString()); //tipoUser é o nome do dropdownlist

                log.LOLogin = LoginUsuario;
                log.LOSenha = Senha;
                log.LOTipoUsuario = tipoUsuario;

                if (LR.VerificarLogin(LoginUsuario, Senha, tipoUsuario).LOLogin != null)//se for verdadeiro, guarda na seção
                {
                    Home home = new Home(); //redireciona para o Home
                    home.GetLogin = LoginUsuario; //passa os valores que quero que o home use
                    home.GetTipoUsuario = tipoUsuario;//passa os valores que quero que o home use

                    this.Hide();
                    home.Show();
                    //this.Close();
                }
            }
            catch (Exception a)
            {
                Error erro = new Error();
                erro.GetError = "Não foi possível realizar sua operação - Seu cadastro no Sistema não foi encontrado!";
                this.Hide();
                erro.Show();
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Cadastrar cadastrar = new Cadastrar();
            this.Hide();
            cadastrar.Show();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tipoUsuarioTableAdapter.FillBy(this.integradosDBDataSet.TipoUsuario);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void panelLogin_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
