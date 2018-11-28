namespace Integrados
{
    partial class ListaProjetos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.projetoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.integradosDBDataSet = new Integrados.IntegradosDBDataSet();
            this.projetoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.projetoTableAdapter = new Integrados.IntegradosDBDataSetTableAdapters.ProjetoTableAdapter();
            this.DefinirValor = new System.Windows.Forms.Button();
            this.Avaliar = new System.Windows.Forms.Button();
            this.Comentar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.TextBox();
            this.pRIDprojetoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRnomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRalunoLiderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRorientadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRavaliadorExternoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRStatusProjetoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projetoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integradosDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projetoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pRIDprojetoDataGridViewTextBoxColumn,
            this.pRnomeDataGridViewTextBoxColumn,
            this.pRalunoLiderDataGridViewTextBoxColumn,
            this.pRorientadorDataGridViewTextBoxColumn,
            this.pRavaliadorExternoDataGridViewTextBoxColumn,
            this.Nota,
            this.pRStatusProjetoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.projetoBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(747, 199);
            this.dataGridView1.TabIndex = 0;
            // 
            // projetoBindingSource1
            // 
            this.projetoBindingSource1.DataMember = "Projeto";
            this.projetoBindingSource1.DataSource = this.integradosDBDataSet;
            // 
            // integradosDBDataSet
            // 
            this.integradosDBDataSet.DataSetName = "IntegradosDBDataSet";
            this.integradosDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // projetoBindingSource
            // 
            this.projetoBindingSource.DataMember = "Projeto";
            this.projetoBindingSource.DataSource = this.integradosDBDataSet;
            // 
            // projetoTableAdapter
            // 
            this.projetoTableAdapter.ClearBeforeFill = true;
            // 
            // DefinirValor
            // 
            this.DefinirValor.Location = new System.Drawing.Point(3, 208);
            this.DefinirValor.Name = "DefinirValor";
            this.DefinirValor.Size = new System.Drawing.Size(128, 41);
            this.DefinirValor.TabIndex = 1;
            this.DefinirValor.Text = "Definir Valores";
            this.DefinirValor.UseVisualStyleBackColor = true;
            this.DefinirValor.Click += new System.EventHandler(this.DefinirValor_Click);
            // 
            // Avaliar
            // 
            this.Avaliar.Location = new System.Drawing.Point(511, 208);
            this.Avaliar.Name = "Avaliar";
            this.Avaliar.Size = new System.Drawing.Size(139, 41);
            this.Avaliar.TabIndex = 3;
            this.Avaliar.Text = "Avaliar";
            this.Avaliar.UseVisualStyleBackColor = true;
            this.Avaliar.Click += new System.EventHandler(this.Avaliar_Click);
            // 
            // Comentar
            // 
            this.Comentar.Location = new System.Drawing.Point(342, 208);
            this.Comentar.Name = "Comentar";
            this.Comentar.Size = new System.Drawing.Size(153, 41);
            this.Comentar.TabIndex = 2;
            this.Comentar.Text = "Comentar";
            this.Comentar.UseVisualStyleBackColor = true;
            this.Comentar.Click += new System.EventHandler(this.Comentar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID do Projeto:";
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(217, 208);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(119, 20);
            this.ID.TabIndex = 6;
            // 
            // pRIDprojetoDataGridViewTextBoxColumn
            // 
            this.pRIDprojetoDataGridViewTextBoxColumn.DataPropertyName = "PRIDprojeto";
            this.pRIDprojetoDataGridViewTextBoxColumn.HeaderText = "ID";
            this.pRIDprojetoDataGridViewTextBoxColumn.Name = "pRIDprojetoDataGridViewTextBoxColumn";
            this.pRIDprojetoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pRnomeDataGridViewTextBoxColumn
            // 
            this.pRnomeDataGridViewTextBoxColumn.DataPropertyName = "PRnome";
            this.pRnomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.pRnomeDataGridViewTextBoxColumn.Name = "pRnomeDataGridViewTextBoxColumn";
            // 
            // pRalunoLiderDataGridViewTextBoxColumn
            // 
            this.pRalunoLiderDataGridViewTextBoxColumn.DataPropertyName = "PRalunoLider";
            this.pRalunoLiderDataGridViewTextBoxColumn.HeaderText = "Aluno Lider";
            this.pRalunoLiderDataGridViewTextBoxColumn.Name = "pRalunoLiderDataGridViewTextBoxColumn";
            // 
            // pRorientadorDataGridViewTextBoxColumn
            // 
            this.pRorientadorDataGridViewTextBoxColumn.DataPropertyName = "PRorientador";
            this.pRorientadorDataGridViewTextBoxColumn.HeaderText = "Orientador";
            this.pRorientadorDataGridViewTextBoxColumn.Name = "pRorientadorDataGridViewTextBoxColumn";
            // 
            // pRavaliadorExternoDataGridViewTextBoxColumn
            // 
            this.pRavaliadorExternoDataGridViewTextBoxColumn.DataPropertyName = "PRavaliadorExterno";
            this.pRavaliadorExternoDataGridViewTextBoxColumn.HeaderText = "Avaliador Externo";
            this.pRavaliadorExternoDataGridViewTextBoxColumn.Name = "pRavaliadorExternoDataGridViewTextBoxColumn";
            // 
            // Nota
            // 
            this.Nota.DataPropertyName = "PRnotaFinal";
            this.Nota.HeaderText = "Nota";
            this.Nota.Name = "Nota";
            // 
            // pRStatusProjetoDataGridViewTextBoxColumn
            // 
            this.pRStatusProjetoDataGridViewTextBoxColumn.DataPropertyName = "PRStatusProjeto";
            this.pRStatusProjetoDataGridViewTextBoxColumn.HeaderText = "Status";
            this.pRStatusProjetoDataGridViewTextBoxColumn.Name = "pRStatusProjetoDataGridViewTextBoxColumn";
            // 
            // ListaProjetos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 261);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Avaliar);
            this.Controls.Add(this.Comentar);
            this.Controls.Add(this.DefinirValor);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ListaProjetos";
            this.Text = "ListaProjetos";
            this.Load += new System.EventHandler(this.ListaProjetos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projetoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integradosDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projetoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private IntegradosDBDataSet integradosDBDataSet;
        private System.Windows.Forms.BindingSource projetoBindingSource;
        private IntegradosDBDataSetTableAdapters.ProjetoTableAdapter projetoTableAdapter;
        private System.Windows.Forms.BindingSource projetoBindingSource1;
        private System.Windows.Forms.Button DefinirValor;
        private System.Windows.Forms.Button Avaliar;
        private System.Windows.Forms.Button Comentar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRIDprojetoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRnomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRalunoLiderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRorientadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRavaliadorExternoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nota;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRStatusProjetoDataGridViewTextBoxColumn;
    }
}