using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Model
{
    public class Customer : Active
    {
        public Guid  UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
