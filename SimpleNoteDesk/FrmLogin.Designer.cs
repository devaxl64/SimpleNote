
namespace SimpleNoteDesk
{
    partial class FrmLogin
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
            BtnLogin = new Button();
            TxtEmail = new TextBox();
            TxtPass = new TextBox();
            LbEmail = new Label();
            LbPass = new Label();
            SuspendLayout();
            // 
            // BtnLogin
            // 
            BtnLogin.Location = new Point(159, 166);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(75, 23);
            BtnLogin.TabIndex = 0;
            BtnLogin.Text = "Login";
            BtnLogin.UseVisualStyleBackColor = true;
            // 
            // TxtEmail
            // 
            TxtEmail.Location = new Point(76, 57);
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(242, 23);
            TxtEmail.TabIndex = 1;
            TxtEmail.Text = "marcell@email.com";
            // 
            // TxtPass
            // 
            TxtPass.Location = new Point(76, 126);
            TxtPass.Name = "TxtPass";
            TxtPass.Size = new Size(242, 23);
            TxtPass.TabIndex = 2;
            TxtPass.Text = "1234";
            TxtPass.UseSystemPasswordChar = true;
            // 
            // LbEmail
            // 
            LbEmail.AutoSize = true;
            LbEmail.Location = new Point(83, 34);
            LbEmail.Name = "LbEmail";
            LbEmail.Size = new Size(41, 15);
            LbEmail.TabIndex = 3;
            LbEmail.Text = "E-mail";
            // 
            // LbPass
            // 
            LbPass.AutoSize = true;
            LbPass.Location = new Point(83, 108);
            LbPass.Name = "LbPass";
            LbPass.Size = new Size(39, 15);
            LbPass.TabIndex = 4;
            LbPass.Text = "Senha";
            // 
            // FrmLogin
            // 
            AcceptButton = BtnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 216);
            Controls.Add(LbPass);
            Controls.Add(LbEmail);
            Controls.Add(TxtPass);
            Controls.Add(TxtEmail);
            Controls.Add(BtnLogin);
            Name = "FrmLogin";
            Text = "FrmLogin";
            Load += FrmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Button BtnLogin;
        private TextBox TxtEmail;
        private TextBox TxtPass;
        private Label LbEmail;
        private Label LbPass;
    }
}