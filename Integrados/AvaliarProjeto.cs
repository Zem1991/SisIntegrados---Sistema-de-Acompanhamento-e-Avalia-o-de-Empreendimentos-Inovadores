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
    public partial class AvaliarProjeto : Form
    {
        private ProjetoRepositorio PR = new ProjetoRepositorio();
        private AlunoRepositorio ALR = new AlunoRepositorio();
        private ProfessorRepositorio PRR = new ProfessorRepositorio();
        private AvaliadorRepositorio AVR = new AvaliadorRepositorio();

        private int idProjeto;
        private string descricaoProjeto;
        private string valores;
        private int somatorio;

        public string GetValoresQuestao
        {
            get { return valores; }
            set { valores = value; }
        }
        public int GetSomatorio
        {
            get { return somatorio; }
            set { somatorio = value; }
        }
        public int GetIDProjeto
        {
            get { return idProjeto; }
            set { idProjeto = value; }
        }
        public string GetDescricaoProjeto
        {
            get { return descricaoProjeto; }
            set { descricaoProjeto = value; }
        }

        public AvaliarProjeto()
        {
            InitializeComponent();
        }

        private void AvaliarProjeto_Load(object sender, EventArgs e)
        {
            
            Projeto proj = new Projeto();

            try
            {
                proj = PR.BuscarPorID(idProjeto);
                if(proj == null)
                {
                    Error erro = new Error();
                    erro.GetError = "Não foi possível realizar sua operação - perguntas não foram respondidas pelo aluno";
                    this.Hide();
                    erro.Show();
                }
            }
            catch
            {
                
            }
            

            var respostas = proj.PRdescricao.Split(';');

            resposta1.Text = respostas[0];
            resposta2.Text = respostas[1];
            resposta3.Text = respostas[2];
            resposta4.Text = respostas[3];
            resposta5.Text = respostas[4];
            resposta6.Text = respostas[5];
            resposta7.Text = respostas[6];
            resposta8.Text = respostas[7];
        }

        private void Salvar_Click(object sender, EventArgs e)
        {
            Projeto proj = new Projeto();
            proj = PR.BuscarPorID(idProjeto);


            if(valores == null || valores.Equals(""))
            {
                valores = "1;1;1;1;1;1;1;1";
                somatorio = 8;
            }
            var valor = valores.Split(';');

            proj.PRnotaFinal = (Int32.Parse(nota1.Text) * Int32.Parse(valor[0]) + Int32.Parse(nota2.Text) * Int32.Parse(valor[1])
                + Int32.Parse(nota3.Text) * Int32.Parse(valor[2]) + Int32.Parse(nota4.Text) * Int32.Parse(valor[3])
                + Int32.Parse(nota5.Text) * Int32.Parse(valor[4]) + Int32.Parse(nota6.Text) * Int32.Parse(valor[5])
                + Int32.Parse(nota7.Text) * Int32.Parse(valor[6]) + Int32.Parse(nota8.Text) * Int32.Parse(valor[7])) / somatorio;

            try
            {
                PR.Atualizar(proj);
            }
            catch
            {
                Error erro = new Error();
                erro.GetError = "Não foi possível realizar sua operação - Valor Inválido em algum dos campos!";
                this.Hide();
                erro.Show();
            }
            

            this.Hide();

            ListaProjetos lista = new ListaProjetos();
            lista.Show();
        }

        private void nota1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void nota2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void nota3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void nota4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void nota5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void nota6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void nota7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void nota8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
