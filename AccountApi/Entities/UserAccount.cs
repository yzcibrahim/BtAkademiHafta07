using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountApi.Entities
{
    public class UserAccount
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string UserRole { get; set; }
    }
}
