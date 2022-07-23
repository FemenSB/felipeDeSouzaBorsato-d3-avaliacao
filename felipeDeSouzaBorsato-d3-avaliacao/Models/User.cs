using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace felipeDeSouzaBorsato_d3_avaliacao.Models
{
    internal class User
    {
        public string Id { get ; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public User(string id, string nome, string email, string senha) // Construtor sem id, utilizado para o cadastro de usuários, uma vez que o id é definido pelo banco de dados
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public User(string nome, string email, string senha) // Construtor sem id, utilizado para o cadastro de usuários, uma vez que o id é definido pelo banco de dados
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public User()
        {

        }
    }
}