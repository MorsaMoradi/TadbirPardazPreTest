using System;
using System.Collections.Generic;
using System.Text;

namespace TadbirPardazPreTest.DataContract
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { set; get; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
