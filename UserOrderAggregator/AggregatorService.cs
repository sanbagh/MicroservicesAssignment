using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UserOrderAggregator.Model;

namespace UserOrderAggregator
{
    public class AggregatorService: IAggregatorService
    {
        private const string UserUrl = "https://localhost:5000/user/";
        private const string OrdersUrl = "https://localhost:5003/order/";
        private readonly IConfiguration configuration;

        public AggregatorService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<User> GetUserDetails(int userId)
        {
            var url = configuration.GetValue<string>("Values:userUrl");
            if (url == null)
            {
                url = UserUrl;
            }
            url = url + userId;

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
            url = url + userId;
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
