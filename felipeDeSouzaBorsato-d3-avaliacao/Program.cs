using felipeDeSouzaBorsato_d3_avaliacao.Models;
using felipeDeSouzaBorsato_d3_avaliacao.Repositories;
using felipeDeSouzaBorsato_d3_avaliacao.Controllers;

namespace felipeDeSouzaBorsato_d3_avaliacao
{
    internal class Program
    {

        private static string LoggedMenu(User user)
        {
            string option;
            Console.WriteLine($"Bem vindo, {user.Nome}!\n");
            do
            {
                Console.WriteLine("Opções:\n");
                Console.WriteLine("1 - Deslogar");
                Console.WriteLine("2 - Encerrar sistema");

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        return "logout";
                }

            } while (option != "2");
            return "2";
        }

        static void Main(string[] args)
        {
            string option;
            UserController controller = new();
            LogRepository logs = new();

            const string logFileName = "logs.txt";
            logs.CreateFile(logFileName);

            do
            {
                Console.WriteLine("Opções:\n");
                Console.WriteLine("1 - Acessar");
                Console.WriteLine("2 - Cancelar");
                Console.WriteLine("3 - Cadastrar usuário");

                option = Console.ReadLine();

                switch(option)
                {
                    case "1":
                        Console.WriteLine("Informe seu email:");
                        string email = Console.ReadLine();
                        Console.WriteLine("Informe sua senha:");
                        string password = Console.ReadLine();
                        Console.WriteLine("");

                        User user = controller.LogUser(email, password);

                        if (user != null) {
                            logs.RegisterLogIn(user, logFileName);
                            option = LoggedMenu(user);
                            logs.RegisterLogOff(user, logFileName);
                        } else
                        {
                            Console.WriteLine("Email e/ou Senha incorreto(s)!\n");
                        }

                        break;

                    case "3":
                        Console.WriteLine("Informe o nome:");
                        string rNome = Console.ReadLine();
                        Console.WriteLine("Informe o email:");
                        string rEmail = Console.ReadLine();
                        Console.WriteLine("Informe a senha:");
                        string rPassword = Console.ReadLine();

                        User rUser = new(rNome, rEmail, rPassword);

                        controller.RegisterUser(rUser);
                        
                        break;
                }

            } while (option != "2");
        }
    }
}