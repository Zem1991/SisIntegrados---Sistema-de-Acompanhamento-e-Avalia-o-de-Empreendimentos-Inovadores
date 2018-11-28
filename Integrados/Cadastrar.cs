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
    public partial class Cadastrar : Form
    {
        public Cadastrar()
        {
            InitializeComponent();
        }

        private void Cadastrar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'integradosDBDataSet.TipoUsuario' table. You can move, or remove it, as needed.
            this.tipoUsuarioTableAdapter.Fill(this.integradosDBDataSet.TipoUsuario);

        }

        private void Cadastrar_btn_Click(object sender, EventArgs e)
        {
            if (tipoUser.SelectedIndex == 3 || tipoUser.SelectedIndex == 4)
            {
                CadastroProfessor cadastrar = new CadastroProfessor();
                this.Hide();
                cadastrar.Show();
            }
            if (tipoUser.SelectedIndex == 5)
            {
                CadastroAdministrador cadastrar = new CadastroAdministrador();
                this.Hide();
                cadastrar.Show();
            }
            if (tipoUser.SelectedIndex == 6)
            {
                CadastroAvaliador cadastrar = new CadastroAvaliador();
                this.Hide();
                cadastrar.Show();
            }
            else
            {

                Error erro = new Error();
                erro.GetError = "Não foi possível realizar sua operação - Voce Não pode se Cadastrar pelo Desktop - Tente acessar o portal WEB!";
                this.Hide();
                erro.Show();
            }
        }
    }
}
