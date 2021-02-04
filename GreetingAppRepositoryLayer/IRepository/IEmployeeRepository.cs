using GreetingAppModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingAppRepositoryLayer.IRepository
{
    public interface IEmployeeRepository
    {
        Employee AddEmployee(Employee employee);
        IEnumerable<Employee> GetEmployees();
        bool DeleteEmployee(int EmpID);
        Employee UpdateEmployee(Employee employee);
    }
}
