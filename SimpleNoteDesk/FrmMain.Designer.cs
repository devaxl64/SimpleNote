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
            dgvLevels = new DataGridView();
            button1 = new Button();
            dgvNotes = new DataGridView();
            clnIdNote = new DataGridViewTextBoxColumn();
            clnColorNote = new DataGridViewTextBoxColumn();
            clnTitleNote = new DataGridViewTextBoxColumn();
            clnDateNote = new DataGridViewTextBoxColumn();
            clnTextNote = new DataGridViewTextBoxColumn();
            clnIdLevel = new DataGridViewTextBoxColumn();
            clnNameLevel = new DataGridViewTextBoxColumn();
            clnAkaLevel = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLevels).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvNotes).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(dgvNotes);
            panel1.Controls.Add(dgvLevels);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(359, 273);
            panel1.TabIndex = 0;
            // 
            // dgvLevels
            // 
            dgvLevels.AllowUserToAddRows = false;
            dgvLevels.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLevels.Columns.AddRange(new DataGridViewColumn[] { clnIdLevel, clnNameLevel, clnAkaLevel });
            dgvLevels.Location = new Point(0, 0);
            dgvLevels.Name = "dgvLevels";
            dgvLevels.RowHeadersVisible = false;
            dgvLevels.Size = new Size(359, 273);
            dgvLevels.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(142, 204);
            button1.Name = "button1";
            button1.Size = new Size(75, 69);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // dgvNotes
            // 
            dgvNotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNotes.Columns.AddRange(new DataGridViewColumn[] { clnIdNote, clnColorNote, clnTitleNote, clnDateNote, clnTextNote });
            dgvNotes.Location = new Point(0, 0);
            dgvNotes.Name = "dgvNotes";
            dgvNotes.RowHeadersVisible = false;
            dgvNotes.Size = new Size(359, 273);
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
            // clnIdLevel
            // 
            clnIdLevel.HeaderText = "ID";
            clnIdLevel.Name = "clnIdLevel";
            clnIdLevel.ReadOnly = true;
            clnIdLevel.Width = 45;
            // 
            // clnNameLevel
            // 
            clnNameLevel.HeaderText = "Nome";
            clnNameLevel.Name = "clnNameLevel";
            clnNameLevel.ReadOnly = true;
            clnNameLevel.Width = 245;
            // 
            // clnAkaLevel
            // 
            clnAkaLevel.HeaderText = "Sigla";
            clnAkaLevel.Name = "clnAkaLevel";
            clnAkaLevel.ReadOnly = true;
            clnAkaLevel.Width = 66;
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
            ((System.ComponentModel.ISupportInitialize)dgvLevels).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvNotes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private DataGridView dgvNotes;
        private DataGridViewTextBoxColumn clnId;
        private DataGridViewTextBoxColumn clnColor;
        private DataGridViewTextBoxColumn clnTitle;
        private DataGridViewTextBoxColumn clnDate;
        private DataGridViewTextBoxColumn clnText;
        private DataGridView dgvLevels;
        private DataGridViewTextBoxColumn clnIdNote;
        private DataGridViewTextBoxColumn clnColorNote;
        private DataGridViewTextBoxColumn clnTitleNote;
        private DataGridViewTextBoxColumn clnDateNote;
        private DataGridViewTextBoxColumn clnTextNote;
        private DataGridViewTextBoxColumn clnIdLevel;
        private DataGridViewTextBoxColumn clnNameLevel;
        private DataGridViewTextBoxColumn clnAkaLevel;
    }
}
