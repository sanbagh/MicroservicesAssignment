using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserOrderAggregator.Model
{
    public class UserOrder
    {
        public User UserDetails { get; set; }
        public List<Order> OrderDetails { get; set; }
    }
}
