using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PythonSucks.ViewModels
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
