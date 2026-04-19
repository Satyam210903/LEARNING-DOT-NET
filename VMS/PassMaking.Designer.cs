namespace VMS
{
    partial class PassMaking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PassMaking));
            pictureBoxCamera = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label6 = new Label();
            visitorName = new TextBox();
            visitPurpose = new TextBox();
            makePassBtn = new Button();
            label7 = new Label();
            label8 = new Label();
            label10 = new Label();
            label12 = new Label();
            label13 = new Label();
            checkinTime = new DateTimePicker();
            startBtn = new Button();
            captureBtn = new Button();
            stopBtn = new Button();
            contactNo = new MaskedTextBox();
            pictureBoxPhoto = new PictureBox();
            label3 = new Label();
            label9 = new Label();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();
            pictureBoxBarcode = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCamera).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBarcode).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxCamera
            // 
            pictureBoxCamera.BackColor = Color.FromArgb(224, 224, 224);
            pictureBoxCamera.BackgroundImageLayout = ImageLayout.Center;
            pictureBoxCamera.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxCamera.Location = new Point(10, 58);
            pictureBoxCamera.Margin = new Padding(3, 2, 3, 2);
            pictureBoxCamera.Name = "pictureBoxCamera";
            pictureBoxCamera.Size = new Size(334, 280);
            pictureBoxCamera.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxCamera.TabIndex = 0;
            pictureBoxCamera.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(750, 93);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 1;
            label1.Text = "Visitor Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(760, 145);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 2;
            label2.Text = "Contact No:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(735, 198);
            label4.Name = "label4";
            label4.Size = new Size(92, 15);
            label4.TabIndex = 4;
            label4.Text = "Purpose of Visit:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(750, 37);
            label6.Name = "label6";
            label6.Size = new Size(238, 25);
            label6.TabIndex = 6;
            label6.Text = "Provide Following Details";
            // 
            // visitorName
            // 
            visitorName.Location = new Point(849, 91);
            visitorName.Margin = new Padding(3, 2, 3, 2);
            visitorName.Name = "visitorName";
            visitorName.Size = new Size(214, 23);
            visitorName.TabIndex = 7;
            // 
            // visitPurpose
            // 
            visitPurpose.Location = new Point(846, 198);
            visitPurpose.Margin = new Padding(3, 2, 3, 2);
            visitPurpose.Name = "visitPurpose";
            visitPurpose.Size = new Size(217, 23);
            visitPurpose.TabIndex = 10;
            // 
            // makePassBtn
            // 
            makePassBtn.BackColor = Color.FromArgb(0, 192, 0);
            makePassBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            makePassBtn.ForeColor = Color.White;
            makePassBtn.Location = new Point(774, 366);
            makePassBtn.Margin = new Padding(3, 2, 3, 2);
            makePassBtn.Name = "makePassBtn";
            makePassBtn.Size = new Size(299, 40);
            makePassBtn.TabIndex = 12;
            makePassBtn.Text = "MAKE PASS";
            makePassBtn.UseVisualStyleBackColor = false;
            makePassBtn.Click += makePassBtn_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Red;
            label7.Location = new Point(830, 91);
            label7.Name = "label7";
            label7.Size = new Size(12, 15);
            label7.TabIndex = 13;
            label7.Text = "*";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.Red;
            label8.Location = new Point(830, 138);
            label8.Name = "label8";
            label8.Size = new Size(12, 15);
            label8.TabIndex = 14;
            label8.Text = "*";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.Red;
            label10.Location = new Point(830, 190);
            label10.Name = "label10";
            label10.Size = new Size(12, 15);
            label10.TabIndex = 16;
            label10.Text = "*";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(782, 259);
            label12.Name = "label12";
            label12.Size = new Size(48, 15);
            label12.TabIndex = 18;
            label12.Text = "Validity:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = Color.Red;
            label13.Location = new Point(830, 255);
            label13.Name = "label13";
            label13.Size = new Size(12, 15);
            label13.TabIndex = 19;
            label13.Text = "*";
            // 
            // checkinTime
            // 
            checkinTime.CalendarTitleBackColor = Color.Red;
            checkinTime.CustomFormat = "dd/MM/yyyy";
            checkinTime.Location = new Point(849, 255);
            checkinTime.Margin = new Padding(3, 2, 3, 2);
            checkinTime.Name = "checkinTime";
            checkinTime.Size = new Size(217, 23);
            checkinTime.TabIndex = 20;
            checkinTime.Value = new DateTime(2026, 1, 2, 0, 0, 0, 0);
            // 
            // startBtn
            // 
            startBtn.BackColor = Color.Blue;
            startBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            startBtn.ForeColor = Color.White;
            startBtn.Location = new Point(60, 364);
            startBtn.Margin = new Padding(3, 2, 3, 2);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(220, 41);
            startBtn.TabIndex = 21;
            startBtn.Text = "START";
            startBtn.UseVisualStyleBackColor = false;
            startBtn.Click += startBtn_Click;
            // 
            // captureBtn
            // 
            captureBtn.BackColor = Color.FromArgb(0, 192, 192);
            captureBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            captureBtn.ForeColor = Color.White;
            captureBtn.Location = new Point(401, 366);
            captureBtn.Margin = new Padding(3, 2, 3, 2);
            captureBtn.Name = "captureBtn";
            captureBtn.Size = new Size(210, 40);
            captureBtn.TabIndex = 22;
            captureBtn.Text = "CAPTURE";
            captureBtn.UseVisualStyleBackColor = false;
            captureBtn.Click += captureBtn_Click;
            // 
            // stopBtn
            // 
            stopBtn.BackColor = Color.Red;
            stopBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            stopBtn.ForeColor = Color.White;
            stopBtn.Location = new Point(182, 430);
            stopBtn.Margin = new Padding(3, 2, 3, 2);
            stopBtn.Name = "stopBtn";
            stopBtn.Size = new Size(336, 39);
            stopBtn.TabIndex = 23;
            stopBtn.Text = "STOP";
            stopBtn.UseVisualStyleBackColor = false;
            stopBtn.Click += stopBtn_Click;
            // 
            // contactNo
            // 
            contactNo.Location = new Point(849, 145);
            contactNo.Margin = new Padding(3, 2, 3, 2);
            contactNo.Name = "contactNo";
            contactNo.Size = new Size(214, 23);
            contactNo.TabIndex = 24;
            // 
            // pictureBoxPhoto
            // 
            pictureBoxPhoto.BackColor = Color.FromArgb(224, 224, 224);
            pictureBoxPhoto.BackgroundImageLayout = ImageLayout.Center;
            pictureBoxPhoto.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxPhoto.Location = new Point(360, 58);
            pictureBoxPhoto.Margin = new Padding(3, 2, 3, 2);
            pictureBoxPhoto.Name = "pictureBoxPhoto";
            pictureBoxPhoto.Size = new Size(348, 280);
            pictureBoxPhoto.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxPhoto.TabIndex = 25;
            pictureBoxPhoto.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Red;
            label3.Location = new Point(91, 340);
            label3.Name = "label3";
            label3.Size = new Size(122, 15);
            label3.TabIndex = 26;
            label3.Text = "<<   Live Camera   >>";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.FromArgb(0, 64, 0);
            label9.Location = new Point(446, 340);
            label9.Name = "label9";
            label9.Size = new Size(148, 15);
            label9.TabIndex = 27;
            label9.Text = "<<     Captured Image   >>";
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // pictureBoxBarcode
            // 
            pictureBoxBarcode.Location = new Point(760, 307);
            pictureBoxBarcode.Margin = new Padding(3, 2, 3, 2);
            pictureBoxBarcode.Name = "pictureBoxBarcode";
            pictureBoxBarcode.Size = new Size(305, 48);
            pictureBoxBarcode.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxBarcode.TabIndex = 28;
            pictureBoxBarcode.TabStop = false;
            // 
            // PassMaking
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1083, 472);
            Controls.Add(pictureBoxBarcode);
            Controls.Add(label9);
            Controls.Add(label3);
            Controls.Add(pictureBoxPhoto);
            Controls.Add(contactNo);
            Controls.Add(stopBtn);
            Controls.Add(captureBtn);
            Controls.Add(startBtn);
            Controls.Add(checkinTime);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label10);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(makePassBtn);
            Controls.Add(visitPurpose);
            Controls.Add(visitorName);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBoxCamera);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PassMaking";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += PassMaking_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxCamera).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBarcode).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxCamera;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label6;
        private TextBox visitorName;
        private TextBox visitPurpose;
        private Button makePassBtn;
        private Label label7;
        private Label label8;
        private Label label10;
        private Label label12;
        private Label label13;
        private DateTimePicker checkinTime;
        private Button startBtn;
        private Button captureBtn;
        private Button stopBtn;
        private MaskedTextBox contactNo;
        private PictureBox pictureBoxPhoto;
        private Label label3;
        private Label label9;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
        private PictureBox pictureBoxBarcode;
    }
}