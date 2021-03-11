using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengri.GBD
{
    public class personal_data
    {
        public string Iin { get; set; }
        public string LastName;
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string AddressOfRegistation { get; set; }
        public string DocType { get; set; }
        public int DocNumber { get; set; }
        public string DocIssuer { get; set; }
        public DateTime DocDate { get; set; }
        public DateTime DocEndDate { get; set; }
        public int Age { get; set; }
        public string status { get; set; }
    }
}
