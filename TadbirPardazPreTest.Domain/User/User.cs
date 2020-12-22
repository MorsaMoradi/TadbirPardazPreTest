using System;
using System.Collections.Generic;
using System.Text;
using TadbirPardazPreTest.Domain.Base;

namespace TadbirPardazPreTest.Domain
{
   public class User :  DomainBase<Guid>
    {
        public User(Guid id, string username, string firstName, string lastName, string phoneNumber, string email)
        {
            Id = id;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public string Username { get;protected set; }
        public string FirstName { protected set; get; }
        public string LastName { get; protected set; }
        public string PhoneNumber { get;protected set; }
        public string Email { get;protected set; }
    }
}
