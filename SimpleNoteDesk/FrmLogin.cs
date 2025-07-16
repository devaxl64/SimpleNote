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

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //Program.LoggedUser = User.Login(TxtEmail.Text, TxtPass.Text);
            
            Program.LoggedUser = User.Login(TxtEmail.Text, TxtPass.Text);
            this.Close();
        }
    }
}
