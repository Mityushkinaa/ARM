namespace ARM
{
    partial class addDist
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
            this.btAddDist = new System.Windows.Forms.Button();
            this.cmCount = new System.Windows.Forms.ComboBox();
            this.txName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txArea = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.epMain = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btAddDist
            // 
            this.btAddDist.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btAddDist.Enabled = false;
            this.btAddDist.Location = new System.Drawing.Point(29, 269);
            this.btAddDist.Name = "btAddDist";
            this.btAddDist.Size = new System.Drawing.Size(226, 51);
            this.btAddDist.TabIndex = 3;
            this.btAddDist.Text = "Добавить";
            this.btAddDist.UseVisualStyleBackColor = true;
            // 
            // cmCount
            // 
            this.cmCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmCount.FormattingEnabled = true;
            this.cmCount.Location = new System.Drawing.Point(13, 21);
            this.cmCount.Name = "cmCount";
            this.cmCount.Size = new System.Drawing.Size(226, 24);
            this.cmCount.TabIndex = 2;
            // 
            // txName
            // 
            this.txName.Location = new System.Drawing.Point(13, 21);
            this.txName.Name = "txName";
            this.txName.Size = new System.Drawing.Size(220, 22);
            this.txName.TabIndex = 0;
            this.txName.TextChanged += new System.EventHandler(this.txName_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txName);
            this.groupBox1.Location = new System.Drawing.Point(16, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 57);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Название района";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txArea);
            this.groupBox2.Location = new System.Drawing.Point(16, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 51);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Площадь";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txArea
            // 
            this.txArea.Location = new System.Drawing.Point(13, 23);
            this.txArea.Name = "txArea";
            this.txArea.Size = new System.Drawing.Size(220, 22);
            this.txArea.TabIndex = 1;
            this.txArea.TextChanged += new System.EventHandler(this.txArea_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmCount);
            this.groupBox3.Location = new System.Drawing.Point(16, 199);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(255, 52);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Страна";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // epMain
            // 
            this.epMain.ContainerControl = this;
            // 
            // addDist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 345);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btAddDist);
            this.Name = "addDist";
            this.Text = "Добавление района";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmCount;
        private System.Windows.Forms.TextBox txName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btAddDist;
        private System.Windows.Forms.TextBox txArea;
        private System.Windows.Forms.ErrorProvider epMain;
    }
}