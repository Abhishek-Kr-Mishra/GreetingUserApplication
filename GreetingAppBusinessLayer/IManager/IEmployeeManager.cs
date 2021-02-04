using GreetingAppModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingAppBusinessLayer.IManager
{
    public interface IEmployeeManager
    {
        Employee AddEmployee(Employee employee);
        IEnumerable<Employee> GetEmployees();
        bool DeleteEmployee(int EmpID);
        Employee UpdateEmployee(Employee employee);
    }
}
