namespace ARM
{
    partial class ARM
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.авторизацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.управлениеПользователямиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запросToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvMyOwn = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvMyDist = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvMyDach = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvMyDachas = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyOwn)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyDist)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyDach)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyDachas)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.авторизацияToolStripMenuItem,
            this.управлениеПользователямиToolStripMenuItem,
            this.запросToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // авторизацияToolStripMenuItem
            // 
            this.авторизацияToolStripMenuItem.Name = "авторизацияToolStripMenuItem";
            this.авторизацияToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.авторизацияToolStripMenuItem.Text = "Авторизация";
            this.авторизацияToolStripMenuItem.Click += new System.EventHandler(this.авторизацияToolStripMenuItem_Click);
            // 
            // управлениеПользователямиToolStripMenuItem
            // 
            this.управлениеПользователямиToolStripMenuItem.Name = "управлениеПользователямиToolStripMenuItem";
            this.управлениеПользователямиToolStripMenuItem.Size = new System.Drawing.Size(179, 20);
            this.управлениеПользователямиToolStripMenuItem.Text = "Управление пользователями";
            this.управлениеПользователямиToolStripMenuItem.Click += new System.EventHandler(this.управлениеПользователямиToolStripMenuItem_Click);
            // 
            // запросToolStripMenuItem
            // 
            this.запросToolStripMenuItem.Name = "запросToolStripMenuItem";
            this.запросToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.запросToolStripMenuItem.Text = "Запросы";
            this.запросToolStripMenuItem.Click += new System.EventHandler(this.запросToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(9, 25);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(582, 331);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvMyOwn);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(574, 305);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Владельцы";
            // 
            // dgvMyOwn
            // 
            this.dgvMyOwn.AllowUserToResizeColumns = false;
            this.dgvMyOwn.AllowUserToResizeRows = false;
            this.dgvMyOwn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMyOwn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyOwn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMyOwn.Location = new System.Drawing.Point(2, 2);
            this.dgvMyOwn.Name = "dgvMyOwn";
            this.dgvMyOwn.Size = new System.Drawing.Size(570, 301);
            this.dgvMyOwn.TabIndex = 0;
            this.dgvMyOwn.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMyOwn_CellContentClick);
            this.dgvMyOwn.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMu_CellValueChanged);
            this.dgvMyOwn.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvMu_RowValidating);
            this.dgvMyOwn.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvMu_UserDeletingRow);
            this.dgvMyOwn.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvMu_PreviewKeyDown);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvMyDist);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(574, 305);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Районы";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvMyDist
            // 
            this.dgvMyDist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMyDist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyDist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMyDist.Location = new System.Drawing.Point(2, 2);
            this.dgvMyDist.Name = "dgvMyDist";
            this.dgvMyDist.Size = new System.Drawing.Size(570, 301);
            this.dgvMyDist.TabIndex = 1;
            this.dgvMyDist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMyDist_CellContentClick);
            this.dgvMyDist.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMyDist_CellValueChanged);
            this.dgvMyDist.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvMyDist_RowValidating);
            this.dgvMyDist.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvMyDist_UserDeletingRow);
            this.dgvMyDist.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvMyDist_PreviewKeyDown);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvMyDach);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(574, 305);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Информация о собственности";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvMyDach
            // 
            this.dgvMyDach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMyDach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyDach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMyDach.Location = new System.Drawing.Point(0, 0);
            this.dgvMyDach.Name = "dgvMyDach";
            this.dgvMyDach.Size = new System.Drawing.Size(574, 305);
            this.dgvMyDach.TabIndex = 4;
            this.dgvMyDach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMyDach_CellContentClick);
            this.dgvMyDach.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMyDach_CellValueChanged);
            this.dgvMyDach.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvMyDach_RowValidating);
            this.dgvMyDach.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvMyDach_UserDeletingRow);
            this.dgvMyDach.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvMyDach_PreviewKeyDown);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvMyDachas);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(574, 305);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Дачи";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvMyDachas
            // 
            this.dgvMyDachas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMyDachas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyDachas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMyDachas.Location = new System.Drawing.Point(0, 0);
            this.dgvMyDachas.Name = "dgvMyDachas";
            this.dgvMyDachas.Size = new System.Drawing.Size(574, 305);
            this.dgvMyDachas.TabIndex = 2;
            this.dgvMyDachas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMyDachas_CellContentClick);
            this.dgvMyDachas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMyDachas_CellValueChanged);
            this.dgvMyDachas.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvMyDachas_RowValidating);
            this.dgvMyDachas.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvMyDachas_UserDeletingRow);
            this.dgvMyDachas.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvMyDachas_PreviewKeyDown);
            // 
            // ARM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ARM";
            this.Text = "Автоматизированное рабочее место";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyOwn)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyDist)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyDach)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyDachas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem авторизацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem управлениеПользователямиToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvMyOwn;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvMyDist;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvMyDach;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgvMyDachas;
        private System.Windows.Forms.ToolStripMenuItem запросToolStripMenuItem;
    }
}

