using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Entity
{
    class Customer
    {
        private string _phone;
        private string _Fullname;
        private string _Email;

        public string Phone { get => _phone; set => _phone = value; }
        public string Fullname { get => _Fullname; set => _Fullname = value; }
        public string Email { get => _Email; set => _Email = value; }
    }
}
