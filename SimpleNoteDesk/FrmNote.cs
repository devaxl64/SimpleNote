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
    public partial class FrmNote : Form
    {
        public FrmNote()
        {
            InitializeComponent();
        }

        private void FrmNote_Load(object sender, EventArgs e)
        {
            if (Program.LoggedUser.Id > 0)
            {
                var loggedUser = Program.LoggedUser;
                this.Text = $"{loggedUser.Name} - {loggedUser.Level.Name}";
            }
        }

        public SimpleNote SaveNote()
        {
            var note = new SimpleNote
            {
                User = Program.LoggedUser,
                Color = new NoteColor { Id = 1 }, // Updated to use TypeColor instead of Id
                Title = txtNote.Text.Length > 40 ? txtNote.Text.Substring(0, 40) : txtNote.Text,
                Textt = txtNote.Text
            };
            note.InsertNote();
            return note;
        }
        public FrmNote(FrmMain frmMain)
        {
            InitializeComponent();
            _frmMain = frmMain;
        }

        private void FrmNote_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveNote();
            this.Close();
            FrmMain.Show();
        }

        private void FrmNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveNote();
            this.Close();
            FrmMain.Show();
        }

        private void FrmNote_Deactivate(object sender, EventArgs e)
        {
            SaveNote();
        }

        private void FrmNote_Leave(object sender, EventArgs e)
        {
            SaveNote();
        }
    }
}
