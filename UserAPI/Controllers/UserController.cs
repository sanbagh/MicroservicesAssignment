using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserAPI.Data;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext dBContext;

        public UserController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return dBContext.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
