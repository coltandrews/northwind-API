using System;
namespace northwindAPI.model
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }

        public Employee(int ID, string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.ID = ID;
        }
    }
}

