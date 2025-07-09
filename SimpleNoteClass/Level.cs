using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNoteClass
{
    public class Level
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Aka { get; set; } // AKA = Also Known As

        public Level()
        {
        }
        public Level(int id, string name, string aka)
        {
            Id = id;
            Name = name;
            Aka = aka;
        }
        public Level(string name, string aka)
        {
            Name = name;
            Aka = aka;
        }

        public void InsertLevel()
        {
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = $"sp_level_insert";
            cmd.Parameters.AddWithValue("spname", Name);
            cmd.Parameters.AddWithValue("spaka", Aka);
            Id = Convert.ToInt32(cmd.ExecuteScalar());
        }
        public static Level GetWithId(int id)
        {
            var level = new Level();
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"SELECT * FROM levels WHERE id = {id};";
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                level = new Level(
                    reader.GetInt32(0), // Id
                    reader.GetString(1), // Name
                    reader.GetString(2) // Aka
                    );
            }
            reader.Close();
            cmd.Connection.Close();
            return level;
        }
        public static List<Level> GetList()
        {
            List<Level> levels = new List<Level>();
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"SELECT * FROM levels ORDER BY name;";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                levels.Add(new Level(
                    reader.GetInt32(0), // Id
                    reader.GetString(1), // Name
                    reader.GetString(2) // Aka
                    ));
            }
            reader.Close();
            cmd.Connection.Close();
            return levels;
        }
        public bool UpdateLevel()
        {
            bool updated = false;
            if (Id <= 0)
            {
                return updated;
                throw new Exception("Não foi possível atualizar!");
            }
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = $"sp_level_update";
            cmd.Parameters.AddWithValue("spid", Id);
            cmd.Parameters.AddWithValue("spname", Name);
            cmd.Parameters.AddWithValue("spaka", Aka);

            if (cmd.ExecuteNonQuery() > 0)
            {                 
                updated = true;
            }
            cmd.Connection.Close();
            return updated;
        }

    }
}
