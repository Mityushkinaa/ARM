namespace ARM
{
    partial class addCountry
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
            this.вф = new System.Windows.Forms.GroupBox();
            this.txCountry = new System.Windows.Forms.TextBox();
            this.cnhf = new System.Windows.Forms.GroupBox();
            this.cmLang = new System.Windows.Forms.ComboBox();
            this.languageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.epMain = new System.Windows.Forms.ErrorProvider(this.components);
            this.btAddCount = new System.Windows.Forms.Button();
            this.вф.SuspendLayout();
            this.cnhf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.languageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).BeginInit();
            this.SuspendLayout();
            // 
            // вф
            // 
            this.вф.Controls.Add(this.txCountry);
            this.вф.Dock = System.Windows.Forms.DockStyle.Top;
            this.вф.Location = new System.Drawing.Point(0, 0);
            this.вф.Margin = new System.Windows.Forms.Padding(4);
            this.вф.Name = "вф";
            this.вф.Padding = new System.Windows.Forms.Padding(4);
            this.вф.Size = new System.Drawing.Size(310, 54);
            this.вф.TabIndex = 2;
            this.вф.TabStop = false;
            this.вф.Text = "Название страны";
            // 
            // txCountry
            // 
            this.txCountry.Dock = System.Windows.Forms.DockStyle.Left;
            this.txCountry.Location = new System.Drawing.Point(4, 19);
            this.txCountry.Margin = new System.Windows.Forms.Padding(4);
            this.txCountry.MaxLength = 100;
            this.txCountry.Name = "txCountry";
            this.txCountry.Size = new System.Drawing.Size(303, 22);
            this.txCountry.TabIndex = 0;
            this.txCountry.TextChanged += new System.EventHandler(this.txCountry_TextChanged);
            // 
            // cnhf
            // 
            this.cnhf.Controls.Add(this.cmLang);
            this.cnhf.Dock = System.Windows.Forms.DockStyle.Top;
            this.cnhf.Location = new System.Drawing.Point(0, 54);
            this.cnhf.Margin = new System.Windows.Forms.Padding(4);
            this.cnhf.Name = "cnhf";
            this.cnhf.Padding = new System.Windows.Forms.Padding(4);
            this.cnhf.Size = new System.Drawing.Size(310, 54);
            this.cnhf.TabIndex = 3;
            this.cnhf.TabStop = false;
            this.cnhf.Text = "Язык";
            // 
            // cmLang
            // 
            this.cmLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmLang.FormattingEnabled = true;
            this.cmLang.Location = new System.Drawing.Point(12, 23);
            this.cmLang.Name = "cmLang";
            this.cmLang.Size = new System.Drawing.Size(295, 24);
            this.cmLang.TabIndex = 0;
            this.cmLang.SelectedIndexChanged += new System.EventHandler(this.cmLang_SelectedIndexChanged);
            // 
            // epMain
            // 
            this.epMain.ContainerControl = this;
            // 
            // btAddCount
            // 
            this.btAddCount.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btAddCount.Enabled = false;
            this.btAddCount.Location = new System.Drawing.Point(77, 132);
            this.btAddCount.Name = "btAddCount";
            this.btAddCount.Size = new System.Drawing.Size(147, 43);
            this.btAddCount.TabIndex = 4;
            this.btAddCount.Text = "Добавить";
            this.btAddCount.UseVisualStyleBackColor = true;
            // 
            // addCountry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 196);
            this.Controls.Add(this.btAddCount);
            this.Controls.Add(this.cnhf);
            this.Controls.Add(this.вф);
            this.Name = "addCountry";
            this.Text = "Добавление страны";
            this.вф.ResumeLayout(false);
            this.вф.PerformLayout();
            this.cnhf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.languageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox вф;
        private System.Windows.Forms.TextBox txCountry;
        private System.Windows.Forms.GroupBox cnhf;
        private System.Windows.Forms.ComboBox cmLang;
       
        private System.Windows.Forms.BindingSource languageBindingSource;
       
        private System.Windows.Forms.ErrorProvider epMain;
        private System.Windows.Forms.Button btAddCount;
    }
}