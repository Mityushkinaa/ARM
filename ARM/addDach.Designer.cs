namespace ARM
{
    partial class addDach
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txArea = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txAway = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gbDist = new System.Windows.Forms.ComboBox();
            this.epMain = new System.Windows.Forms.ErrorProvider(this.components);
            this.btAddDist = new System.Windows.Forms.Button();
            this.addDistrict = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Название";
            // 
            // txName
            // 
            this.txName.Location = new System.Drawing.Point(9, 20);
            this.txName.Name = "txName";
            this.txName.Size = new System.Drawing.Size(268, 22);
            this.txName.TabIndex = 2;
            this.txName.TextChanged += new System.EventHandler(this.txName_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txArea);
            this.groupBox2.Location = new System.Drawing.Point(12, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 39);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Площадь";
            // 
            // txArea
            // 
            this.txArea.Location = new System.Drawing.Point(6, 17);
            this.txArea.Name = "txArea";
            this.txArea.Size = new System.Drawing.Size(271, 22);
            this.txArea.TabIndex = 1;
            this.txArea.TextChanged += new System.EventHandler(this.txArea_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txAway);
            this.groupBox3.Location = new System.Drawing.Point(18, 130);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(277, 60);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Удаленность от города";
            // 
            // txAway
            // 
            this.txAway.Location = new System.Drawing.Point(0, 21);
            this.txAway.Name = "txAway";
            this.txAway.Size = new System.Drawing.Size(271, 22);
            this.txAway.TabIndex = 0;
            this.txAway.TextChanged += new System.EventHandler(this.txAway_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gbDist);
            this.groupBox4.Location = new System.Drawing.Point(12, 196);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(283, 41);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Район";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // gbDist
            // 
            this.gbDist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gbDist.FormattingEnabled = true;
            this.gbDist.Location = new System.Drawing.Point(6, 17);
            this.gbDist.Name = "gbDist";
            this.gbDist.Size = new System.Drawing.Size(271, 24);
            this.gbDist.TabIndex = 4;
            // 
            // epMain
            // 
            this.epMain.ContainerControl = this;
            // 
            // btAddDist
            // 
            this.btAddDist.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btAddDist.Enabled = false;
            this.btAddDist.Location = new System.Drawing.Point(12, 284);
            this.btAddDist.Name = "btAddDist";
            this.btAddDist.Size = new System.Drawing.Size(283, 51);
            this.btAddDist.TabIndex = 2;
            this.btAddDist.Text = "Добавить";
            this.btAddDist.UseVisualStyleBackColor = true;
            // 
            // addDistrict
            // 
            this.addDistrict.Location = new System.Drawing.Point(12, 243);
            this.addDistrict.Name = "addDistrict";
            this.addDistrict.Size = new System.Drawing.Size(277, 35);
            this.addDistrict.TabIndex = 3;
            this.addDistrict.Text = "Добавить район";
            this.addDistrict.UseVisualStyleBackColor = true;
            this.addDistrict.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // addDach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 347);
            this.Controls.Add(this.addDistrict);
            this.Controls.Add(this.btAddDist);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "addDach";
            this.Text = "Добавление дачи";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txArea;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txAway;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox gbDist;
        private System.Windows.Forms.ErrorProvider epMain;
        private System.Windows.Forms.Button btAddDist;
        private System.Windows.Forms.Button addDistrict;
    }
}