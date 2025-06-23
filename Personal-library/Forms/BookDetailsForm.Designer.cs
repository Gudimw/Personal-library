namespace Personal_library.Forms
{
    partial class BookDetailsForm
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            comboBox1 = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            label6 = new Label();
            comboBox2 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label10 = new Label();
            textBox5 = new TextBox();
            label9 = new Label();
            trackBar1 = new TrackBar();
            textBox4 = new TextBox();
            label8 = new Label();
            checkBox1 = new CheckBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 22);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "Назва:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(55, 19);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(55, 48);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 50);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 2;
            label2.Text = "Автор:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(94, 76);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 79);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 4;
            label3.Text = "Видавництво:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 108);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 6;
            label4.Text = "Рік видання:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 139);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 8;
            label5.Text = "Жанр:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(54, 136);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 9;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(87, 105);
            numericUpDown1.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 10;
            numericUpDown1.Value = new decimal(new int[] { 2025, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 25);
            label6.Name = "label6";
            label6.Size = new Size(115, 15);
            label6.TabIndex = 11;
            label6.Text = "Походження книги:";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(127, 22);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 12;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(303, 434);
            button1.Name = "button1";
            button1.Size = new Size(102, 33);
            button1.TabIndex = 13;
            button1.Text = "Зберегти";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BtnCancel_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.Location = new Point(12, 434);
            button2.Name = "button2";
            button2.Size = new Size(102, 33);
            button2.TabIndex = 14;
            button2.Text = "Скасувати";
            button2.UseVisualStyleBackColor = true;
            button1.Click += BtnSave_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(393, 170);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Основна інформація";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(textBox5);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(trackBar1);
            groupBox2.Controls.Add(textBox4);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(checkBox1);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(comboBox2);
            groupBox2.Location = new Point(12, 188);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(393, 235);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "Додаткова інформація та статус";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(7, 154);
            label10.Name = "label10";
            label10.Size = new Size(39, 15);
            label10.TabIndex = 19;
            label10.Text = "Опис:";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(52, 151);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(258, 71);
            textBox5.TabIndex = 18;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(7, 120);
            label9.Name = "label9";
            label9.Size = new Size(54, 15);
            label9.TabIndex = 17;
            label9.Text = "Рейтинг:";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(67, 110);
            trackBar1.Maximum = 5;
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(104, 45);
            trackBar1.TabIndex = 16;
            trackBar1.Value = 1;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(95, 81);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(7, 84);
            label8.Name = "label8";
            label8.Size = new Size(82, 15);
            label8.TabIndex = 15;
            label8.Text = "Кому віддана:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(89, 57);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 14;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(7, 56);
            label7.Name = "label7";
            label7.Size = new Size(76, 15);
            label7.TabIndex = 13;
            label7.Text = "Доступність:";
            // 
            // BookDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 479);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "BookDetailsForm";
            Text = "Додати книгу";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox comboBox1;
        private NumericUpDown numericUpDown1;
        private Label label6;
        private ComboBox comboBox2;
        private Button button1;
        private Button button2;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label8;
        private CheckBox checkBox1;
        private Label label7;
        private Label label10;
        private TextBox textBox5;
        private Label label9;
        private TrackBar trackBar1;
        private TextBox textBox4;
    }
}