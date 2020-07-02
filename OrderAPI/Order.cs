using System;

namespace OrderAPI
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
