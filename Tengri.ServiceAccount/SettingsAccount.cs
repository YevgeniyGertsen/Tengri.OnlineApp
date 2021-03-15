using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Tengri.ServiceAccount
{
    public class SettingsAccount
    {
        private DAL.liteDbEntity db = null;
        private ServiceUser.ServicesUser servicesUser = null;

        //public List<AccountType> accountsType;

        public SettingsAccount(string connectionString)
        {
            db = new DAL.liteDbEntity(connectionString);
            servicesUser = new ServiceUser.ServicesUser(connectionString);

            //accountsType = new List<AccountType>()
            //{
            //    new AccountType(){ Id =1, Name="Loan"},
            //    new AccountType(){ Id =2, Name="Deposit"}
            //};
        }

        public List<Account> this[int accTypeId, int userId]
        {
            get
            {
                return GetUserAccounts(userId)
                    .Where(w => w.AccountTypeId == accTypeId)
                    .ToList();
            }            
        }

        /// <summary>
        /// Метод который возвращает список счетов пользователя
        /// </summary>
        /// <param name="userId">ID пользователя в системе</param>
        /// <returns>Коллекцию счетов типа List</returns>
        public List<Account> GetUserAccounts(int userId)
        {
            List<Account> accounts = new List<Account>();

            accounts = db.GetCollection<Account>();

            return accounts
                .Where(w => w.UserId == userId)
                .ToList();
        }

        public bool CreateAccount(int userId, out Account account)
        {
            Random rnd = new Random();
            string message = "";
            account = new Account();

            if (userId == 0 || userId < 0)
                throw new Exception("Пользователь не существует!");
            else if(servicesUser.IsExistUser(userId))
            {
                
                account.UserId = userId;
                account.IBAN = "KZ" + rnd.Next(1, 100);
                account.AccountTypeId = rnd.Next(1,2);

                if (db.Create<Account>(account, out message))
                {
                    return true;
                }
                else
                    throw new Exception(message);
            }
            return false;
        }

        public bool AddMoney(int accId, decimal sum)
        {
            string message = "";
            List<Account> accounts = db.GetCollection<Account>();
            Account facc = accounts.Where(w => w.Id == accId).FirstOrDefault();
            if(facc != null)
            {
                facc.Balance += sum;
            }

            return db.UpDate<Account>(facc, out message);
        }


        public void CreateTransaction(int From, int To, decimal Sum, int userId)
        {
            string message = "";
            //получить список счетов пользователя
            List<Account> acc = GetUserAccounts(userId);

            //проверить сущствование счета From
            if (acc.Where(w => w.Id == From).Count()<=0)
                throw new Exception("Счет отправителя не найден.");

            //проверить сущствование счета To
            if (acc.Where(w => w.Id == To).Count() <= 0)
                throw new Exception("Счет получателя не найден.");

            //проверить наличие срдств Sum на From
            if (acc.FirstOrDefault(w => w.Id == From).Balance < Sum)
                throw new Exception("Недостаточно средств на счете.");

            //отнять от счета From - Sum
            Account accFrom = acc.FirstOrDefault(w => w.Id == From);
            accFrom.Balance -= Sum;
            if(db.UpDate<Account>(accFrom, out message))
            {
                Account accTo = acc.FirstOrDefault(w => w.Id == To);
                accTo.Balance += Sum;
                db.UpDate<Account>(accTo, out message);
            }



            

            //прибавить к счету To - Sum

        }
    }
}
