using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UserOrderAggregator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IAggregatorService aggregatorService;

        public OrderDetailsController(IAggregatorService aggregatorService)
        {
            this.aggregatorService = aggregatorService;
        }

        [HttpGet("{id}")]
        public async Task<UserOrder> GetAsync(int id)
        {
            return await aggregatorService.GetUserOrderDetails(id);
        }
    }
}
