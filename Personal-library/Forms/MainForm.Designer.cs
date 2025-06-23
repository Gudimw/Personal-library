namespace Personal_library
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            FileToolStripMenuItem = new ToolStripMenuItem();
            OpenLibraryToolStripMenuItem = new ToolStripMenuItem();
            SaveLibraryToolStripMenuItem = new ToolStripMenuItem();
            EditToolStripMenuItem = new ToolStripMenuItem();
            EditSelectedBookToolStripMenuItem = new ToolStripMenuItem();
            DeleteChoosedBookToolStripMenuItem = new ToolStripMenuItem();
            AddNewBookToolStripMenuItem = new ToolStripMenuItem();
            GenresEditToolStripMenuItem = new ToolStripMenuItem();
            звітиToolStripMenuItem = new ToolStripMenuItem();
            інвентаризаціяБібліотекиToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            listBox1 = new ListBox();
            bookBindingSource = new BindingSource(components);
            groupBox2 = new GroupBox();
            groupBox4 = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            groupBox3 = new GroupBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            trackBar2 = new TrackBar();
            label6 = new Label();
            trackBar1 = new TrackBar();
            label5 = new Label();
            comboBox3 = new ComboBox();
            label4 = new Label();
            comboBox2 = new ComboBox();
            label3 = new Label();
            comboBox1 = new ComboBox();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            PublisherEditToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bookBindingSource).BeginInit();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { FileToolStripMenuItem, EditToolStripMenuItem, звітиToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1073, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { OpenLibraryToolStripMenuItem, SaveLibraryToolStripMenuItem });
            FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            FileToolStripMenuItem.Size = new Size(48, 20);
            FileToolStripMenuItem.Text = "Файл";
            // 
            // OpenLibraryToolStripMenuItem
            // 
            OpenLibraryToolStripMenuItem.Name = "OpenLibraryToolStripMenuItem";
            OpenLibraryToolStripMenuItem.Size = new Size(193, 22);
            OpenLibraryToolStripMenuItem.Text = "Відкрити бібліотеку...";
            OpenLibraryToolStripMenuItem.Click += OpenLibraryToolStripMenuItem_Click;
            // 
            // SaveLibraryToolStripMenuItem
            // 
            SaveLibraryToolStripMenuItem.Name = "SaveLibraryToolStripMenuItem";
            SaveLibraryToolStripMenuItem.Size = new Size(193, 22);
            SaveLibraryToolStripMenuItem.Text = "Зберегти бібліотеку...";
            SaveLibraryToolStripMenuItem.Click += SaveLibraryToolStripMenuItem_Click;
            // 
            // EditToolStripMenuItem
            // 
            EditToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { EditSelectedBookToolStripMenuItem, DeleteChoosedBookToolStripMenuItem, AddNewBookToolStripMenuItem, GenresEditToolStripMenuItem, PublisherEditToolStripMenuItem });
            EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            EditToolStripMenuItem.Size = new Size(87, 20);
            EditToolStripMenuItem.Text = "Редагування";
            // 
            // EditSelectedBookToolStripMenuItem
            // 
            EditSelectedBookToolStripMenuItem.Name = "EditSelectedBookToolStripMenuItem";
            EditSelectedBookToolStripMenuItem.Size = new Size(217, 22);
            EditSelectedBookToolStripMenuItem.Text = "Редагувати вибрану книгу";
            EditSelectedBookToolStripMenuItem.Click += EditSelectedBookToolStripMenuItem_Click;
            // 
            // DeleteChoosedBookToolStripMenuItem
            // 
            DeleteChoosedBookToolStripMenuItem.Name = "DeleteChoosedBookToolStripMenuItem";
            DeleteChoosedBookToolStripMenuItem.Size = new Size(217, 22);
            DeleteChoosedBookToolStripMenuItem.Text = "Видалити вибрану книгу";
            DeleteChoosedBookToolStripMenuItem.Click += DeleteChoosedBookToolStripMenuItem_Click;
            // 
            // AddNewBookToolStripMenuItem
            // 
            AddNewBookToolStripMenuItem.Name = "AddNewBookToolStripMenuItem";
            AddNewBookToolStripMenuItem.Size = new Size(217, 22);
            AddNewBookToolStripMenuItem.Text = "Додати нову книгу";
            AddNewBookToolStripMenuItem.Click += AddNewBookToolStripMenuItem_Click;
            // 
            // GenresEditToolStripMenuItem
            // 
            GenresEditToolStripMenuItem.Name = "GenresEditToolStripMenuItem";
            GenresEditToolStripMenuItem.Size = new Size(217, 22);
            GenresEditToolStripMenuItem.Text = "Редактор жанрів";
            GenresEditToolStripMenuItem.Click += GenresEditToolStripMenuItem_Click;
            // 
            // звітиToolStripMenuItem
            // 
            звітиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { інвентаризаціяБібліотекиToolStripMenuItem });
            звітиToolStripMenuItem.Name = "звітиToolStripMenuItem";
            звітиToolStripMenuItem.Size = new Size(47, 20);
            звітиToolStripMenuItem.Text = "Звіти";
            // 
            // інвентаризаціяБібліотекиToolStripMenuItem
            // 
            інвентаризаціяБібліотекиToolStripMenuItem.Name = "інвентаризаціяБібліотекиToolStripMenuItem";
            інвентаризаціяБібліотекиToolStripMenuItem.Size = new Size(216, 22);
            інвентаризаціяБібліотекиToolStripMenuItem.Text = "Інвентаризація бібліотеки";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox2);
            splitContainer1.Size = new Size(1073, 568);
            splitContainer1.SplitterDistance = 744;
            splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listBox1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(744, 568);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Книжки";
            // 
            // listBox1
            // 
            listBox1.DataSource = bookBindingSource;
            listBox1.Dock = DockStyle.Fill;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(3, 19);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(738, 546);
            listBox1.TabIndex = 0;
            // 
            // bookBindingSource
            // 
            bookBindingSource.DataSource = typeof(Models.Book);
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(trackBar2);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(trackBar1);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(comboBox3);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(comboBox2);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(button1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(325, 568);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Пошук";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(radioButton3);
            groupBox4.Controls.Add(radioButton2);
            groupBox4.Controls.Add(radioButton1);
            groupBox4.Location = new Point(207, 246);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(115, 100);
            groupBox4.TabIndex = 17;
            groupBox4.TabStop = false;
            groupBox4.Text = "Наявність книги";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(6, 72);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(63, 19);
            radioButton3.TabIndex = 18;
            radioButton3.Text = "Віддані";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(6, 47);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(88, 19);
            radioButton2.TabIndex = 17;
            radioButton2.Text = "У наявності";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(6, 22);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(41, 19);
            radioButton1.TabIndex = 16;
            radioButton1.TabStop = true;
            radioButton1.Text = "Всі";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox4);
            groupBox3.Controls.Add(textBox3);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label8);
            groupBox3.Location = new Point(8, 246);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(125, 80);
            groupBox3.TabIndex = 15;
            groupBox3.TabStop = false;
            groupBox3.Text = "Рік видання";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(38, 19);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(77, 23);
            textBox4.TabIndex = 17;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(38, 48);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(77, 23);
            textBox3.TabIndex = 19;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 22);
            label9.Name = "label9";
            label9.Size = new Size(26, 15);
            label9.TabIndex = 16;
            label9.Text = "Від:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 51);
            label8.Name = "label8";
            label8.Size = new Size(25, 15);
            label8.TabIndex = 18;
            label8.Text = "До:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(8, 205);
            label7.Name = "label7";
            label7.Size = new Size(64, 15);
            label7.TabIndex = 14;
            label7.Text = "Оцінка до:";
            // 
            // trackBar2
            // 
            trackBar2.LargeChange = 1;
            trackBar2.Location = new Point(95, 195);
            trackBar2.Maximum = 5;
            trackBar2.Minimum = 1;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(224, 45);
            trackBar2.TabIndex = 13;
            trackBar2.Value = 5;
            trackBar2.Scroll += trackBar2_Scroll;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 178);
            label6.Name = "label6";
            label6.Size = new Size(66, 15);
            label6.TabIndex = 12;
            label6.Text = "Оцінка від:";
            // 
            // trackBar1
            // 
            trackBar1.LargeChange = 1;
            trackBar1.Location = new Point(95, 168);
            trackBar1.Maximum = 5;
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(224, 45);
            trackBar1.TabIndex = 11;
            trackBar1.Value = 1;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 142);
            label5.Name = "label5";
            label5.Size = new Size(115, 15);
            label5.TabIndex = 10;
            label5.Text = "Походження книги:";
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(129, 139);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(190, 23);
            comboBox3.TabIndex = 9;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 113);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 8;
            label4.Text = "Видавництво:";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(95, 110);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(224, 23);
            comboBox2.TabIndex = 7;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 84);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 6;
            label3.Text = "Жанр:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(55, 81);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(264, 23);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(55, 52);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(264, 23);
            textBox2.TabIndex = 4;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 55);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 3;
            label2.Text = "Автор:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(89, 26);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(230, 23);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 29);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 1;
            label1.Text = "Назва книги:";
            // 
            // button1
            // 
            button1.Location = new Point(193, 518);
            button1.Name = "button1";
            button1.Size = new Size(126, 44);
            button1.TabIndex = 0;
            button1.Text = "Пошук";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PublisherEditToolStripMenuItem
            // 
            PublisherEditToolStripMenuItem.Name = "PublisherEditToolStripMenuItem";
            PublisherEditToolStripMenuItem.Size = new Size(217, 22);
            PublisherEditToolStripMenuItem.Text = "Редактор видавництв";
            PublisherEditToolStripMenuItem.Click += PublisherEditToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1073, 592);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bookBindingSource).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem FileToolStripMenuItem;
        private ToolStripMenuItem OpenLibraryToolStripMenuItem;
        private ToolStripMenuItem EditToolStripMenuItem;
        private ToolStripMenuItem EditSelectedBookToolStripMenuItem;
        private ToolStripMenuItem DeleteChoosedBookToolStripMenuItem;
        private ToolStripMenuItem звітиToolStripMenuItem;
        private ToolStripMenuItem інвентаризаціяБібліотекиToolStripMenuItem;
        private SplitContainer splitContainer1;
        private ListBox listBox1;
        private BindingSource bookBindingSource;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Label label4;
        private ComboBox comboBox2;
        private Label label3;
        private ComboBox comboBox1;
        private TextBox textBox2;
        private Label label5;
        private ComboBox comboBox3;
        private TrackBar trackBar1;
        private Label label7;
        private TrackBar trackBar2;
        private Label label6;
        private GroupBox groupBox3;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label9;
        private Label label8;
        private GroupBox groupBox4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private ToolStripMenuItem AddNewBookToolStripMenuItem;
        private ToolStripMenuItem SaveLibraryToolStripMenuItem;
        private ToolStripMenuItem GenresEditToolStripMenuItem;
        private ToolStripMenuItem PublisherEditToolStripMenuItem;
    }
}
