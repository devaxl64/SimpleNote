using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNoteClass
{
    public class SimpleNote
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Textt { get; set; }
        public DateTime Datte { get; set; }
        public User? User { get; set; }
        public NoteColor? Color { get; set; }
        public bool Archived { get; set; }
        public bool Deleted { get; set; }
        public SimpleNote()
        {
            User = new User();
            Color = new NoteColor();
        }

        public SimpleNote(string title, string textt, User user, NoteColor color)
        {
            Title = title;
            Textt = textt;
            User = user;
            Color = color;
        }
        public SimpleNote(int id, string? title, string? textt, DateTime datte, User? user, NoteColor? color, bool archived, bool deleted)
        {
            Id = id;
            Title = title;
            Textt = textt;
            Datte = datte;
            User = user;
            Color = color;
            Archived = archived;
            Deleted = deleted;
        }
        public void InsertNote()
        {
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = $"sp_note_insert";
            cmd.Parameters.AddWithValue("spfk_iduser", User.Id);
            cmd.Parameters.AddWithValue("spfk_idcolor", Color.Id);
            cmd.Parameters.AddWithValue("sptitle", Title);
            cmd.Parameters.AddWithValue("sptextt", Textt);
            Id = Convert.ToInt32(cmd.ExecuteScalar());
        }
        public static SimpleNote GetById(int id)
        {
            var note = new SimpleNote();
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"SELECT * FROM notes WHERE id = {id};";
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                note = new SimpleNote(
                    reader.GetInt32(0), // Id
                    reader.GetString(1), // Title
                    reader.GetString(2), // Textt
                    reader.GetDateTime(3), // Datte
                    User.GetById(reader.GetInt32(4)), // User
                    NoteColor.GetById(reader.GetInt32(5)), // Color
                    reader.GetBoolean(6), // Archived
                    reader.GetBoolean(7) // Deleted
                );
            }
            reader.Close();
            cmd.Connection.Close();
            return note;
        }
        public static List<SimpleNote> GetList()
        {
            List<SimpleNote> notes = new List<SimpleNote>();
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"SELECT * FROM notes;";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                notes.Add(new SimpleNote(
                    reader.GetInt32(0), // Id
                    reader.GetString(1), // Title
                    reader.GetString(2), // Textt
                    reader.GetDateTime(3), // Datte
                    User.GetById(reader.GetInt32(4)), // User
                    NoteColor.GetById(reader.GetInt32(5)), // Color
                    reader.GetBoolean(6), // Archived
                    reader.GetBoolean(7)) // Deleted
                );
            }
            reader.Close();
            cmd.Connection.Close();
            return notes;
        }

    }
}
