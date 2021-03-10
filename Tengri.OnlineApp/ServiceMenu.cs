using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tengri.ServiceUser;

namespace Tengri.OnlineApp
{
    public static class ServiceMenu
    {
        public static void WelcomeMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Добро пожалось на платформу Тенгри банка");
            Console.WriteLine("----------------------------------------");
        }

        public static void EnterLoginMenu(out string login, out string password)
        {
            Console.Write("Введите логин: ");
            login = Console.ReadLine();

            Console.Write("Введите пароль: ");
            password = Console.ReadLine();
        }

        public static void WelcomeUserMenu(User user)
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать "+ user .fullname+ "!");
            Console.WriteLine("----------------------------------------");
        }

        public static void NotAuthUserMenu()
        {
            Console.WriteLine("Вы ввели некорректный логин или пароль!");
            Console.WriteLine("");
            Console.Write("Забыли пароль (да/нет): ");
            string ch = Console.ReadLine();
            if(ch == "да")
            {

            }
            else
            {
                Console.Write("Желаете пройти регистрацию (да/нет): ");
            }            
        }

        public static void AuthUserMenu()
        {
            Console.WriteLine("1. Список счетов");
            Console.WriteLine("2. Пополнить счет");
            Console.WriteLine("3. Перевести деньги");
            Console.WriteLine("4. Выход");
        }
    }
}
