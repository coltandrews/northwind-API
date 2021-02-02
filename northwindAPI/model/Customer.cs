using System;
namespace northwindAPI.model
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }

        public Customer(string CustomerID, string CompanyName)
        {
            this.CustomerID = CustomerID;
            this.CompanyName = CompanyName;
           
        }
        public Customer(string CustomerID, string CompanyName, string PhoneNumber)
        {
            this.CustomerID = CustomerID;
            this.CompanyName = CompanyName;
            this.PhoneNumber = PhoneNumber;

        }
    }
}

