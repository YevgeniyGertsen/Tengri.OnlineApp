using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Tengri.ServiceUser
{
    public class ServicesUser
    {
        private DAL.liteDbEntity db = null;

        public ServicesUser(string connectionString)
        {
            db = new DAL.liteDbEntity(connectionString);
        }

        //регистрация
        public bool Registration(User user)
        {
            if (user == null)
            {
                return false;
            }
            else
            {
                string message = "";
                Tengri.GBD.ServiceGBDinfo ser = new GBD.ServiceGBDinfo();
                
                user.personalData = ser.GetInfo(user.Iin);
                if (!db.Create<User>(user, out message))
                    throw new Exception(message);
                else
                    return true;

                //return db.Create<User>(user, out message);
            }
        }

        //наличие пользователя
        public User IsExist(string login)
        {
            List<User> users = db.GetCollection<User>();
            return users
                .Where(w => w.login == login)
                .FirstOrDefault();
        }

        public bool IsExistUser(string login)
        {
            List<User> users = db.GetCollection<User>();
            return users
                .Where(w => w.login == login)
                .Any();
        }

        /// <summary>
        /// Метод возвращет пользователя по его ID
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <returns></returns>
        public bool IsExistUser(int userId)
        {
            List<User> users = db.GetCollection<User>();
            return users
                .Where(w => w.id == userId)
                .Any();
        }

        public User GetUser(string login, string password)
        {
            string message = "";
            User user = IsExist(login);
            if (user != null)
            {
                if (user.password != password)
                {
                    if(user.wrongpasswordscount == 3)
                        user.status = 2;//заблокирован

                    user.wrongpasswordscount = user.wrongpasswordscount + 1;
                    db.UpDate<User>(user, out message);
                }
                else if(user.password == password)
                {
                    return user;
                }
            }
            
            return null;

            //List<User> users = db.GetCollection<User>();
            //return users
            //    .Where(w => w.login == login && w.password == password)
            //    .FirstOrDefault();
        }

        //авторизация
        //восстановление пароля
        //изменение пароля
        //блокировка учетной записи
    }


}
