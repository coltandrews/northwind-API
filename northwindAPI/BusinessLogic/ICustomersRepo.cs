using System.Collections.Generic;
using northwindAPI.model;

namespace northwindAPI.BusinessLogic
{
    public interface ICustomersRepo
    {
        IEnumerable<Customer> getCustomers();
    }
}