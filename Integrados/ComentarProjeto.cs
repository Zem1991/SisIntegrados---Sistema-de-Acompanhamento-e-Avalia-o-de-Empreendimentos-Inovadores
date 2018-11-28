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
    public partial class ComentarProjeto : Form
    {
        private ProjetoRepositorio PR = new ProjetoRepositorio();
        private AlunoRepositorio ALR = new AlunoRepositorio();
        private ProfessorRepositorio PRR = new ProfessorRepositorio();
        private AvaliadorRepositorio AVR = new AvaliadorRepositorio();

        private int idProjeto;
        private string descricaoProjeto;

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

        public ComentarProjeto()
        {
            InitializeComponent();
        }

        private void ComentarProjeto_Load(object sender, EventArgs e)
        {
            Projeto proj = new Projeto();

            try
            {
                proj = PR.BuscarPorID(idProjeto);
            }
            catch
            {
                Error erro = new Error();
                erro.GetError = "Não foi possível realizar sua operação - Projeto Não encontrado!";
                this.Hide();
                erro.Show();
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

            if(!proj.PRComentarios.Equals(" "))
            {
                var comentarios = proj.PRComentarios.Split(';');

                Comentario1.Text = comentarios[0];
                Comentario2.Text = comentarios[1];
                Comentario3.Text = comentarios[2];
                Comentario4.Text = comentarios[3];
                Comentario5.Text = comentarios[4];
                Comentario6.Text = comentarios[5];
                Comentario7.Text = comentarios[6];
                Comentario8.Text = comentarios[7];
            }

        }

        private void Salvar_Click(object sender, EventArgs e)
        {
            Projeto proj = new Projeto();
            proj = PR.BuscarPorID(idProjeto);


            proj.PRComentarios = "";

            proj.PRComentarios += Comentario1.Text + ";";
            proj.PRComentarios += Comentario2.Text + ";";
            proj.PRComentarios += Comentario3.Text + ";";
            proj.PRComentarios += Comentario4.Text + ";";
            proj.PRComentarios += Comentario5.Text + ";";
            proj.PRComentarios += Comentario6.Text + ";";
            proj.PRComentarios += Comentario7.Text + ";";
            proj.PRComentarios += Comentario8.Text + ";";

            try
            {
                PR.Atualizar(proj);
            }
            catch
            {
                Error erro = new Error();
                erro.GetError = "Não foi possível realizar sua operação - Informação Inválida em Algum dos Campos!";
                this.Hide();
                erro.Show();
            }
            

            this.Hide();

            ListaProjetos lista = new ListaProjetos();
            lista.Show();
        }
    }
}
