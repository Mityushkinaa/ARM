namespace ARM
{
    partial class secondForm
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
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.login = new System.Windows.Forms.TextBox();
            this.gbPassword = new System.Windows.Forms.GroupBox();
            this.password = new System.Windows.Forms.TextBox();
            this.gbRegistrationDate = new System.Windows.Forms.GroupBox();
            this.registrationDate = new System.Windows.Forms.DateTimePicker();
            this.btOk = new System.Windows.Forms.Button();
            this.cbAdmin = new System.Windows.Forms.CheckBox();
            this.epMain = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbLogin.SuspendLayout();
            this.gbPassword.SuspendLayout();
            this.gbRegistrationDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).BeginInit();
            this.SuspendLayout();
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.login);
            this.gbLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbLogin.Location = new System.Drawing.Point(0, 0);
            this.gbLogin.Margin = new System.Windows.Forms.Padding(4);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Padding = new System.Windows.Forms.Padding(4);
            this.gbLogin.Size = new System.Drawing.Size(372, 54);
            this.gbLogin.TabIndex = 2;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "Логин";
            // 
            // login
            // 
            this.login.Dock = System.Windows.Forms.DockStyle.Left;
            this.login.Location = new System.Drawing.Point(4, 19);
            this.login.Margin = new System.Windows.Forms.Padding(4);
            this.login.MaxLength = 100;
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(303, 22);
            this.login.TabIndex = 0;
            this.login.TextChanged += new System.EventHandler(this.login_TextChanged);
            // 
            // gbPassword
            // 
            this.gbPassword.Controls.Add(this.password);
            this.gbPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPassword.Location = new System.Drawing.Point(0, 54);
            this.gbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.gbPassword.Name = "gbPassword";
            this.gbPassword.Padding = new System.Windows.Forms.Padding(4);
            this.gbPassword.Size = new System.Drawing.Size(372, 54);
            this.gbPassword.TabIndex = 3;
            this.gbPassword.TabStop = false;
            this.gbPassword.Text = "Пароль";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(4, 19);
            this.password.Margin = new System.Windows.Forms.Padding(4);
            this.password.MaxLength = 100;
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(303, 22);
            this.password.TabIndex = 0;
            this.password.TextChanged += new System.EventHandler(this.password_TextChanged);
            // 
            // gbRegistrationDate
            // 
            this.gbRegistrationDate.Controls.Add(this.registrationDate);
            this.gbRegistrationDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbRegistrationDate.Location = new System.Drawing.Point(0, 108);
            this.gbRegistrationDate.Margin = new System.Windows.Forms.Padding(4);
            this.gbRegistrationDate.Name = "gbRegistrationDate";
            this.gbRegistrationDate.Padding = new System.Windows.Forms.Padding(4);
            this.gbRegistrationDate.Size = new System.Drawing.Size(372, 54);
            this.gbRegistrationDate.TabIndex = 5;
            this.gbRegistrationDate.TabStop = false;
            this.gbRegistrationDate.Text = "Дата регистрации";
            // 
            // registrationDate
            // 
            this.registrationDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registrationDate.Location = new System.Drawing.Point(4, 19);
            this.registrationDate.Margin = new System.Windows.Forms.Padding(4);
            this.registrationDate.Name = "registrationDate";
            this.registrationDate.Size = new System.Drawing.Size(364, 22);
            this.registrationDate.TabIndex = 0;
            // 
            // btOk
            // 
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.Location = new System.Drawing.Point(0, 233);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(358, 55);
            this.btOk.TabIndex = 6;
            this.btOk.Text = "OK";
            this.btOk.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click_1);
            // 
            // cbAdmin
            // 
            this.cbAdmin.AutoSize = true;
            this.cbAdmin.Location = new System.Drawing.Point(4, 169);
            this.cbAdmin.Name = "cbAdmin";
            this.cbAdmin.Size = new System.Drawing.Size(185, 21);
            this.cbAdmin.TabIndex = 7;
            this.cbAdmin.Text = "Права администратора";
            this.cbAdmin.UseVisualStyleBackColor = true;
            this.cbAdmin.CheckedChanged += new System.EventHandler(this.cbAdmin_CheckedChanged);
            // 
            // epMain
            // 
            this.epMain.ContainerControl = this;
            // 
            // secondForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 319);
            this.Controls.Add(this.cbAdmin);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.gbRegistrationDate);
            this.Controls.Add(this.gbPassword);
            this.Controls.Add(this.gbLogin);
            this.Name = "secondForm";
            this.Text = "Данные пользователя";
            this.Load += new System.EventHandler(this.secondForm_Load);
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.gbPassword.ResumeLayout(false);
            this.gbPassword.PerformLayout();
            this.gbRegistrationDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.GroupBox gbPassword;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.GroupBox gbRegistrationDate;
        private System.Windows.Forms.DateTimePicker registrationDate;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.CheckBox cbAdmin;
        private System.Windows.Forms.ErrorProvider epMain;
    }
}