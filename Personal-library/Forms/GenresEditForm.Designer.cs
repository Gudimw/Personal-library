namespace Personal_library.Forms
{
    partial class GenresEditForm
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
            components = new System.ComponentModel.Container();
            btnCancel = new Button();
            btnSave = new Button();
            label1 = new Label();
            txtName = new TextBox();
            genreBindingSource = new BindingSource(components);
            label10 = new Label();
            txtDescription = new TextBox();
            lbGenres = new ListBox();
            btnAdd = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)genreBindingSource).BeginInit();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.Location = new Point(239, 313);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(102, 33);
            btnCancel.TabIndex = 16;
            btnCancel.Text = "Закрити";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(414, 310);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(102, 33);
            btnSave.TabIndex = 15;
            btnSave.Text = "OK";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += BtnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(236, 17);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 20;
            label1.Text = "Назва:";
            // 
            // txtName
            // 
            txtName.DataBindings.Add(new Binding("DataContext", genreBindingSource, "Name", true));
            txtName.DataBindings.Add(new Binding("Text", genreBindingSource, "Name", true));
            txtName.Location = new Point(284, 14);
            txtName.Name = "txtName";
            txtName.Size = new Size(232, 23);
            txtName.TabIndex = 21;
            // 
            // genreBindingSource
            // 
            genreBindingSource.DataSource = typeof(Models.Genre);
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(239, 46);
            label10.Name = "label10";
            label10.Size = new Size(39, 15);
            label10.TabIndex = 23;
            label10.Text = "Опис:";
            // 
            // txtDescription
            // 
            txtDescription.DataBindings.Add(new Binding("DataContext", genreBindingSource, "Description", true));
            txtDescription.DataBindings.Add(new Binding("Text", genreBindingSource, "Description", true));
            txtDescription.Location = new Point(284, 43);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(232, 71);
            txtDescription.TabIndex = 22;
            // 
            // lbGenres
            // 
            lbGenres.DataSource = genreBindingSource;
            lbGenres.DisplayMember = "Name";
            lbGenres.FormattingEnabled = true;
            lbGenres.ItemHeight = 15;
            lbGenres.Location = new Point(12, 12);
            lbGenres.Name = "lbGenres";
            lbGenres.Size = new Size(218, 334);
            lbGenres.TabIndex = 24;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(239, 143);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(80, 23);
            btnAdd.TabIndex = 25;
            btnAdd.Text = "Додати";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(436, 143);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(80, 23);
            btnDelete.TabIndex = 26;
            btnDelete.Text = "Видалити";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += BtnDelete_Click;
            // 
            // GenresEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(528, 355);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(lbGenres);
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(label10);
            Controls.Add(txtDescription);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Name = "GenresEditForm";
            Text = "Управління жанрами";
            Load += GenresEditForm_Load;
            ((System.ComponentModel.ISupportInitialize)genreBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Button btnSave;
        private Label label1;
        private TextBox txtName;
        private Label label10;
        private TextBox txtDescription;
        private ListBox lbGenres; // Змінено назву
        private Button btnAdd;     // Змінено назву
        private Button btnDelete;  // Змінено назву
        private BindingSource genreBindingSource;
    }
}