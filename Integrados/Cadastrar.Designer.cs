namespace Integrados
{
    partial class Cadastrar
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
            this.tipoUser = new System.Windows.Forms.ComboBox();
            this.tipoUsuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.integradosDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.integradosDBDataSet = new Integrados.IntegradosDBDataSet();
            this.Cadastrar_btn = new System.Windows.Forms.Button();
            this.tipoUsuarioTableAdapter = new Integrados.IntegradosDBDataSetTableAdapters.TipoUsuarioTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tipoUsuarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integradosDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integradosDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tipoUser
            // 
            this.tipoUser.DataSource = this.tipoUsuarioBindingSource;
            this.tipoUser.DisplayMember = "TUdescricao";
            this.tipoUser.FormattingEnabled = true;
            this.tipoUser.Location = new System.Drawing.Point(12, 21);
            this.tipoUser.Name = "tipoUser";
            this.tipoUser.Size = new System.Drawing.Size(121, 21);
            this.tipoUser.TabIndex = 0;
            this.tipoUser.ValueMember = "TUIDusuario";
            // 
            // tipoUsuarioBindingSource
            // 
            this.tipoUsuarioBindingSource.DataMember = "TipoUsuario";
            this.tipoUsuarioBindingSource.DataSource = this.integradosDBDataSetBindingSource;
            // 
            // integradosDBDataSetBindingSource
            // 
            this.integradosDBDataSetBindingSource.DataSource = this.integradosDBDataSet;
            this.integradosDBDataSetBindingSource.Position = 0;
            // 
            // integradosDBDataSet
            // 
            this.integradosDBDataSet.DataSetName = "IntegradosDBDataSet";
            this.integradosDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Cadastrar_btn
            // 
            this.Cadastrar_btn.Location = new System.Drawing.Point(149, 19);
            this.Cadastrar_btn.Name = "Cadastrar_btn";
            this.Cadastrar_btn.Size = new System.Drawing.Size(75, 23);
            this.Cadastrar_btn.TabIndex = 1;
            this.Cadastrar_btn.Text = "Cadastrar";
            this.Cadastrar_btn.UseVisualStyleBackColor = true;
            this.Cadastrar_btn.Click += new System.EventHandler(this.Cadastrar_btn_Click);
            // 
            // tipoUsuarioTableAdapter
            // 
            this.tipoUsuarioTableAdapter.ClearBeforeFill = true;
            // 
            // Cadastrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 59);
            this.Controls.Add(this.Cadastrar_btn);
            this.Controls.Add(this.tipoUser);
            this.Name = "Cadastrar";
            this.Text = "Cadastrar";
            this.Load += new System.EventHandler(this.Cadastrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tipoUsuarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integradosDBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integradosDBDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox tipoUser;
        private System.Windows.Forms.Button Cadastrar_btn;
        private System.Windows.Forms.BindingSource integradosDBDataSetBindingSource;
        private IntegradosDBDataSet integradosDBDataSet;
        private System.Windows.Forms.BindingSource tipoUsuarioBindingSource;
        private IntegradosDBDataSetTableAdapters.TipoUsuarioTableAdapter tipoUsuarioTableAdapter;
    }
}