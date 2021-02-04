using GreetingAppBusinessLayer.IManager;
using GreetingAppModelLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager manager;
        public EmployeeController(IEmployeeManager manager)
        {
            this.manager = manager;

        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            try
            {
                var result = this.manager.AddEmployee(employee);
                if(result!=null)
                {
                    return this.Ok(new { Status=true, Message="Empployee Added Successfully", Data=result});
                }
                return this.BadRequest(new { Status = false, Message = "Empployee Added Un-Successfull", Data = result });
            }
            catch(Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployee()
        {
            try
            {
                var result = this.manager.GetEmployees();
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "List Of Employee Details", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "No records Found", Data = result });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee )
        {
            try
            {
                var result = this.manager.UpdateEmployee(employee);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Employee Updated Sucssesfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Employee Updation Un-Sucssesfull", Data = result });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        [HttpDelete]
        public IActionResult DeleteEmployee(int EmpId)
        {
            try
            {
                var result = this.manager.DeleteEmployee(EmpId);
                if (result)
                {
                    return this.Ok(new { Status = true, Message = "Employee Deleted Sucssesfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Employee Deletion Un-Sucssesfull", Data = result });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message});
            }
        }
    }
}
