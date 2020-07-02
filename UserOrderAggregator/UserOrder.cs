using System;
using System.Collections.Generic;
using UserOrderAggregator.Model;

namespace UserOrderAggregator
{
    public class UserOrder
    {
        public User UserDetails { get; set; }
        public List<Order> OrderDetails { get; set; }
    }
}
