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
        public FrmNote() // Evento new note
        {
            InitializeComponent();
        }
        public FrmNote(FrmMain frmMain) // Evento save note
        {
            InitializeComponent();
            frmMain = new FrmMain();
            this.FormClosing += FrmNote_FormClosing;
            this.Deactivate += FrmNote_Deactivate;
            this.Leave += FrmNote_Leave;
        }
        public FrmNote(string textt) // evento edit note
        {
            InitializeComponent();
            txtNote.Text = textt;
        }

        private void FrmNote_Load(object sender, EventArgs e) // User Information
        {
            if (Program.LoggedUser.Id > 0)
            {
                var loggedUser = Program.LoggedUser;
                this.Text = $"{loggedUser.Name} - {loggedUser.Level.Name}";
            }
        }

        public bool SaveNote()
        {
            var notesaved = false;
            if (string.IsNullOrWhiteSpace(txtNote.Text))
            {
                return notesaved;
            }
            else
            {
                var note = new SimpleNote
                {
                    User = Program.LoggedUser,
                    Color = new NoteColor { Id = 1 }, // Updated to use TypeColor instead of Id
                    Title = txtNote.Text.Length > 40 ? txtNote.Text.Substring(0, 40) : txtNote.Text,
                    Textt = txtNote.Text
                };
                note.InsertNote();

                notesaved = true;
                var frmMain = new FrmMain();
                frmMain.ShowSave("Salvo", 2000);
            }
            return notesaved;
        }

        private void FrmNote_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveNote();
            this.Close();
        }


        // Saves Configuration when the form is closing:
        private void FrmNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveNote();
            this.Close();
        }

        private void FrmNote_Deactivate(object sender, EventArgs e)
        {
            SaveNote();
        }

        private void FrmNote_Leave(object sender, EventArgs e)
        {
            SaveNote();
        }

        private void btnRetrun_Click(object sender, EventArgs e)
        {
            SaveNote();
            //var frmMain = new FrmMain();
            //frmMain.ShowDialog();
            this.Close();
        }
    }
}
