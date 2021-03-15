using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tengri.ServiceAccount;
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

        public static void AuthUserMenu(SettingsAccount serviceAccount, User user)
        {
            Console.WriteLine("1. Список счетов");
            Console.WriteLine("2. Пополнить счет");
            Console.WriteLine("3. Перевести деньги");
            Console.WriteLine("4. Создать счет");
            Console.WriteLine("5. Выход");
            int userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    {
                        Console.WriteLine(new String('-',20));
                        Console.WriteLine("");

                        foreach (Account acc in serviceAccount[1, user.id])
                            acc.PrintAccountBaseInfo();

                        foreach (var acc in serviceAccount[2, user.id])
                            acc.PrintAccountBaseInfo();

                        Thread.Sleep(3000);
                        AuthUserMenu(serviceAccount, user);

                        //Console.Clear();
                        //foreach (Account acc in serviceAccount.GetUserAccounts(user.id))
                        //{
                        //    Console.WriteLine(acc.Id+". " + acc.IBAN+" - "+ acc.Balance+" тенге");
                        //} 
                    }
                    
                    break;
                    case 2:
                    {
                       
                        Console.Write("Выберите счет: ");
                        int accId = int.Parse(Console.ReadLine());
                        
                        decimal addMoney = 0;
                        Console.Write("Введите сумму пополнения счета: ");
                        addMoney = Convert.ToDecimal(Console.ReadLine());

                        serviceAccount.AddMoney(accId, addMoney);
                    }  
                       break;
                case 3:
                    {
                        Console.Write("Выберите счет отправления: ");
                        int countOne = int.Parse(Console.ReadLine());

                        Console.Write("Выберите счет получателя: ");
                        int countSecond = int.Parse(Console.ReadLine());

                        Console.WriteLine("Сумма перевода: ");
                        decimal amount = decimal.Parse(Console.ReadLine());

                        serviceAccount.CreateTransaction(countOne, countSecond, amount, user.id);

                    }
                    break;

                case 4:
                    if(serviceAccount.CreateAccount(user.id, out ServiceAccount.Account account))
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            Console.Write(".");
                            Thread.Sleep(500);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Поздравляем! Ваш счет создан.");
                        Thread.Sleep(3000);



                        Console.Clear();
                        AuthUserMenu(serviceAccount, user);
                    }
                    else
                    {
                        Console.WriteLine("Некорректные данные! Попробуйте еще раз.");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
