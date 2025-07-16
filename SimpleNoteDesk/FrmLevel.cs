using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleNoteClass;

namespace SimpleNoteDesk
{
    public partial class FrmLevel : Form
    {
        public FrmLevel()
        {
            InitializeComponent();
        }

        private void FrmLevel_Load(object sender, EventArgs e)
        {

            if (Program.LoggedUser.Id > 0)
            {
                var loggedUser = Program.LoggedUser;
                this.Text = $"{loggedUser.Name} - {loggedUser.Level.Name}";
            }
            LoadGridLevels();
        }

        private void LoadGridLevels()
        {
            var levels = Level.GetList();
            int line = 0;
            dgvLevels.Rows.Clear();
            foreach (var level in levels)
            {
                dgvLevels.Rows.Add();
                dgvLevels.Rows[line].Cells[0].Value = level.Id; // clnIdLevel
                dgvLevels.Rows[line].Cells[1].Value = level.Name; // clnNameLevel
                dgvLevels.Rows[line].Cells[2].Value = level.Aka; // clnAkaLevel
                line++;
            }

        }
    }
}
