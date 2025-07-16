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
            txtNote = new TextBox();
            btnNewNote = new Button();
            dgvNotes = new DataGridView();
            clnIdNote = new DataGridViewTextBoxColumn();
            clnColorNote = new DataGridViewTextBoxColumn();
            clnTitleNote = new DataGridViewTextBoxColumn();
            clnDateNote = new DataGridViewTextBoxColumn();
            clnTextNote = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNotes).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(txtNote);
            panel1.Controls.Add(btnNewNote);
            panel1.Controls.Add(dgvNotes);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(360, 337);
            panel1.TabIndex = 0;
            // 
            // txtNote
            // 
            txtNote.Location = new Point(-3, 90);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(0, 0);
            txtNote.TabIndex = 4;
            // 
            // btnNewNote
            // 
            btnNewNote.Font = new Font("SimSun-ExtB", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNewNote.Location = new Point(141, 268);
            btnNewNote.Name = "btnNewNote";
            btnNewNote.Size = new Size(75, 69);
            btnNewNote.TabIndex = 1;
            btnNewNote.Text = "I";
            btnNewNote.UseVisualStyleBackColor = true;
            btnNewNote.Click += btnNewNote_Click;
            // 
            // dgvNotes
            // 
            dgvNotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNotes.Columns.AddRange(new DataGridViewColumn[] { clnIdNote, clnColorNote, clnTitleNote, clnDateNote, clnTextNote });
            dgvNotes.Location = new Point(0, 0);
            dgvNotes.Name = "dgvNotes";
            dgvNotes.RowHeadersVisible = false;
            dgvNotes.Size = new Size(360, 337);
            dgvNotes.TabIndex = 2;
            // 
            // clnIdNote
            // 
            clnIdNote.HeaderText = "ID";
            clnIdNote.Name = "clnIdNote";
            clnIdNote.ReadOnly = true;
            clnIdNote.Visible = false;
            clnIdNote.Width = 25;
            // 
            // clnColorNote
            // 
            clnColorNote.HeaderText = "Color";
            clnColorNote.Name = "clnColorNote";
            clnColorNote.ReadOnly = true;
            clnColorNote.Visible = false;
            clnColorNote.Width = 45;
            // 
            // clnTitleNote
            // 
            clnTitleNote.HeaderText = "Title";
            clnTitleNote.Name = "clnTitleNote";
            clnTitleNote.ReadOnly = true;
            clnTitleNote.Width = 290;
            // 
            // clnDateNote
            // 
            clnDateNote.HeaderText = "Date";
            clnDateNote.Name = "clnDateNote";
            clnDateNote.ReadOnly = true;
            clnDateNote.Width = 66;
            // 
            // clnTextNote
            // 
            clnTextNote.HeaderText = "Text";
            clnTextNote.Name = "clnTextNote";
            clnTextNote.ReadOnly = true;
            clnTextNote.Visible = false;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(panel1);
            Name = "FrmMain";
            Text = "-";
            Load += FrmMain_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNotes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnNewNote;
        private DataGridView dgvNotes;
        private DataGridViewTextBoxColumn clnId;
        private DataGridViewTextBoxColumn clnColor;
        private DataGridViewTextBoxColumn clnTitle;
        private DataGridViewTextBoxColumn clnDate;
        private DataGridViewTextBoxColumn clnText;
        private DataGridViewTextBoxColumn clnIdNote;
        private DataGridViewTextBoxColumn clnColorNote;
        private DataGridViewTextBoxColumn clnTitleNote;
        private DataGridViewTextBoxColumn clnDateNote;
        private DataGridViewTextBoxColumn clnTextNote;
        private TextBox txtNote;
    }
}
