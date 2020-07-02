using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserOrderAggregator.Model;

namespace UserOrderAggregator
{
    public interface IAggregatorService
    {
        Task<User> GetUserDetails(int userId);
        Task<List<Order>> GetOrderDetails(int userId);
        Task<UserOrder> GetUserOrderDetails(int Id);
    }
}
