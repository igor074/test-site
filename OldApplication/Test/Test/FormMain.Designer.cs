namespace Test
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типыВопросовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.областиВопросовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.учебныеЗаведенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ученикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.регистрацияПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewVoprosy = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьВопросОлимпToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьВопросОлимпToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьВопросОлимпToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewOlimp = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьВопросToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.testDataSet1 = new Test.TestDataSet();
            this.voprosyTableAdapter1 = new Test.TestDataSetTableAdapters.VoprosyTableAdapter();
            this.olimpiadyTableAdapter1 = new Test.TestDataSetTableAdapters.OlimpiadyTableAdapter();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVoprosy)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOlimp)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BackgroundImage")));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справочникиToolStripMenuItem,
            this.регистрацияПользователяToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(893, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.файлToolStripMenuItem.ForeColor = System.Drawing.Color.SpringGreen;
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.типыВопросовToolStripMenuItem,
            this.областиВопросовToolStripMenuItem,
            this.учебныеЗаведенияToolStripMenuItem,
            this.ученикиToolStripMenuItem,
            this.тестыToolStripMenuItem});
            this.справочникиToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.справочникиToolStripMenuItem.ForeColor = System.Drawing.Color.SpringGreen;
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // типыВопросовToolStripMenuItem
            // 
            this.типыВопросовToolStripMenuItem.Name = "типыВопросовToolStripMenuItem";
            this.типыВопросовToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.типыВопросовToolStripMenuItem.Text = "Типы вопросов";
            this.типыВопросовToolStripMenuItem.Click += new System.EventHandler(this.типыВопросовToolStripMenuItem_Click);
            // 
            // областиВопросовToolStripMenuItem
            // 
            this.областиВопросовToolStripMenuItem.Name = "областиВопросовToolStripMenuItem";
            this.областиВопросовToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.областиВопросовToolStripMenuItem.Text = "Области вопросов";
            this.областиВопросовToolStripMenuItem.Click += new System.EventHandler(this.областиВопросовToolStripMenuItem_Click);
            // 
            // учебныеЗаведенияToolStripMenuItem
            // 
            this.учебныеЗаведенияToolStripMenuItem.Name = "учебныеЗаведенияToolStripMenuItem";
            this.учебныеЗаведенияToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.учебныеЗаведенияToolStripMenuItem.Text = "Учебные заведения";
            this.учебныеЗаведенияToolStripMenuItem.Click += new System.EventHandler(this.учебныеЗаведенияToolStripMenuItem_Click);
            // 
            // ученикиToolStripMenuItem
            // 
            this.ученикиToolStripMenuItem.Name = "ученикиToolStripMenuItem";
            this.ученикиToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.ученикиToolStripMenuItem.Text = "Ученики";
            this.ученикиToolStripMenuItem.Click += new System.EventHandler(this.ученикиToolStripMenuItem_Click);
            // 
            // тестыToolStripMenuItem
            // 
            this.тестыToolStripMenuItem.Name = "тестыToolStripMenuItem";
            this.тестыToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.тестыToolStripMenuItem.Text = "Тесты";
            this.тестыToolStripMenuItem.Click += new System.EventHandler(this.тестыToolStripMenuItem_Click);
            // 
            // регистрацияПользователяToolStripMenuItem
            // 
            this.регистрацияПользователяToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.регистрацияПользователяToolStripMenuItem.ForeColor = System.Drawing.Color.SpringGreen;
            this.регистрацияПользователяToolStripMenuItem.Name = "регистрацияПользователяToolStripMenuItem";
            this.регистрацияПользователяToolStripMenuItem.Size = new System.Drawing.Size(176, 20);
            this.регистрацияПользователяToolStripMenuItem.Text = "Регистрация пользователя";
            this.регистрацияПользователяToolStripMenuItem.Click += new System.EventHandler(this.регистрацияПользователяToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.справкаToolStripMenuItem.ForeColor = System.Drawing.Color.SpringGreen;
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(893, 344);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridViewVoprosy);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(885, 318);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Вопросы";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewVoprosy
            // 
            this.dataGridViewVoprosy.AllowUserToAddRows = false;
            this.dataGridViewVoprosy.AllowUserToDeleteRows = false;
            this.dataGridViewVoprosy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewVoprosy.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewVoprosy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVoprosy.ContextMenuStrip = this.contextMenuStrip2;
            this.dataGridViewVoprosy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewVoprosy.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewVoprosy.Name = "dataGridViewVoprosy";
            this.dataGridViewVoprosy.ReadOnly = true;
            this.dataGridViewVoprosy.RowHeadersVisible = false;
            this.dataGridViewVoprosy.Size = new System.Drawing.Size(879, 312);
            this.dataGridViewVoprosy.TabIndex = 0;
            this.dataGridViewVoprosy.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVoprosy_CellClick);
            this.dataGridViewVoprosy.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVoprosy_CellContentClick);
            this.dataGridViewVoprosy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewVoprosy_MouseClick);
            this.dataGridViewVoprosy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewVoprosy_MouseDown);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьВопросОлимпToolStripMenuItem,
            this.изменитьВопросОлимпToolStripMenuItem,
            this.удалитьВопросОлимпToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(172, 70);
            // 
            // добавитьВопросОлимпToolStripMenuItem
            // 
            this.добавитьВопросОлимпToolStripMenuItem.Name = "добавитьВопросОлимпToolStripMenuItem";
            this.добавитьВопросОлимпToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.добавитьВопросОлимпToolStripMenuItem.Text = "Добавить вопрос";
            this.добавитьВопросОлимпToolStripMenuItem.Click += new System.EventHandler(this.добавитьВопросToolStripMenuItem_Click);
            // 
            // изменитьВопросОлимпToolStripMenuItem
            // 
            this.изменитьВопросОлимпToolStripMenuItem.Name = "изменитьВопросОлимпToolStripMenuItem";
            this.изменитьВопросОлимпToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.изменитьВопросОлимпToolStripMenuItem.Text = "Изменить вопрос";
            this.изменитьВопросОлимпToolStripMenuItem.Click += new System.EventHandler(this.изменитьВопросToolStripMenuItem_Click);
            // 
            // удалитьВопросОлимпToolStripMenuItem
            // 
            this.удалитьВопросОлимпToolStripMenuItem.Name = "удалитьВопросОлимпToolStripMenuItem";
            this.удалитьВопросОлимпToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.удалитьВопросОлимпToolStripMenuItem.Text = "Удалить вопрос";
            this.удалитьВопросОлимпToolStripMenuItem.Click += new System.EventHandler(this.удалитьВопросToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewOlimp);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(885, 318);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Олимпиады";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewOlimp
            // 
            this.dataGridViewOlimp.AllowUserToAddRows = false;
            this.dataGridViewOlimp.AllowUserToDeleteRows = false;
            this.dataGridViewOlimp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOlimp.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewOlimp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOlimp.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewOlimp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewOlimp.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridViewOlimp.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewOlimp.Name = "dataGridViewOlimp";
            this.dataGridViewOlimp.RowHeadersVisible = false;
            this.dataGridViewOlimp.Size = new System.Drawing.Size(879, 312);
            this.dataGridViewOlimp.TabIndex = 0;
            this.dataGridViewOlimp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOlimp_CellContentClick);
            this.dataGridViewOlimp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewOlimp_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьВопросToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(176, 26);
            // 
            // добавитьВопросToolStripMenuItem
            // 
            this.добавитьВопросToolStripMenuItem.Name = "добавитьВопросToolStripMenuItem";
            this.добавитьВопросToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.добавитьВопросToolStripMenuItem.Text = "Добавить предмет";
            this.добавитьВопросToolStripMenuItem.Click += new System.EventHandler(this.добавитьВопросToolStripMenuItem_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(795, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Обновить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // testDataSet1
            // 
            this.testDataSet1.DataSetName = "TestDataSet";
            this.testDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // voprosyTableAdapter1
            // 
            this.voprosyTableAdapter1.ClearBeforeFill = true;
            // 
            // olimpiadyTableAdapter1
            // 
            this.olimpiadyTableAdapter1.ClearBeforeFill = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(893, 412);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Zebra";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVoprosy)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOlimp)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.testDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типыВопросовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem областиВопросовToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewVoprosy;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem учебныеЗаведенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ученикиToolStripMenuItem;
        private TestDataSet testDataSet1;
        private TestDataSetTableAdapters.VoprosyTableAdapter voprosyTableAdapter1;
        private TestDataSetTableAdapters.OlimpiadyTableAdapter olimpiadyTableAdapter1;
        private System.Windows.Forms.DataGridView dataGridViewOlimp;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem добавитьВопросОлимпToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьВопросОлимпToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьВопросОлимпToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тестыToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem регистрацияПользователяToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьВопросToolStripMenuItem;
    }
}