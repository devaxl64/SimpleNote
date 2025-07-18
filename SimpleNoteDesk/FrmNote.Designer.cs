namespace SimpleNoteDesk
{
    partial class FrmNote
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
            txtNote = new TextBox();
            btnRetrun = new Button();
            SuspendLayout();
            // 
            // txtNote
            // 
            txtNote.Location = new Point(12, 50);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.ScrollBars = ScrollBars.Horizontal;
            txtNote.Size = new Size(360, 299);
            txtNote.TabIndex = 0;
            // 
            // btnRetrun
            // 
            btnRetrun.BackColor = Color.Transparent;
            btnRetrun.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRetrun.Location = new Point(12, 9);
            btnRetrun.Margin = new Padding(0);
            btnRetrun.Name = "btnRetrun";
            btnRetrun.Size = new Size(35, 38);
            btnRetrun.TabIndex = 1;
            btnRetrun.Text = "←\r\n";
            btnRetrun.TextAlign = ContentAlignment.TopLeft;
            btnRetrun.UseVisualStyleBackColor = false;
            // 
            // FrmNote
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            ControlBox = false;
            Controls.Add(btnRetrun);
            Controls.Add(txtNote);
            MaximizeBox = false;
            Name = "FrmNote";
            StartPosition = FormStartPosition.CenterParent;
            Text = "-";
            Deactivate += FrmNote_Deactivate;
            FormClosing += FrmNote_FormClosing;
            FormClosed += FrmNote_FormClosed;
            Load += FrmNote_Load;
            Leave += FrmNote_Leave;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNote;
        private Button btnRetrun;
    }
}