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
    public partial class Error : Form
    {
        public Error()
        {
            InitializeComponent();
        }
        private string erro;
        public string GetError
        {
            get { return erro; }
            set { erro = value; }
        }

        private void Error_Load(object sender, EventArgs e)
        {
            msgErro.Text = erro;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            this.Hide();
            log.Show();
        }
    }
}
