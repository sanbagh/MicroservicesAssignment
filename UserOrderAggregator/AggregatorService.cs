using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UserOrderAggregator.Model;

namespace UserOrderAggregator
{
    public class AggregatorService : IAggregatorService
    {
        private readonly ILogger _logger;
        private const string UserUrl = "https://localhost:5000/user/";
        private const string OrdersUrl = "https://localhost:5003/order/";
        private readonly IConfiguration configuration;

        public AggregatorService(IConfiguration configuration, ILogger<AggregatorService> logger)
        {
            this.configuration = configuration;
            _logger = logger;
        }
        public async Task<User> GetUserDetails(int userId)
        {
            var url = configuration.GetValue<string>("Values:userUrl");
            if (url == null)
            {
                url = UserUrl;
            }
            var port = configuration.GetValue<string>("Values:userport");
            _logger.LogInformation("urluser = " + url);
            url = "http://"+ url + ":" + port + "/user/" + userId;
            _logger.LogInformation("urluser after = " + url);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            var data = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(data);
            return user;
        }

        public async Task<List<Order>> GetOrderDetails(int userId)
        {
            var url = configuration.GetValue<string>("Values:ordersUrl");
            if (url == null)
            {
                url = OrdersUrl;
            }
            _logger.LogInformation("urlorder = " + url);
            var port = configuration.GetValue<string>("Values:orderport");
            url = "http://"+ url +":"+ port+ "/order/" + userId;
            _logger.LogInformation("urlorder after = " + url);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            var data = await response.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<List<Order>>(data);
            return order;
        }

        public async Task<UserOrder> GetUserOrderDetails(int Id)
        {
            var user = await GetUserDetails(Id);
            if (user == null)
                return null;
            var order = await GetOrderDetails(Id);
            return new UserOrder()
            {
                UserDetails = user,
                OrderDetails = order
            };

        }
    }
}
