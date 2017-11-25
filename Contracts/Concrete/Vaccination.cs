using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Concrete
{
    public class Vaccination
    {
        public string Preparation { get; set; }
        public string Approval { get; set; }
        public DateTime Date { get; set; }
    }

    public class Patient
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Snils { get; set; }
    }
}
