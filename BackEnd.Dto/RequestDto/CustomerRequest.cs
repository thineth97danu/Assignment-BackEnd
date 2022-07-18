using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Dto.RequestDto
{
    public class CustomerRequest
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
    }

   
}
