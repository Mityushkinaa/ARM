namespace ARM
{
    partial class addOwner
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
            this.btAdd = new System.Windows.Forms.Button();
            this.txAge = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txNumber = new System.Windows.Forms.TextBox();
            this.txFio = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.epMain = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btAdd
            // 
            this.btAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btAdd.Enabled = false;
            this.btAdd.Location = new System.Drawing.Point(8, 216);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(303, 66);
            this.btAdd.TabIndex = 1;
            this.btAdd.Text = "Добавить";
            this.btAdd.UseVisualStyleBackColor = true;
            // 
            // txAge
            // 
            this.txAge.Location = new System.Drawing.Point(14, 108);
            this.txAge.Name = "txAge";
            this.txAge.Size = new System.Drawing.Size(297, 22);
            this.txAge.TabIndex = 2;
            this.txAge.TextChanged += new System.EventHandler(this.txAge_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(8, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 56);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Возраст";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txNumber);
            this.groupBox2.Location = new System.Drawing.Point(8, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(534, 52);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Номер телефона";
            // 
            // txNumber
            // 
            this.txNumber.Location = new System.Drawing.Point(6, 21);
            this.txNumber.Name = "txNumber";
            this.txNumber.Size = new System.Drawing.Size(297, 22);
            this.txNumber.TabIndex = 5;
            this.txNumber.TextChanged += new System.EventHandler(this.txNumber_TextChanged);
            // 
            // txFio
            // 
            this.txFio.Location = new System.Drawing.Point(6, 21);
            this.txFio.Name = "txFio";
            this.txFio.Size = new System.Drawing.Size(291, 22);
            this.txFio.TabIndex = 4;
            this.txFio.TextChanged += new System.EventHandler(this.txFio_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txFio);
            this.groupBox3.Location = new System.Drawing.Point(8, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(303, 56);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ФИО";
            // 
            // epMain
            // 
            this.epMain.ContainerControl = this;
            // 
            // addOwner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 313);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txAge);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btAdd);
            this.Name = "addOwner";
            this.Text = "Добавление владельца";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.TextBox txAge;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txNumber;
        private System.Windows.Forms.TextBox txFio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ErrorProvider epMain;
    }
}