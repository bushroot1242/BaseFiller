namespace BaseFiller
{
    partial class FMain
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
            this.butGetAdress = new System.Windows.Forms.Button();
            this.tbPcName = new System.Windows.Forms.TextBox();
            this.tbAdress = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ssConsole = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbAvailableSQLInstaces = new System.Windows.Forms.ComboBox();
            this.dgvTableView = new System.Windows.Forms.DataGridView();
            this.cbAvailablServers = new System.Windows.Forms.ComboBox();
            this.cbTablesList = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выбратьБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butGetAdress
            // 
            this.butGetAdress.Location = new System.Drawing.Point(487, 353);
            this.butGetAdress.Name = "butGetAdress";
            this.butGetAdress.Size = new System.Drawing.Size(75, 23);
            this.butGetAdress.TabIndex = 0;
            this.butGetAdress.Text = "Получить адресс";
            this.butGetAdress.UseVisualStyleBackColor = true;
            this.butGetAdress.Click += new System.EventHandler(this.butGetAdress_Click);
            // 
            // tbPcName
            // 
            this.tbPcName.Location = new System.Drawing.Point(12, 434);
            this.tbPcName.Name = "tbPcName";
            this.tbPcName.Size = new System.Drawing.Size(334, 20);
            this.tbPcName.TabIndex = 1;
            // 
            // tbAdress
            // 
            this.tbAdress.Location = new System.Drawing.Point(12, 373);
            this.tbAdress.Multiline = true;
            this.tbAdress.Name = "tbAdress";
            this.tbAdress.Size = new System.Drawing.Size(334, 27);
            this.tbAdress.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssConsole});
            this.statusStrip1.Location = new System.Drawing.Point(0, 519);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(860, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ssConsole
            // 
            this.ssConsole.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ssConsole.Name = "ssConsole";
            this.ssConsole.Size = new System.Drawing.Size(845, 17);
            this.ssConsole.Spring = true;
            this.ssConsole.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // cbAvailableSQLInstaces
            // 
            this.cbAvailableSQLInstaces.FormattingEnabled = true;
            this.cbAvailableSQLInstaces.Location = new System.Drawing.Point(27, 229);
            this.cbAvailableSQLInstaces.Name = "cbAvailableSQLInstaces";
            this.cbAvailableSQLInstaces.Size = new System.Drawing.Size(227, 21);
            this.cbAvailableSQLInstaces.TabIndex = 4;
            // 
            // dgvTableView
            // 
            this.dgvTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableView.Location = new System.Drawing.Point(312, 81);
            this.dgvTableView.Name = "dgvTableView";
            this.dgvTableView.Size = new System.Drawing.Size(536, 247);
            this.dgvTableView.TabIndex = 5;
            // 
            // cbAvailablServers
            // 
            this.cbAvailablServers.FormattingEnabled = true;
            this.cbAvailablServers.Location = new System.Drawing.Point(26, 270);
            this.cbAvailablServers.Name = "cbAvailablServers";
            this.cbAvailablServers.Size = new System.Drawing.Size(227, 21);
            this.cbAvailablServers.TabIndex = 6;
            this.cbAvailablServers.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cbTablesList
            // 
            this.cbTablesList.FormattingEnabled = true;
            this.cbTablesList.Location = new System.Drawing.Point(27, 81);
            this.cbTablesList.Name = "cbTablesList";
            this.cbTablesList.Size = new System.Drawing.Size(226, 21);
            this.cbTablesList.TabIndex = 7;
            this.cbTablesList.SelectedIndexChanged += new System.EventHandler(this.cbTablesList_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.правкаToolStripMenuItem,
            this.сервисToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(860, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.правкаToolStripMenuItem.Text = "Правка";
            // 
            // сервисToolStripMenuItem
            // 
            this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбратьБДToolStripMenuItem});
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            this.сервисToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.сервисToolStripMenuItem.Text = "Сервис";
            // 
            // выбратьБДToolStripMenuItem
            // 
            this.выбратьБДToolStripMenuItem.Name = "выбратьБДToolStripMenuItem";
            this.выбратьБДToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.выбратьБДToolStripMenuItem.Text = "Выбрать БД";
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 541);
            this.Controls.Add(this.cbTablesList);
            this.Controls.Add(this.cbAvailablServers);
            this.Controls.Add(this.dgvTableView);
            this.Controls.Add(this.cbAvailableSQLInstaces);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tbAdress);
            this.Controls.Add(this.tbPcName);
            this.Controls.Add(this.butGetAdress);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FMain";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butGetAdress;
        private System.Windows.Forms.TextBox tbPcName;
        private System.Windows.Forms.TextBox tbAdress;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ssConsole;
        private System.Windows.Forms.ComboBox cbAvailableSQLInstaces;
        private System.Windows.Forms.DataGridView dgvTableView;
        private System.Windows.Forms.ComboBox cbAvailablServers;
        private System.Windows.Forms.ComboBox cbTablesList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выбратьБДToolStripMenuItem;
    }
}

