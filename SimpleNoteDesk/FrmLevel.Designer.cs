namespace SimpleNoteDesk
{
    partial class FrmLevel
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
            dgvLevels = new DataGridView();
            clnIdLevel = new DataGridViewTextBoxColumn();
            clnNameLevel = new DataGridViewTextBoxColumn();
            clnAkaLevel = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvLevels).BeginInit();
            SuspendLayout();
            // 
            // dgvLevels
            // 
            dgvLevels.AllowUserToAddRows = false;
            dgvLevels.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLevels.Columns.AddRange(new DataGridViewColumn[] { clnIdLevel, clnNameLevel, clnAkaLevel });
            dgvLevels.Location = new Point(12, 12);
            dgvLevels.Name = "dgvLevels";
            dgvLevels.RowHeadersVisible = false;
            dgvLevels.Size = new Size(360, 337);
            dgvLevels.TabIndex = 4;
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
            // FrmLevel
            // 
            AccessibleRole = AccessibleRole.OutlineButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(dgvLevels);
            Name = "FrmLevel";
            Text = "-";
            Load += FrmLevel_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLevels).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvLevels;
        private DataGridViewTextBoxColumn clnIdLevel;
        private DataGridViewTextBoxColumn clnNameLevel;
        private DataGridViewTextBoxColumn clnAkaLevel;
    }
}