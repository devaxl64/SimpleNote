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
            lblSave = new Label();
            txtNote = new TextBox();
            btnNewNote = new Button();
            dgvNotes = new DataGridView();
            clnIdNote = new DataGridViewTextBoxColumn();
            clnIdUser = new DataGridViewTextBoxColumn();
            clnIdColor = new DataGridViewTextBoxColumn();
            clnTitleNote = new DataGridViewTextBoxColumn();
            clnTextNote = new DataGridViewTextBoxColumn();
            clnDateNote = new DataGridViewTextBoxColumn();
            clnArchived = new DataGridViewTextBoxColumn();
            clnDeleted = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNotes).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblSave);
            panel1.Controls.Add(txtNote);
            panel1.Controls.Add(btnNewNote);
            panel1.Controls.Add(dgvNotes);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(360, 337);
            panel1.TabIndex = 0;
            // 
            // lblSave
            // 
            lblSave.AutoSize = true;
            lblSave.Location = new Point(120, 39);
            lblSave.Name = "lblSave";
            lblSave.Size = new Size(109, 15);
            lblSave.TabIndex = 1;
            lblSave.Text = "Salvo com sucesso!";
            lblSave.Visible = false;
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
            dgvNotes.Columns.AddRange(new DataGridViewColumn[] { clnIdNote, clnIdUser, clnIdColor, clnTitleNote, clnTextNote, clnDateNote, clnArchived, clnDeleted });
            dgvNotes.Location = new Point(0, 0);
            dgvNotes.Name = "dgvNotes";
            dgvNotes.RowHeadersVisible = false;
            dgvNotes.Size = new Size(360, 337);
            dgvNotes.TabIndex = 2;
            dgvNotes.CellContentClick += dgvNotes_CellContentClick;
            // 
            // clnIdNote
            // 
            clnIdNote.HeaderText = "ID";
            clnIdNote.Name = "clnIdNote";
            clnIdNote.ReadOnly = true;
            clnIdNote.Visible = false;
            clnIdNote.Width = 25;
            // 
            // clnIdUser
            // 
            clnIdUser.HeaderText = "User (ID)";
            clnIdUser.Name = "clnIdUser";
            clnIdUser.Visible = false;
            // 
            // clnIdColor
            // 
            clnIdColor.HeaderText = "Color (ID)";
            clnIdColor.Name = "clnIdColor";
            clnIdColor.ReadOnly = true;
            clnIdColor.Visible = false;
            clnIdColor.Width = 45;
            // 
            // clnTitleNote
            // 
            clnTitleNote.HeaderText = "Title";
            clnTitleNote.Name = "clnTitleNote";
            clnTitleNote.ReadOnly = true;
            clnTitleNote.Width = 290;
            // 
            // clnTextNote
            // 
            clnTextNote.HeaderText = "Text";
            clnTextNote.Name = "clnTextNote";
            clnTextNote.ReadOnly = true;
            clnTextNote.Visible = false;
            // 
            // clnDateNote
            // 
            clnDateNote.HeaderText = "Date";
            clnDateNote.Name = "clnDateNote";
            clnDateNote.ReadOnly = true;
            clnDateNote.Width = 66;
            // 
            // clnArchived
            // 
            clnArchived.HeaderText = "Archived";
            clnArchived.Name = "clnArchived";
            clnArchived.Visible = false;
            // 
            // clnDeleted
            // 
            clnDeleted.HeaderText = "Deleted";
            clnDeleted.Name = "clnDeleted";
            clnDeleted.Visible = false;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            ControlBox = false;
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
        private TextBox txtNote;
        private DataGridViewTextBoxColumn clnIdNote;
        private DataGridViewTextBoxColumn clnIdUser;
        private DataGridViewTextBoxColumn clnIdColor;
        private DataGridViewTextBoxColumn clnTitleNote;
        private DataGridViewTextBoxColumn clnTextNote;
        private DataGridViewTextBoxColumn clnDateNote;
        private DataGridViewTextBoxColumn clnArchived;
        private DataGridViewTextBoxColumn clnDeleted;
        private Label lblSave;
    }
}
