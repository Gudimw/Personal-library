namespace Personal_library
{
    partial class Form1
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
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            OpenLibraryToolStripMenuItem = new ToolStripMenuItem();
            AddNewBookToolStripMenuItem = new ToolStripMenuItem();
            редагуванняToolStripMenuItem = new ToolStripMenuItem();
            редагуватиВибрануКнигуToolStripMenuItem = new ToolStripMenuItem();
            видалитиВибрануКнигуToolStripMenuItem = new ToolStripMenuItem();
            звітиToolStripMenuItem = new ToolStripMenuItem();
            інвентаризаціяБібліотекиToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, редагуванняToolStripMenuItem, звітиToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(995, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { OpenLibraryToolStripMenuItem, AddNewBookToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // OpenLibraryToolStripMenuItem
            // 
            OpenLibraryToolStripMenuItem.Name = "OpenLibraryToolStripMenuItem";
            OpenLibraryToolStripMenuItem.Size = new Size(191, 22);
            OpenLibraryToolStripMenuItem.Text = "Відкрити бібліотеку...";
            OpenLibraryToolStripMenuItem.Click += OpenLibraryToolStripMenuItem_Click;
            // 
            // AddNewBookToolStripMenuItem
            // 
            AddNewBookToolStripMenuItem.Name = "AddNewBookToolStripMenuItem";
            AddNewBookToolStripMenuItem.Size = new Size(191, 22);
            AddNewBookToolStripMenuItem.Text = "Додати нову книгу";
            // 
            // редагуванняToolStripMenuItem
            // 
            редагуванняToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { редагуватиВибрануКнигуToolStripMenuItem, видалитиВибрануКнигуToolStripMenuItem });
            редагуванняToolStripMenuItem.Name = "редагуванняToolStripMenuItem";
            редагуванняToolStripMenuItem.Size = new Size(87, 20);
            редагуванняToolStripMenuItem.Text = "Редагування";
            // 
            // редагуватиВибрануКнигуToolStripMenuItem
            // 
            редагуватиВибрануКнигуToolStripMenuItem.Name = "редагуватиВибрануКнигуToolStripMenuItem";
            редагуватиВибрануКнигуToolStripMenuItem.Size = new Size(217, 22);
            редагуватиВибрануКнигуToolStripMenuItem.Text = "Редагувати вибрану книгу";
            // 
            // видалитиВибрануКнигуToolStripMenuItem
            // 
            видалитиВибрануКнигуToolStripMenuItem.Name = "видалитиВибрануКнигуToolStripMenuItem";
            видалитиВибрануКнигуToolStripMenuItem.Size = new Size(217, 22);
            видалитиВибрануКнигуToolStripMenuItem.Text = "Видалити вибрану книгу";
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
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Size = new Size(995, 568);
            splitContainer1.SplitterDistance = 767;
            splitContainer1.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(995, 592);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem OpenLibraryToolStripMenuItem;
        private ToolStripMenuItem AddNewBookToolStripMenuItem;
        private ToolStripMenuItem редагуванняToolStripMenuItem;
        private ToolStripMenuItem редагуватиВибрануКнигуToolStripMenuItem;
        private ToolStripMenuItem видалитиВибрануКнигуToolStripMenuItem;
        private ToolStripMenuItem звітиToolStripMenuItem;
        private ToolStripMenuItem інвентаризаціяБібліотекиToolStripMenuItem;
        private SplitContainer splitContainer1;
    }
}
