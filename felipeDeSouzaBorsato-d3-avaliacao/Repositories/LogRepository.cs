using felipeDeSouzaBorsato_d3_avaliacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace felipeDeSouzaBorsato_d3_avaliacao.Repositories
{
    internal class LogRepository
    {

        public LogRepository() { }

        public void CreateFile(string fileName)
        {
            if(!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }
        }

        public void RegisterLogIn(User user, string fileName)
        {
            DateTime today = DateTime.Now;
            string date = today.ToString("dd-MM-yyyy");
            string time = today.ToString("hh:mm");
            string log = $"In: O usuário {user.Nome} ({user.Id}) acessou o sistema às {time} do dia {date}";
            File.AppendAllLines(fileName, new List<string>{ log });
        }

        public void RegisterLogOff(User user, string fileName)
        {
            DateTime today = DateTime.Now;
            string date = today.ToString("dd-MM-yyyy");
            string time = today.ToString("hh:mm");
            string log = $"Out: O usuário {user.Nome} ({user.Id}) deslogou do sistema às {time} do dia {date}";
            File.AppendAllLines(fileName, new List<string> { log });
        }

    }
}
