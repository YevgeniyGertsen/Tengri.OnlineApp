using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengri.ServiceAccount
{
    /// <summary>
    /// Шаблон счета
    /// </summary>
    public class Account
    {
        public int Id { get; set; }
        public int AccountTypeId { get; set; }
        public int UserId { get; set; }
        public string IBAN { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public decimal Balance { get; set; }
        public int Status { get; set; }

        public string GetStatusName
        {
            get
            {
                switch (Status)
                {
                    case 1:
                        return "Активный";
                    case 2:
                        return "Закрытый";
                    default:
                        return "Неопределенный статус";
                }
            }
        }

        public override string ToString()
        {
            //return this.Id + ". " + this.IBAN + " - " + this.Balance + " тенге";
            //return string.Format("{0}. {1} - {2} тенге", Id, IBAN, Balance);
            string AppInfo = string.Format("{4}. {0}\n{1}\n{2} тенге\n{3}\n",
                                           AccTypeName, IBAN, Balance, new String('-', 20), Id);
            return AppInfo;
        }

        public string AccTypeName 
        {
            get
            {
                switch (AccountTypeId)
                {
                    case 1: return "Текущий счет";
                    case 2: return "Депозитный счет";
                    case 3: return "Кредитный счет";
                    default:  return "Не определен";
                }
            }
        }
        public void PrintAccountBaseInfo()
        {
            switch (AccountTypeId)
            {
                case 1: Console.ForegroundColor = ConsoleColor.Green; break;
                case 2: Console.ForegroundColor = ConsoleColor.Red; break;
                case 3: Console.ForegroundColor = ConsoleColor.Yellow; break;
            }
            Console.WriteLine(this.ToString());

            Console.ResetColor();
        }



    }
}
