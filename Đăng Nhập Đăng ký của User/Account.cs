using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMillTeaProgram
{
     class Account
    {
        public string UserName {  get; set; }
        public string Password { get; set; }

        public Account(string username, string password)
        {
            UserName = username;
            Password = password;
        }
        public Account() { 
        }
    }

  
}
