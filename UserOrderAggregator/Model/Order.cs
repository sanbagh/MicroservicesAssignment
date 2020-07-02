using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserOrderAggregator.Model
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
