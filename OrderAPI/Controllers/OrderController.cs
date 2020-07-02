using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OrderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        static List<Order> orders = new List<Order> { new Order { Id = 1, Amount = 250, Date = DateTime.Now }, new Order { Id = 2, Amount = 500, Date = DateTime.Now } };

        public OrderController()
        {
        }

        [HttpGet ("{userId}")]
        public IEnumerable<Order> Get(int userId)
        {
            return orders;
        }
    }
}
