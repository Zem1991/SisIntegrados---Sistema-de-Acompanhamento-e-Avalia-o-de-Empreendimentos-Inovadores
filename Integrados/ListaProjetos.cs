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
    public partial class ListaProjetos : Form
    {
        private ProjetoRepositorio PR = new ProjetoRepositorio();
        private AlunoRepositorio ALR = new AlunoRepositorio();
        private ProfessorRepositorio PRR = new ProfessorRepositorio();
        private AvaliadorRepositorio AVR = new AvaliadorRepositorio();

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

        public ListaProjetos()
        {
            InitializeComponent();
        }

        private void ListaProjetos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'integradosDBDataSet.Projeto' table. You can move, or remove it, as needed.
            this.projetoTableAdapter.Fill(this.integradosDBDataSet.Projeto);

        }

        private void Comentar_Click(object sender, EventArgs e)
        {
            ComentarProjeto comentar = new ComentarProjeto();

            if (!ID.Text.Equals(""))
            {
                comentar.GetIDProjeto = (Int32.Parse(ID.Text));
                comentar.Show();
            }

        }

        private void Avaliar_Click(object sender, EventArgs e)
        {
            AvaliarProjeto avaliar = new AvaliarProjeto();
            if (!ID.Text.Equals(""))
            {
                avaliar.GetIDProjeto = (Int32.Parse(ID.Text));
                avaliar.GetValoresQuestao = valores;
                avaliar.GetSomatorio = somatorio;
                avaliar.Show();
            }
        }

        private void DefinirValor_Click(object sender, EventArgs e)
        {
            QuantificarValor quantificar = new QuantificarValor();
            quantificar.Show();
        }
    }
}
