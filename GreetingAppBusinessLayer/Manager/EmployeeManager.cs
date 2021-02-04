using GreetingAppBusinessLayer.IManager;
using GreetingAppModelLayer;
using GreetingAppRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingAppBusinessLayer.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository repository;
        public EmployeeManager(IEmployeeRepository repository)
        {
            this.repository = repository;
        }
        public Employee AddEmployee(Employee employee)
        {
            return this.repository.AddEmployee(employee);
        }

        public bool DeleteEmployee(int EmpID)
        {
            return this.repository.DeleteEmployee(EmpID);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return this.repository.GetEmployees();
        }

        public Employee UpdateEmployee(Employee employee)
        {
            return this.repository.UpdateEmployee(employee);
        }
    }
}
