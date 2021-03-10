using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengri.ServiceAccount
{
    public class SettingsAccount
    {
        private Tengri.DAL.liteDbEntity db = null;
        private ServiceUser.ServicesUser servicesUser = null;

        public SettingsAccount(string connectionString)
        {
            db = new DAL.liteDbEntity(connectionString);
            servicesUser = new ServiceUser.ServicesUser(connectionString);
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
            if (userId == 0 || userId < 0)
                throw new Exception("Пользователь не существует!");
            else if(servicesUser.IsExistUser(userId))
            {

            }
        }
    }
}
