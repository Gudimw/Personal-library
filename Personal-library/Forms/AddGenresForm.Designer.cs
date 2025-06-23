namespace Personal_library.Forms
{
    partial class AddGenresForm
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
            label1 = new Label();
            txtName = new TextBox();
            label10 = new Label();
            txtDescription = new TextBox();
            btnCancel = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 14);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 24;
            label1.Text = "Назва:";
            // 
            // txtName
            // 
            txtName.Location = new Point(58, 11);
            txtName.Name = "txtName";
            txtName.Size = new Size(232, 23);
            txtName.TabIndex = 25;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(13, 43);
            label10.Name = "label10";
            label10.Size = new Size(39, 15);
            label10.TabIndex = 27;
            label10.Text = "Опис:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(58, 40);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(232, 71);
            txtDescription.TabIndex = 26;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.Location = new Point(10, 183);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(102, 33);
            btnCancel.TabIndex = 29;
            btnCancel.Text = "Закрити";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(188, 183);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(102, 33);
            btnSave.TabIndex = 28;
            btnSave.Text = "OK";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // AddGenresForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(301, 228);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(label10);
            Controls.Add(txtDescription);
            Name = "AddGenresForm";
            Text = "Додавання нового жанру";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private Label label10;
        private TextBox txtDescription;
        private Button btnCancel;
        private Button btnSave;
    }
}