using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using felipeDeSouzaBorsato_d3_avaliacao.Models;
using felipeDeSouzaBorsato_d3_avaliacao.Repositories;
using BCrypt.Net;
using static BCrypt.Net.BCrypt;

namespace felipeDeSouzaBorsato_d3_avaliacao.Controllers
{
    internal class UserController
    {
        private UserRepository userRepository;

        public UserController()
        {
            userRepository = new();
        }

        public User LogUser(string email, string password)
        {
            User foundUser = userRepository.SearchEmail(email);
            
            if(foundUser == null)
            {
                return null;
            }
            
            if(Verify(password, foundUser.Senha))
            {
                return foundUser;
            }

            return null;
        }

        public void RegisterUser(User user)
        {
            if(userRepository.SearchEmail(user.Email) != null)
            {
                Console.WriteLine("Email já cadastrado!");
                return;
            }
            user.Senha = HashPassword(user.Senha, 10);

            userRepository.SaveUser(user);
        }
    }
}
