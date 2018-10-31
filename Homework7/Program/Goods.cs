using System;

namespace ordertest
{
    public class Goods
    {

        private double price;
        public Goods() { }
        public Goods(string id, string name, double value)
        {
            Id = id;
            Name = name;
            Price = value;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value must >= 0!");
                price = value;
            }
        }
        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}, Value:{Price}";
        }
    }
}
