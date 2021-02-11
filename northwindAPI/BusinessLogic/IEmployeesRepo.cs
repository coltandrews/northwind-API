using System.Collections.Generic;
using northwindAPI.model;

namespace northwindAPI.BusinessLogic
{
    public interface IEmployeesRepo
    {
        IEnumerable<Employee> getEmployees();
        Employee getEmployeeById(string id);
        Employee updateEmployee(Employee employee);
        Employee addEmployee(Employee employee);
    }
}