using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mysqlx.Notice.Warning.Types;
using SimpleNoteClass;

namespace SimpleNoteDesk
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //Program.LoggedUser = User.Login(TxtEmail.Text, TxtPass.Text);
            //if (Program.LoggedUser.Id > 0)
            //{
            //    Program.LoggedUser = User.Login(TxtEmail.Text, TxtPass.Text);
            //}

            //Program.LoggedUser = User.Login(TxtEmail.Text, TxtPass.Text);
            Program.LoggedUser = User.Login(TxtEmail.Text, TxtPass.Text);
            if (Program.LoggedUser.Id > 0)
            {
                this.Close();
                //FrmMain frmMain = new FrmMain();
            }
            else
            {
                MessageBox.Show("Email e/ou senha incorretos \n ou usuário não cadastrado");
                TxtEmail.Focus();
                TxtEmail.SelectAll();
            }
            //FrmMain frmMain = new FrmMain();

            //this.Close();
        }
    }
}
