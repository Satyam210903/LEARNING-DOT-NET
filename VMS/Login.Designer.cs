namespace VMS
{
    partial class Login
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            userTxt = new TextBox();
            passTxt = new TextBox();
            button1 = new Button();
            label6 = new Label();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(327, 47);
            label1.Name = "label1";
            label1.Size = new Size(209, 38);
            label1.TabIndex = 0;
            label1.Text = "ADMIN LOGIN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(137, 133);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 1;
            label2.Text = "USERNAME:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(137, 184);
            label3.Name = "label3";
            label3.Size = new Size(90, 20);
            label3.TabIndex = 2;
            label3.Text = "PASSWORD:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(222, 126);
            label4.Name = "label4";
            label4.Size = new Size(16, 20);
            label4.TabIndex = 3;
            label4.Text = "*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(222, 177);
            label5.Name = "label5";
            label5.Size = new Size(16, 20);
            label5.TabIndex = 4;
            label5.Text = "*";
            // 
            // userTxt
            // 
            userTxt.Location = new Point(272, 126);
            userTxt.Name = "userTxt";
            userTxt.Size = new Size(322, 27);
            userTxt.TabIndex = 5;
            // 
            // passTxt
            // 
            passTxt.Location = new Point(272, 177);
            passTxt.Name = "passTxt";
            passTxt.PasswordChar = '*';
            passTxt.Size = new Size(322, 27);
            passTxt.TabIndex = 6;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(272, 233);
            button1.Name = "button1";
            button1.Size = new Size(322, 37);
            button1.TabIndex = 7;
            button1.Text = "LOGIN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(262, 287);
            label6.Name = "label6";
            label6.Size = new Size(132, 20);
            label6.TabIndex = 8;
            label6.Text = "CREATE ACCOUNT";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(400, 287);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(87, 20);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "CLICK HERE";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(linkLabel1);
            Controls.Add(label6);
            Controls.Add(button1);
            Controls.Add(passTxt);
            Controls.Add(userTxt);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox userTxt;
        private TextBox passTxt;
        private Button button1;
        private Label label6;
        private LinkLabel linkLabel1;
    }
}