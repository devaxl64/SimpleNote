using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNoteClass
{
    internal class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Level? Level { get; set; }
        public bool Active { get; set; }
        public User()
        {
            Level = new Level();
        }
        public User(int id, string name, string lastName, string email, string password, Level level, bool active)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            Level = level;
            Active = active;
        }

        public User(string name, string lastName, string email, string password, Level level)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            Level = level;
        }
        public User(string name, string email, string password, Level level)
        {
            Name = name;
            Email = email;
            Password = password;
            Level = level;
        }

        public User(int id, string name, string lastName)
        {
            Id = id;
            Name = name;
            LastName = lastName;
        }
        public User(int id, string password)
        {
            Id = id;
            Password = password;
        }
        public void InsertUser()
        {
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = $"sp_user_insert";
            cmd.Parameters.AddWithValue("spname", Name);
            cmd.Parameters.AddWithValue("splastname", LastName);
            cmd.Parameters.AddWithValue("spemail", Email);
            cmd.Parameters.AddWithValue("sppassword", Password);
            cmd.Parameters.AddWithValue("spactive", Active);
            cmd.Parameters.AddWithValue("spidlevel", Level.Id);
            Id = Convert.ToInt32(cmd.ExecuteScalar());
        }
        public static User GetWithId(int id)
        {
            User user = new User();
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"SELECT * FROM users WHERE id = {id};";
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                user = new User(
                    reader.GetInt32(0), // Id
                    reader.GetString(1), // Name
                    reader.GetString(2), // LastName
                    reader.GetString(3), // Email
                    reader.GetString(4), // Password
                    Level.GetWithId(reader.GetInt32(5)), // Level
                    reader.GetBoolean(6) // Active
                );
            }
            reader.Close();
            cmd.Connection.Close();
            return user;
        }
        public static List<User> GetList()
        {
            List<User> users = new List<User>();
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"SELECT * FROM users WHERE BY name;";
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                users.Add(new User(
                    reader.GetInt32(0), // Id
                    reader.GetString(1), // Name
                    reader.GetString(2), // LastName
                    reader.GetString(3), // Email
                    reader.GetString(4), // Password
                    Level.GetWithId(reader.GetInt32(5)), // Level
                    reader.GetBoolean(6) // Active
                    ));
            }
            reader.Close();
            cmd.Connection.Close();
            return users;
        }
        public bool UpdateUser()
        {
            bool updated = false;
            if (Id <= 0)
            {
                return updated;
                throw new Exception("Não foi possível atualizar!");
            }
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = $"sp_user_update";
            cmd.Parameters.AddWithValue("spid", Id);
            cmd.Parameters.AddWithValue("spname", Name);
            cmd.Parameters.AddWithValue("splastname", LastName);
            cmd.Parameters.AddWithValue("sppassword", Password);
            cmd.Parameters.AddWithValue("spidlevel", Level.Id);
            if (cmd.ExecuteNonQuery() > 0)
            {
                updated = true;
            }
            cmd.Connection.Close();
            return updated;
        }
        public bool UpdateUserName()
        {
            bool updated = false;
            if (Id <= 0)
            {
                return updated;
                throw new Exception("Não foi possível atualizar!");
            }
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = $"sp_user_update_name";
            cmd.Parameters.AddWithValue("spid", Id);
            cmd.Parameters.AddWithValue("spname", Name);
            cmd.Parameters.AddWithValue("splastname", LastName);
            if (cmd.ExecuteNonQuery() > 0)
            {
                updated = true;
            }
            cmd.Connection.Close();
            return updated;
        }
        public bool UpdateUserPassword()
        {
            bool updated = false;
            if (Id <= 0)
            {
                return updated;
                throw new Exception("Não foi possível atualizar!");
            }
            var cmd = Db.OpenDb();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = $"sp_user_update_password";
            cmd.Parameters.AddWithValue("spid", Id);
            cmd.Parameters.AddWithValue("sppassword", Password);
            if (cmd.ExecuteNonQuery() > 0)
            {
                updated = true;
            }
            cmd.Connection.Close();
            return updated;
        }
    }
}
