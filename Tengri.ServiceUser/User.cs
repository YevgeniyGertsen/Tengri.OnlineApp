using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
