namespace VMS
{
    partial class In
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
            button1 = new Button();
            maskedTextBox1 = new MaskedTextBox();
            label2 = new Label();
            label1 = new Label();
            pictureBoxCamera = new PictureBox();
            scanBarcode = new Button();
            startCamera = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCamera).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Olive;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(707, 240);
            button1.Name = "button1";
            button1.Size = new Size(263, 58);
            button1.TabIndex = 10;
            button1.Text = "CHECK IN ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(778, 178);
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(222, 27);
            maskedTextBox1.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(650, 185);
            label2.Name = "label2";
            label2.Size = new Size(103, 20);
            label2.TabIndex = 8;
            label2.Text = "CONTACT NO:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(717, 101);
            label1.Name = "label1";
            label1.Size = new Size(253, 31);
            label1.TabIndex = 7;
            label1.Text = "CHECK IN FROM HERE";
            // 
            // pictureBoxCamera
            // 
            pictureBoxCamera.BackColor = Color.FromArgb(224, 224, 224);
            pictureBoxCamera.BorderStyle = BorderStyle.Fixed3D;
            pictureBoxCamera.Dock = DockStyle.Left;
            pictureBoxCamera.Location = new Point(0, 0);
            pictureBoxCamera.Name = "pictureBoxCamera";
            pictureBoxCamera.Size = new Size(586, 493);
            pictureBoxCamera.TabIndex = 11;
            pictureBoxCamera.TabStop = false;
            // 
            // scanBarcode
            // 
            scanBarcode.BackColor = Color.Teal;
            scanBarcode.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            scanBarcode.ForeColor = Color.White;
            scanBarcode.Location = new Point(312, 403);
            scanBarcode.Name = "scanBarcode";
            scanBarcode.Size = new Size(270, 58);
            scanBarcode.TabIndex = 12;
            scanBarcode.Text = "SCAN BARCODE TO CHECK IN";
            scanBarcode.UseVisualStyleBackColor = false;
            scanBarcode.Click += scanBarcode_Click;
            // 
            // startCamera
            // 
            startCamera.BackColor = Color.Green;
            startCamera.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            startCamera.ForeColor = Color.White;
            startCamera.Location = new Point(30, 403);
            startCamera.Name = "startCamera";
            startCamera.Size = new Size(228, 55);
            startCamera.TabIndex = 13;
            startCamera.Text = "START";
            startCamera.UseVisualStyleBackColor = false;
            startCamera.Click += startCamera_Click;
            // 
            // In
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 493);
            Controls.Add(startCamera);
            Controls.Add(scanBarcode);
            Controls.Add(pictureBoxCamera);
            Controls.Add(button1);
            Controls.Add(maskedTextBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "In";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "In";
            ((System.ComponentModel.ISupportInitialize)pictureBoxCamera).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private MaskedTextBox maskedTextBox1;
        private Label label2;
        private Label label1;
        private PictureBox pictureBoxCamera;
        private Button scanBarcode;
        private Button startCamera;
    }
}