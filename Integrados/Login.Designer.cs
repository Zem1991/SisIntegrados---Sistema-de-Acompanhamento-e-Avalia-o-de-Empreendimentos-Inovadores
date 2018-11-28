namespace Integrados
{
    partial class Login
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
            this.panelLogin = new System.Windows.Forms.Panel();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.tipoUser = new System.Windows.Forms.ComboBox();
            this.tipoUsuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.integradosDBDataSet = new Integrados.IntegradosDBDataSet();
            this.labelUserType = new System.Windows.Forms.Label();
            this.nomeUser = new System.Windows.Forms.TextBox();
            this.senha = new System.Windows.Forms.MaskedTextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.tipoUsuarioTableAdapter = new Integrados.IntegradosDBDataSetTableAdapters.TipoUsuarioTableAdapter();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipoUsuarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integradosDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLogin
            // 
            this.panelLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLogin.Controls.Add(this.buttonRegister);
            this.panelLogin.Controls.Add(this.buttonLogin);
            this.panelLogin.Controls.Add(this.tipoUser);
            this.panelLogin.Controls.Add(this.labelUserType);
            this.panelLogin.Controls.Add(this.nomeUser);
            this.panelLogin.Controls.Add(this.senha);
            this.panelLogin.Controls.Add(this.labelPassword);
            this.panelLogin.Controls.Add(this.labelUserName);
            this.panelLogin.Location = new System.Drawing.Point(7, 3);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(291, 154);
            this.panelLogin.TabIndex = 0;
            this.panelLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLogin_Paint);
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(6, 121);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(252, 23);
            this.buttonRegister.TabIndex = 7;
            this.buttonRegister.Text = "Novo cadastro";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(3, 92);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(252, 23);
            this.buttonLogin.TabIndex = 6;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // tipoUser
            // 
            this.tipoUser.DataSource = this.tipoUsuarioBindingSource;
            this.tipoUser.DisplayMember = "TUdescricao";
            this.tipoUser.FormattingEnabled = true;
            this.tipoUser.Location = new System.Drawing.Point(96, 3);
            this.tipoUser.Name = "tipoUser";
            this.tipoUser.Size = new System.Drawing.Size(160, 21);
            this.tipoUser.TabIndex = 5;
            this.tipoUser.ValueMember = "TUIDusuario";
            // 
            // tipoUsuarioBindingSource
            // 
            this.tipoUsuarioBindingSource.DataMember = "TipoUsuario";
            this.tipoUsuarioBindingSource.DataSource = this.integradosDBDataSet;
            // 
            // integradosDBDataSet
            // 
            this.integradosDBDataSet.DataSetName = "IntegradosDBDataSet";
            this.integradosDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelUserType
            // 
            this.labelUserType.AutoSize = true;
            this.labelUserType.Location = new System.Drawing.Point(3, 6);
            this.labelUserType.Name = "labelUserType";
            this.labelUserType.Size = new System.Drawing.Size(80, 13);
            this.labelUserType.TabIndex = 4;
            this.labelUserType.Text = "Tipo de usuário";
            // 
            // nomeUser
            // 
            this.nomeUser.Location = new System.Drawing.Point(96, 30);
            this.nomeUser.Name = "nomeUser";
            this.nomeUser.Size = new System.Drawing.Size(160, 20);
            this.nomeUser.TabIndex = 3;
            // 
            // senha
            // 
            this.senha.Location = new System.Drawing.Point(96, 56);
            this.senha.Name = "senha";
            this.senha.PasswordChar = '*';
            this.senha.Size = new System.Drawing.Size(160, 20);
            this.senha.TabIndex = 2;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(3, 59);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(38, 13);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Senha";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(3, 33);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(87, 13);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "Nome do usuário";
            // 
            // tipoUsuarioTableAdapter
            // 
            this.tipoUsuarioTableAdapter.ClearBeforeFill = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 165);
            this.Controls.Add(this.panelLogin);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipoUsuarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integradosDBDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.TextBox nomeUser;
        private System.Windows.Forms.MaskedTextBox senha;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelUserType;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.ComboBox tipoUser;
        private System.Windows.Forms.Button buttonRegister;
        private IntegradosDBDataSet integradosDBDataSet;
        private System.Windows.Forms.BindingSource tipoUsuarioBindingSource;
        private IntegradosDBDataSetTableAdapters.TipoUsuarioTableAdapter tipoUsuarioTableAdapter;
    }
}