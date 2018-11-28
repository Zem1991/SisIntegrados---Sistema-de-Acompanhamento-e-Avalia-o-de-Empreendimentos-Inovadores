namespace Integrados
{
    partial class EditarProfessor
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
            this.Departamento = new System.Windows.Forms.TextBox();
            this.Disciplina = new System.Windows.Forms.TextBox();
            this.Senha = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.Nome = new System.Windows.Forms.TextBox();
            this.Cadastrar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Stat = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Departamento
            // 
            this.Departamento.Location = new System.Drawing.Point(134, 179);
            this.Departamento.Name = "Departamento";
            this.Departamento.Size = new System.Drawing.Size(138, 20);
            this.Departamento.TabIndex = 21;
            // 
            // Disciplina
            // 
            this.Disciplina.Location = new System.Drawing.Point(134, 137);
            this.Disciplina.Name = "Disciplina";
            this.Disciplina.Size = new System.Drawing.Size(138, 20);
            this.Disciplina.TabIndex = 20;
            // 
            // Senha
            // 
            this.Senha.Location = new System.Drawing.Point(134, 102);
            this.Senha.Name = "Senha";
            this.Senha.PasswordChar = '*';
            this.Senha.Size = new System.Drawing.Size(138, 20);
            this.Senha.TabIndex = 19;
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(134, 59);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(138, 20);
            this.Email.TabIndex = 18;
            // 
            // Nome
            // 
            this.Nome.Location = new System.Drawing.Point(134, 24);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(138, 20);
            this.Nome.TabIndex = 17;
            // 
            // Cadastrar
            // 
            this.Cadastrar.Location = new System.Drawing.Point(197, 266);
            this.Cadastrar.Name = "Cadastrar";
            this.Cadastrar.Size = new System.Drawing.Size(75, 23);
            this.Cadastrar.TabIndex = 16;
            this.Cadastrar.Text = "Cadastrar";
            this.Cadastrar.UseVisualStyleBackColor = true;
            this.Cadastrar.Click += new System.EventHandler(this.Cadastrar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Departamento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Disciplina Principal:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Senha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Email:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nome:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Status:";
            // 
            // Stat
            // 
            this.Stat.FormattingEnabled = true;
            this.Stat.Items.AddRange(new object[] {
            "Ativo",
            "Inativo"});
            this.Stat.Location = new System.Drawing.Point(134, 221);
            this.Stat.Name = "Stat";
            this.Stat.Size = new System.Drawing.Size(138, 21);
            this.Stat.TabIndex = 23;
            // 
            // EditarProfessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 301);
            this.Controls.Add(this.Stat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Departamento);
            this.Controls.Add(this.Disciplina);
            this.Controls.Add(this.Senha);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.Nome);
            this.Controls.Add(this.Cadastrar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditarProfessor";
            this.Text = "EditarProfessor";
            this.Load += new System.EventHandler(this.EditarProfessor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Departamento;
        private System.Windows.Forms.TextBox Disciplina;
        private System.Windows.Forms.TextBox Senha;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.TextBox Nome;
        private System.Windows.Forms.Button Cadastrar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Stat;
    }
}