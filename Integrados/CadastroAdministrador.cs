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
    public partial class CadastroAdministrador : Form
    {
        private AdministradorRepositorio AR = new AdministradorRepositorio();
        private LoginRepositorio LR = new LoginRepositorio();

        public CadastroAdministrador()
        {
            InitializeComponent();
        }

        private void CadastroAdministrador_Load(object sender, EventArgs e)
        {

        }

        private void Cadastrar_Click(object sender, EventArgs e)
        {
            Administrador adm = new Administrador();

            adm.ADLogin = user.Text;
            adm.ADSenha = password.Text;

            try
            {
                AR.Adicionar(adm);
            }
            catch
            {
                Error erro = new Error();
                erro.GetError = "Não foi possível realizar sua operação - Valor Inválido em algum dos campos!";
                this.Hide();
                erro.Show();
            }
            

            LoginUsuarios login = new LoginUsuarios();
            login.LOLogin = adm.ADLogin;
            login.LOSenha = adm.ADSenha;
            login.LOTipoUsuario = 5;
            LR.Adicionar(login);

            Home home = new Home();
            this.Hide();
            home.Show();
        }
    }
}
