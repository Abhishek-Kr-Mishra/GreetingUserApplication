using GreetingAppModelLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using GreetingAppRepositoryLayer.IRepository;
using Microsoft.Extensions.Configuration;

namespace GreetingAppRepositoryLayer.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration configuration;
        public string connectionString;
        SqlConnection sqlConnection;
        public EmployeeRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("UserDbConnection");
            sqlConnection = new SqlConnection(connectionString);
        }
         SqlCommand command;

        public Employee AddEmployee(Employee employee)
        {
            try
            {
                command = new SqlCommand("sp_AddGreetingUser", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmpName", employee.EmpName);
                command.Parameters.AddWithValue("@EmailID", employee.EmailID);
                command.Parameters.AddWithValue("@MobileNumber", employee.MobileNumber);
                command.Parameters.AddWithValue("@Address", employee.Address);
                command.Parameters.AddWithValue("@Password", employee.Password);

                this.sqlConnection.Open();
                var result = command.ExecuteNonQuery();
                this.sqlConnection.Close();
                if (result != 0)
                {
                    return employee;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                List<Employee> empList = new List<Employee>();
                command = new SqlCommand("sp_RetrieveGreetingUser", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                this.sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmpID = reader.GetInt32(0);
                        employee.EmpName = reader.GetString(1);
                        employee.EmailID = reader.GetString(2);
                        employee.MobileNumber = reader.GetInt64(3);
                        employee.Address = reader.GetString(4);
                        employee.Password = reader.GetString(5);

                        empList.Add(employee);
                    }
                }
                return empList;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
        public bool DeleteEmployee(int EmpID)
        {
            try
            {
                command = new SqlCommand("sp_DeleteGreetingUser", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmpID", EmpID);

                this.sqlConnection.Open();
                var result = command.ExecuteNonQuery();
                if (result != 0)
                {
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public Employee UpdateEmployee(Employee employee)
        { 
            try
            {
                command = new SqlCommand("sp_UpdateGreetingUser", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmpID", employee.EmpID);
                command.Parameters.AddWithValue("@EmpName", employee.EmpName);
                command.Parameters.AddWithValue("@EmailID", employee.EmailID);
                command.Parameters.AddWithValue("@MobileNumber", employee.MobileNumber);
                command.Parameters.AddWithValue("@Address", employee.Address);
                command.Parameters.AddWithValue("@Password", employee.Password);

                this.sqlConnection.Open();
                var result = command.ExecuteNonQuery();
                this.sqlConnection.Close();
                if (result != 0)
                {
                    return employee;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
