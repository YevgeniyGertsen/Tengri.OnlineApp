using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tengri.GBD;

namespace Tengri.ServiceUser
{
    public class User
    {
        public int id { get; set; }
        /// <summary>
        /// пароль
        /// </summary>
        public string password { get; set; }
        public string login { get; set; }
        public string fullname { get; set; }
        public DateTime createdate { get; set; }
        public int status { get; set; }
        public int wrongpasswordscount { get; set; }
        public string Iin { get; set; }
        public personal_data personalData { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1:MMMM dd}", fullname, createdate); 
        }
    }
}