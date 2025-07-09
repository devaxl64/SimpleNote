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

        private void BtnLogin_Click(string email, string password, object sender, EventArgs e)
        {
            email = TxtEmail.Text;
            password = TxtPass.Text;
            var cmd = Db.OpenDb();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"SELECT * FROM users WHERE email = '{email}' and senha = md5('{password}');";
            MessageBox.Show($"E-mail: {email} e Senha: {password}");
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
