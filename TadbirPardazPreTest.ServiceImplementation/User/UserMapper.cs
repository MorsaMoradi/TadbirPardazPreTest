using System;
using System.Collections.Generic;
using System.Text;
using TadbirPardazPreTest.DataContract;
using TadbirPardazPreTest.Domain;
using TadbirPardazPreTest.ServiceContract.Base;

namespace TadbirPardazPreTest.ServiceImplementation
{
    public class UserMapper : IEntityMapper<User, UserDto>
    {
        public User CreateFrom(UserDto domainDto)
       => new User(domainDto.Id, domainDto.Username, domainDto.FirstName, domainDto.LastName, domainDto.PhoneNumber, domainDto.Email);


        public UserDto MappTo(User domain)
        => new UserDto
        {
            Email = domain.Email,
            FirstName = domain.FirstName,
            Id = domain.Id,
            LastName = domain.LastName,
            PhoneNumber = domain.PhoneNumber,
            Username = domain.Username
        };

    }
}
