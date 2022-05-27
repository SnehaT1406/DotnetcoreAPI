using BAL.Service;
using DAL.Interface;
using DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5APIWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailsController : ControllerBase
    {
        private readonly EmployeeService _EmployeeService;
        private readonly IRepository<Employee> _Employee;

        public EmployeeDetailsController(IRepository<Employee> Employee, EmployeeService ProductService)
        {
            _EmployeeService = ProductService;
            _Employee = Employee;

        }
        //Add Employee
        [HttpPost("AddEmployee")]
        public async Task<Object> AddEmployee([FromBody] Employee Employee)
        {
            try
            {
                await _EmployeeService.AddEmployee(Employee);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
       
       
        //GET All Employee by Name
        [HttpGet("GetAllEmployeeByName")]
        public Object GetAllEmployeeByName(string UserEmail)
        {
            var data = _EmployeeService.GetEmployeeByUserName(UserEmail);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        //GET All Employee
        [HttpGet("GetAllEmployees")]
        public Object GetAllEmployees()
        {
            var data = _EmployeeService.GetAllEmployees();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
    }
}
