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
    public partial class QuantificarValor : Form
    {
        public QuantificarValor()
        {
            InitializeComponent();
        }

        private void darValor_Click(object sender, EventArgs e)
        {
            int somatiorio = Int32.Parse(Valor1.Text) + Int32.Parse(Valor2.Text) + Int32.Parse(Valor3.Text) + Int32.Parse(Valor4.Text)
                + Int32.Parse(Valor5.Text) + Int32.Parse(Valor6.Text) + Int32.Parse(Valor7.Text) + Int32.Parse(Valor8.Text);

            string valores = Valor1.Text + ";" + Valor2.Text + ";" + Valor3.Text + ";" + Valor4.Text + ";"
                + Valor5.Text + ";" + Valor6.Text + ";" + Valor7.Text + ";" + Valor8.Text + ";";

            ListaProjetos lista = new ListaProjetos();
            this.Hide();

            lista.GetValoresQuestao = valores;
            lista.GetSomatorio = somatiorio;
            lista.Show();
        }

        private void QuantificarValor_Load(object sender, EventArgs e)
        {
            
        }
        private void Valor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Valor2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Valor3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Valor4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Valor5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Valor6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Valor7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Valor8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
