using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Integrados
{
    public partial class Home : Form
    {
        private string loginUsuario;
        private int tipoUsuario;

        public string GetLogin
        {
            get { return loginUsuario; }
            set { loginUsuario = value; }
        }
        public int GetTipoUsuario
        {
            get { return tipoUsuario; }
            set { tipoUsuario = value; }
        }

        public Home()
        {
            InitializeComponent();
        }


        private void Administradores_btn_Click(object sender, EventArgs e)
        {

        }

        private void Avaliadores_Click(object sender, EventArgs e)
        {

        }

        private void Professores_Click(object sender, EventArgs e)
        {
            if (tipoUsuario == 3 || tipoUsuario == 4 || tipoUsuario == 5)
            {
                EditarProfessor editar = new EditarProfessor();
                editar.GetLogin = loginUsuario;
                this.Hide();
                editar.Show();
            }
            else
            {
                Error erro = new Error();
                erro.GetError = "Não foi possível realizar sua operação - Voce Não tem acesso a esse recurso!";
                this.Hide();
                erro.Show();
            }
        }

        private void Projetos_Click(object sender, EventArgs e)
        {
            ListaProjetos lista = new ListaProjetos();
            this.Hide();
            lista.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
