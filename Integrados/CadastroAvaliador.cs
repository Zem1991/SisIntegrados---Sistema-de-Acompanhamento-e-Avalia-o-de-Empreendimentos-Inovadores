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
    public partial class CadastroAvaliador : Form
    {
        private AvaliadorRepositorio AVR = new AvaliadorRepositorio();
        private LoginRepositorio LR = new LoginRepositorio();

        public CadastroAvaliador()
        {
            InitializeComponent();
        }

        private void CadastroAvaliador_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Avaliador avaliador = new Avaliador();

            avaliador.AVareaAtuacao = Area.Text;
            avaliador.AVemail = Email.Text;
            avaliador.AVformacao = Formacao.Text;
            avaliador.AVnome = Nome.Text;
            avaliador.AVsenha = Senha.Text;
            avaliador.AVValido = "S";

            

            try
            {
                AVR.Adicionar(avaliador);
            }
            catch
            {
                Error erro = new Error();
                erro.GetError = "Não foi possível realizar sua operação - Valor Inválido em algum dos campos!";
                this.Hide();
                erro.Show();
            }

            LoginUsuarios login = new LoginUsuarios();
            login.LOSenha = avaliador.AVsenha;
            login.LOLogin = avaliador.AVemail;
            login.LOTipoUsuario = 6;

            LR.Adicionar(login);

            Home home = new Home();
            this.Hide();
            home.Show();
        }
    }
}
