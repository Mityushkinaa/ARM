namespace ARM
{
    partial class ques
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
            this.btSearchCountry = new System.Windows.Forms.Button();
            this.btSearchDach = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmCountry = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbName = new System.Windows.Forms.ComboBox();
            this.dgvCountry = new System.Windows.Forms.DataGridView();
            this.dgvDach = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDach)).BeginInit();
            this.SuspendLayout();
            // 
            // btSearchCountry
            // 
            this.btSearchCountry.Location = new System.Drawing.Point(25, 131);
            this.btSearchCountry.Name = "btSearchCountry";
            this.btSearchCountry.Size = new System.Drawing.Size(75, 23);
            this.btSearchCountry.TabIndex = 0;
            this.btSearchCountry.Text = "Поиск";
            this.btSearchCountry.UseVisualStyleBackColor = true;
            this.btSearchCountry.Click += new System.EventHandler(this.btSearchCountry_Click);
            // 
            // btSearchDach
            // 
            this.btSearchDach.Location = new System.Drawing.Point(524, 131);
            this.btSearchDach.Name = "btSearchDach";
            this.btSearchDach.Size = new System.Drawing.Size(75, 23);
            this.btSearchDach.TabIndex = 1;
            this.btSearchDach.Text = "Поиск";
            this.btSearchDach.UseVisualStyleBackColor = true;
            this.btSearchDach.Click += new System.EventHandler(this.btSearchDach_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmCountry);
            this.groupBox1.Location = new System.Drawing.Point(509, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Определить страну дачи";
            // 
            // cmCountry
            // 
            this.cmCountry.DisplayMember = "fullName";
            this.cmCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmCountry.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmCountry.FormattingEnabled = true;
            this.cmCountry.Location = new System.Drawing.Point(0, 38);
            this.cmCountry.Name = "cmCountry";
            this.cmCountry.Size = new System.Drawing.Size(194, 24);
            this.cmCountry.TabIndex = 0;
            this.cmCountry.ValueMember = "id";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbName);
            this.groupBox2.Location = new System.Drawing.Point(25, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Дачи в собственности";
            // 
            // cbName
            // 
            this.cbName.DisplayMember = "fio";
            this.cbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbName.FormattingEnabled = true;
            this.cbName.Location = new System.Drawing.Point(6, 38);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(188, 24);
            this.cbName.TabIndex = 1;
            this.cbName.ValueMember = "id";
            // 
            // dgvCountry
            // 
            this.dgvCountry.AllowUserToAddRows = false;
            this.dgvCountry.AllowUserToDeleteRows = false;
            this.dgvCountry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCountry.Location = new System.Drawing.Point(509, 176);
            this.dgvCountry.Name = "dgvCountry";
            this.dgvCountry.ReadOnly = true;
            this.dgvCountry.RowTemplate.Height = 24;
            this.dgvCountry.Size = new System.Drawing.Size(357, 235);
            this.dgvCountry.TabIndex = 3;
            // 
            // dgvDach
            // 
            this.dgvDach.AllowUserToAddRows = false;
            this.dgvDach.AllowUserToDeleteRows = false;
            this.dgvDach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvDach.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgvDach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDach.Location = new System.Drawing.Point(12, 176);
            this.dgvDach.Name = "dgvDach";
            this.dgvDach.ReadOnly = true;
            this.dgvDach.RowTemplate.Height = 24;
            this.dgvDach.Size = new System.Drawing.Size(350, 235);
            this.dgvDach.TabIndex = 4;
            // 
            // ques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 460);
            this.Controls.Add(this.dgvDach);
            this.Controls.Add(this.dgvCountry);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btSearchDach);
            this.Controls.Add(this.btSearchCountry);
            this.Name = "ques";
            this.Text = "Запросы";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btSearchCountry;
        private System.Windows.Forms.Button btSearchDach;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvCountry;
        private System.Windows.Forms.DataGridView dgvDach;
        private System.Windows.Forms.ComboBox cmCountry;
        private System.Windows.Forms.ComboBox cbName;
    }
}