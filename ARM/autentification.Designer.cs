namespace ARM
{
    partial class autentification
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
            this.login1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txLogin = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.password = new System.Windows.Forms.TextBox();
            this.btEnter = new System.Windows.Forms.Button();
            this.btReg = new System.Windows.Forms.Button();
            this.btGuest = new System.Windows.Forms.Button();
            this.epMain = new System.Windows.Forms.ErrorProvider(this.components);
            this.login1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).BeginInit();
            this.SuspendLayout();
            // 
            // login1
            // 
            this.login1.Controls.Add(this.panel1);
            this.login1.Dock = System.Windows.Forms.DockStyle.Top;
            this.login1.Location = new System.Drawing.Point(0, 0);
            this.login1.Margin = new System.Windows.Forms.Padding(2);
            this.login1.Name = "login1";
            this.login1.Padding = new System.Windows.Forms.Padding(2);
            this.login1.Size = new System.Drawing.Size(600, 81);
            this.login1.TabIndex = 2;
            this.login1.TabStop = false;
            this.login1.Text = "Login";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txLogin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 11, 0);
            this.panel1.Size = new System.Drawing.Size(596, 64);
            this.panel1.TabIndex = 1;
            // 
            // txLogin
            // 
            this.txLogin.Location = new System.Drawing.Point(2, 14);
            this.txLogin.Margin = new System.Windows.Forms.Padding(2);
            this.txLogin.Multiline = true;
            this.txLogin.Name = "txLogin";
            this.txLogin.Size = new System.Drawing.Size(563, 26);
            this.txLogin.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.password);
            this.groupBox1.Location = new System.Drawing.Point(2, 86);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(593, 88);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Password";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(0, 28);
            this.password.Margin = new System.Windows.Forms.Padding(2);
            this.password.Multiline = true;
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(563, 31);
            this.password.TabIndex = 0;
            this.password.UseSystemPasswordChar = true;
            this.password.TextChanged += new System.EventHandler(this.password_TextChanged);
            // 
            // btEnter
            // 
            this.btEnter.Location = new System.Drawing.Point(4, 179);
            this.btEnter.Margin = new System.Windows.Forms.Padding(2);
            this.btEnter.Name = "btEnter";
            this.btEnter.Size = new System.Drawing.Size(582, 70);
            this.btEnter.TabIndex = 6;
            this.btEnter.Text = "Войти";
            this.btEnter.UseVisualStyleBackColor = true;
            this.btEnter.Click += new System.EventHandler(this.enter_Click);
            // 
            // btReg
            // 
            this.btReg.Location = new System.Drawing.Point(302, 254);
            this.btReg.Margin = new System.Windows.Forms.Padding(2);
            this.btReg.Name = "btReg";
            this.btReg.Size = new System.Drawing.Size(285, 88);
            this.btReg.TabIndex = 7;
            this.btReg.Text = "Зарегистрироваться как оператор";
            this.btReg.UseVisualStyleBackColor = true;
            this.btReg.Click += new System.EventHandler(this.btReg_Click);
            // 
            // btGuest
            // 
            this.btGuest.Location = new System.Drawing.Point(4, 254);
            this.btGuest.Margin = new System.Windows.Forms.Padding(2);
            this.btGuest.Name = "btGuest";
            this.btGuest.Size = new System.Drawing.Size(280, 88);
            this.btGuest.TabIndex = 8;
            this.btGuest.Text = "Войти как гость";
            this.btGuest.UseVisualStyleBackColor = true;
            this.btGuest.Click += new System.EventHandler(this.btGuest_Click);
            // 
            // epMain
            // 
            this.epMain.ContainerControl = this;
            // 
            // autentification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btGuest);
            this.Controls.Add(this.btReg);
            this.Controls.Add(this.btEnter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.login1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "autentification";
            this.Text = "Вход";
            this.login1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox login1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txLogin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btEnter;
        private System.Windows.Forms.Button btReg;
        private System.Windows.Forms.Button btGuest;
        private System.Windows.Forms.ErrorProvider epMain;
        public System.Windows.Forms.TextBox password;
    }
}