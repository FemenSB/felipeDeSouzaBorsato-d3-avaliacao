using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using felipeDeSouzaBorsato_d3_avaliacao.Models;

namespace felipeDeSouzaBorsato_d3_avaliacao.Repositories
{
    internal class UserRepository
    {
        const string URL = "server=localhost;user=root;database=felipeDeSouzaBorsato-d3-avaliacao;port=3306;password=";

        public UserRepository()
        {

        }

        private MySqlConnection GetConnection()
        {
            MySqlConnection conn = new MySqlConnection(URL);
            try
            {
                conn.Open();
                return conn;
            } catch(Exception e)
            {
                throw new Exception("Erro ao conectar ao banco de dados", e);
            }
        }

        public List<User> ReadUsers()
        {
            List < User > userList = new();

            using(MySqlConnection conn = GetConnection())
            {
                string query = "SELECT * FROM users";
                MySqlCommand cmd = new(query, conn);
                using(MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while(rdr.Read())
                    {
                        User user = new()
                        {
                            Id = rdr["Id"].ToString(),
                            Nome = rdr["Nome"].ToString(),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["senha"].ToString()
                        };

                        userList.Add(user);
                    }
                }
            }

            return userList;
        }

        public User SearchEmail(string email)
        {
            string query = "SELECT * FROM users WHERE Email=@email";

            using(MySqlConnection conn = GetConnection())
            {
                MySqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@email", email);

                using(MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    if(rdr.Read())
                    {
                        return new User()
                        {
                            Id = rdr["Id"].ToString(),
                            Nome = rdr["Nome"].ToString(),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString()
                        };
                    }

                    return null;
                }
            }
        }

        public void SaveUser(User user)
        {
            string query = "INSERT INTO users (Nome, Email, Senha) VALUES (@n, @e, @s)";
            
            using(MySqlConnection conn = GetConnection())
            {
                MySqlCommand cmd = new(query, conn);
                cmd.Parameters.AddWithValue("@n", user.Nome);
                cmd.Parameters.AddWithValue("@e", user.Email);
                cmd.Parameters.AddWithValue("s", user.Senha);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
