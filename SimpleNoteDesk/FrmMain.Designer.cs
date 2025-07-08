namespace SimpleNoteDesk
{
    partial class FrmMain
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
            panel1 = new Panel();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            ClnID = new DataGridViewTextBoxColumn();
            ClnColor = new DataGridViewTextBoxColumn();
            ClnTitle = new DataGridViewTextBoxColumn();
            ClnDate = new DataGridViewTextBoxColumn();
            ClnText = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(359, 273);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(142, 214);
            button1.Name = "button1";
            button1.Size = new Size(75, 69);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ClnID, ClnColor, ClnTitle, ClnDate, ClnText });
            dataGridView1.Location = new Point(0, 10);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(359, 273);
            dataGridView1.TabIndex = 0;
            // 
            // ClnID
            // 
            ClnID.HeaderText = "ID";
            ClnID.MinimumWidth = 15;
            ClnID.Name = "ClnID";
            ClnID.ReadOnly = true;
            ClnID.Visible = false;
            ClnID.Width = 25;
            // 
            // ClnColor
            // 
            ClnColor.HeaderText = "Color";
            ClnColor.Name = "ClnColor";
            ClnColor.ReadOnly = true;
            ClnColor.Width = 45;
            // 
            // ClnTitle
            // 
            ClnTitle.HeaderText = "Title";
            ClnTitle.Name = "ClnTitle";
            ClnTitle.ReadOnly = true;
            ClnTitle.Width = 250;
            // 
            // ClnDate
            // 
            ClnDate.HeaderText = "Date";
            ClnDate.Name = "ClnDate";
            ClnDate.ReadOnly = true;
            ClnDate.Width = 61;
            // 
            // ClnText
            // 
            ClnText.HeaderText = "Text";
            ClnText.Name = "ClnText";
            ClnText.ReadOnly = true;
            ClnText.Visible = false;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(383, 297);
            Controls.Add(panel1);
            Name = "FrmMain";
            Text = "Form1";
            Load += FrmMain_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridView1;
        private Button button1;
        private DataGridViewTextBoxColumn ClnID;
        private DataGridViewTextBoxColumn ClnColor;
        private DataGridViewTextBoxColumn ClnTitle;
        private DataGridViewTextBoxColumn ClnDate;
        private DataGridViewTextBoxColumn ClnText;
    }
}
