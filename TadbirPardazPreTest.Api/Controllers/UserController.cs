using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TadbirPardazPreTest.DataContract;
using TadbirPardazPreTest.ServiceContract;

namespace TadbirPardazPreTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        IUserApplicationService userApplicationService;

        public UserController(IUserApplicationService userApplicationService)
        {
            this.userApplicationService = userApplicationService;
        }

        // GET: api/User
        [HttpGet]
        public IList<UserDto> Get()
        {
          return  userApplicationService.GetAll();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public UserDto Get(Guid id)
        {
            return userApplicationService.Find(id);
        }

        // POST: api/User
        [HttpPost]
        public UserDto Post([FromBody] UserDto userDto)
        {
           return userApplicationService.Save(userDto);
        }

    }
}
