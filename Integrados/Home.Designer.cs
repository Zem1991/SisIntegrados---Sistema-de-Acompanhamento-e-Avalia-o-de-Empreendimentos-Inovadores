namespace Integrados
{
    partial class Home
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
            this.Administradores_btn = new System.Windows.Forms.Button();
            this.Avaliadores = new System.Windows.Forms.Button();
            this.Professores = new System.Windows.Forms.Button();
            this.Projetos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Administradores_btn
            // 
            this.Administradores_btn.Location = new System.Drawing.Point(3, 12);
            this.Administradores_btn.Name = "Administradores_btn";
            this.Administradores_btn.Size = new System.Drawing.Size(278, 23);
            this.Administradores_btn.TabIndex = 0;
            this.Administradores_btn.Text = "Administradores";
            this.Administradores_btn.UseVisualStyleBackColor = true;
            this.Administradores_btn.Click += new System.EventHandler(this.Administradores_btn_Click);
            // 
            // Avaliadores
            // 
            this.Avaliadores.Location = new System.Drawing.Point(3, 41);
            this.Avaliadores.Name = "Avaliadores";
            this.Avaliadores.Size = new System.Drawing.Size(278, 23);
            this.Avaliadores.TabIndex = 1;
            this.Avaliadores.Text = "Avaliadores";
            this.Avaliadores.UseVisualStyleBackColor = true;
            this.Avaliadores.Click += new System.EventHandler(this.Avaliadores_Click);
            // 
            // Professores
            // 
            this.Professores.Location = new System.Drawing.Point(3, 70);
            this.Professores.Name = "Professores";
            this.Professores.Size = new System.Drawing.Size(278, 23);
            this.Professores.TabIndex = 2;
            this.Professores.Text = "Professores";
            this.Professores.UseVisualStyleBackColor = true;
            this.Professores.Click += new System.EventHandler(this.Professores_Click);
            // 
            // Projetos
            // 
            this.Projetos.Location = new System.Drawing.Point(3, 99);
            this.Projetos.Name = "Projetos";
            this.Projetos.Size = new System.Drawing.Size(278, 23);
            this.Projetos.TabIndex = 3;
            this.Projetos.Text = "Projetos";
            this.Projetos.UseVisualStyleBackColor = true;
            this.Projetos.Click += new System.EventHandler(this.Projetos_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 132);
            this.Controls.Add(this.Projetos);
            this.Controls.Add(this.Professores);
            this.Controls.Add(this.Avaliadores);
            this.Controls.Add(this.Administradores_btn);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Administradores_btn;
        private System.Windows.Forms.Button Avaliadores;
        private System.Windows.Forms.Button Professores;
        private System.Windows.Forms.Button Projetos;
    }
}