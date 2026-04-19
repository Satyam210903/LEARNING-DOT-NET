namespace VMS
{
    partial class Register
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
            button1 = new Button();
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            maskedTextBox1 = new MaskedTextBox();
            linkLabel1 = new LinkLabel();
            label8 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(307, 25);
            label1.Name = "label1";
            label1.Size = new Size(144, 38);
            label1.TabIndex = 0;
            label1.Text = "REGISTER";
            // 
            // button1
            // 
            button1.BackColor = Color.Teal;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(254, 260);
            button1.Name = "button1";
            button1.Size = new Size(281, 41);
            button1.TabIndex = 1;
            button1.Text = "REGISTER";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(353, 101);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(197, 27);
            textBox1.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(353, 209);
            textBox3.Name = "textBox3";
            textBox3.PasswordChar = '*';
            textBox3.Size = new Size(197, 27);
            textBox3.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(204, 101);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 5;
            label2.Text = "USERNAME:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(204, 159);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 6;
            label3.Text = "MOB:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(204, 209);
            label4.Name = "label4";
            label4.Size = new Size(90, 20);
            label4.TabIndex = 7;
            label4.Text = "PASSWORD:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Red;
            label5.Location = new Point(294, 91);
            label5.Name = "label5";
            label5.Size = new Size(15, 20);
            label5.TabIndex = 8;
            label5.Text = "*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Red;
            label6.Location = new Point(245, 149);
            label6.Name = "label6";
            label6.Size = new Size(15, 20);
            label6.TabIndex = 9;
            label6.Text = "*";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Red;
            label7.Location = new Point(294, 199);
            label7.Name = "label7";
            label7.Size = new Size(15, 20);
            label7.TabIndex = 10;
            label7.Text = "*";
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(353, 159);
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(197, 27);
            maskedTextBox1.TabIndex = 11;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkVisited = true;
            linkLabel1.Location = new Point(423, 314);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(87, 20);
            linkLabel1.TabIndex = 12;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "CLICK HERE";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(230, 314);
            label8.Name = "label8";
            label8.Size = new Size(196, 20);
            label8.TabIndex = 13;
            label8.Text = "ALREADY HAVE ACCOUNT ?";
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label8);
            Controls.Add(linkLabel1);
            Controls.Add(maskedTextBox1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox3;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private MaskedTextBox maskedTextBox1;
        private LinkLabel linkLabel1;
        private Label label8;
    }
}