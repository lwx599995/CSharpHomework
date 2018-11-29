using System.Data.Entity;

namespace ordertest
{
    public class OrderDB : DbContext
    {
        public OrderDB() : base("ods"){ }
        public DbSet<Order> Order { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
    }
}
