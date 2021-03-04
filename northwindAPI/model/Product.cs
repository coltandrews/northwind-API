using System;
namespace northwindAPI.model
{
    public class Product
    {
        public string ProductName { get; set; }
        public bool Discontinued { get; set; }
        public int ProductID { get; set; }

        public Product()
        {
        }

    }
}