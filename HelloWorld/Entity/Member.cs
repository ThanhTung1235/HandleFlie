using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Entity
{
    class Member
    {
        private string _userName;
        private string _email;
        private string _introduction;

        public string UserName { get => _userName; set => _userName = value; }
        public string Email { get => _email; set => _email = value; }
        public string Introduction { get => _introduction; set => _introduction = value; }
    }
}
