namespace VMS
{
    partial class Home
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            InVisitors = new Label();
            OutVisitors = new Label();
            ExpiredVisitors = new Label();
            newPassBtn = new Button();
            checkedListBtn = new Button();
            CheckedOutListBtn = new Button();
            expiredListBtn = new Button();
            checkOutBtn = new Button();
            checkInBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(0, 192, 0);
            label1.Location = new Point(70, 128);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 0;
            label1.Text = "Checked In:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(830, 128);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 1;
            label2.Text = "Expired:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.Blue;
            label3.Location = new Point(415, 128);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 2;
            label3.Text = "Checked Out:";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(38, 190);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(987, 265);
            dataGridView1.TabIndex = 3;
            // 
            // InVisitors
            // 
            InVisitors.AutoSize = true;
            InVisitors.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            InVisitors.ForeColor = Color.FromArgb(0, 192, 0);
            InVisitors.Location = new Point(153, 128);
            InVisitors.Name = "InVisitors";
            InVisitors.Size = new Size(14, 15);
            InVisitors.TabIndex = 4;
            InVisitors.Text = "0";
            // 
            // OutVisitors
            // 
            OutVisitors.AutoSize = true;
            OutVisitors.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            OutVisitors.ForeColor = Color.Blue;
            OutVisitors.Location = new Point(508, 128);
            OutVisitors.Name = "OutVisitors";
            OutVisitors.Size = new Size(14, 15);
            OutVisitors.TabIndex = 5;
            OutVisitors.Text = "0";
            // 
            // ExpiredVisitors
            // 
            ExpiredVisitors.AutoSize = true;
            ExpiredVisitors.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ExpiredVisitors.ForeColor = Color.Red;
            ExpiredVisitors.Location = new Point(892, 128);
            ExpiredVisitors.Name = "ExpiredVisitors";
            ExpiredVisitors.Size = new Size(14, 15);
            ExpiredVisitors.TabIndex = 6;
            ExpiredVisitors.Text = "0";
            // 
            // newPassBtn
            // 
            newPassBtn.BackColor = Color.FromArgb(0, 192, 192);
            newPassBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            newPassBtn.ForeColor = Color.White;
            newPassBtn.Location = new Point(49, 43);
            newPassBtn.Margin = new Padding(3, 2, 3, 2);
            newPassBtn.Name = "newPassBtn";
            newPassBtn.Size = new Size(191, 30);
            newPassBtn.TabIndex = 7;
            newPassBtn.Text = "NEW PASS";
            newPassBtn.UseVisualStyleBackColor = false;
            newPassBtn.Click += button1_Click;
            // 
            // checkedListBtn
            // 
            checkedListBtn.BackColor = Color.Lime;
            checkedListBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkedListBtn.ForeColor = Color.White;
            checkedListBtn.Location = new Point(49, 155);
            checkedListBtn.Margin = new Padding(3, 2, 3, 2);
            checkedListBtn.Name = "checkedListBtn";
            checkedListBtn.Size = new Size(174, 31);
            checkedListBtn.TabIndex = 8;
            checkedListBtn.Text = "CHECKED IN LIST";
            checkedListBtn.UseVisualStyleBackColor = false;
            checkedListBtn.Click += checkedListBtn_Click;
            // 
            // CheckedOutListBtn
            // 
            CheckedOutListBtn.BackColor = Color.Blue;
            CheckedOutListBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CheckedOutListBtn.ForeColor = Color.White;
            CheckedOutListBtn.Location = new Point(415, 154);
            CheckedOutListBtn.Margin = new Padding(3, 2, 3, 2);
            CheckedOutListBtn.Name = "CheckedOutListBtn";
            CheckedOutListBtn.Size = new Size(183, 31);
            CheckedOutListBtn.TabIndex = 9;
            CheckedOutListBtn.Text = "CHECKED OUT LIST";
            CheckedOutListBtn.UseVisualStyleBackColor = false;
            CheckedOutListBtn.Click += CheckedOutListBtn_Click;
            // 
            // expiredListBtn
            // 
            expiredListBtn.BackColor = Color.Red;
            expiredListBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            expiredListBtn.ForeColor = Color.White;
            expiredListBtn.Location = new Point(830, 154);
            expiredListBtn.Margin = new Padding(3, 2, 3, 2);
            expiredListBtn.Name = "expiredListBtn";
            expiredListBtn.Size = new Size(186, 32);
            expiredListBtn.TabIndex = 10;
            expiredListBtn.Text = "EXPIRED LIST:";
            expiredListBtn.UseVisualStyleBackColor = false;
            expiredListBtn.Click += expiredListBtn_Click;
            // 
            // checkOutBtn
            // 
            checkOutBtn.BackColor = Color.Olive;
            checkOutBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkOutBtn.ForeColor = Color.White;
            checkOutBtn.Location = new Point(830, 43);
            checkOutBtn.Margin = new Padding(3, 2, 3, 2);
            checkOutBtn.Name = "checkOutBtn";
            checkOutBtn.Size = new Size(186, 30);
            checkOutBtn.TabIndex = 11;
            checkOutBtn.Text = "CHECK OUT";
            checkOutBtn.UseVisualStyleBackColor = false;
            checkOutBtn.Click += checkOutBtn_Click;
            // 
            // checkInBtn
            // 
            checkInBtn.BackColor = Color.Green;
            checkInBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkInBtn.ForeColor = Color.White;
            checkInBtn.Location = new Point(415, 43);
            checkInBtn.Margin = new Padding(3, 2, 3, 2);
            checkInBtn.Name = "checkInBtn";
            checkInBtn.Size = new Size(183, 30);
            checkInBtn.TabIndex = 12;
            checkInBtn.Text = "CHECK IN";
            checkInBtn.UseVisualStyleBackColor = false;
            checkInBtn.Click += button6_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(checkInBtn);
            Controls.Add(checkOutBtn);
            Controls.Add(expiredListBtn);
            Controls.Add(CheckedOutListBtn);
            Controls.Add(checkedListBtn);
            Controls.Add(newPassBtn);
            Controls.Add(ExpiredVisitors);
            Controls.Add(OutVisitors);
            Controls.Add(InVisitors);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Home";
            Size = new Size(1095, 595);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dataGridView1;
        private Label InVisitors;
        private Label OutVisitors;
        private Label ExpiredVisitors;
        private Button newPassBtn;
        private Button checkedListBtn;
        private Button CheckedOutListBtn;
        private Button expiredListBtn;
        private Button checkOutBtn;
        private Button checkInBtn;
    }
}
