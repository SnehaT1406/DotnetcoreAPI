using DAL.Interface;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    public class EmployeeService
    {
        private readonly IRepository<Employee> _Employee;

        public EmployeeService(IRepository<Employee> perosn)
        {
            _Employee = perosn;
        }
        
        //GET All Employee Details 
        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                return _Employee.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Get Employee by Employee Name
        public Employee GetEmployeeByUserName(string UserName)
        {
            return _Employee.GetAll().Where(x => x.UserEmail == UserName).FirstOrDefault();
        }
        //Add Employee
        public async Task<Employee> AddEmployee(Employee Employee)
        {
            return await _Employee.Create(Employee);
        }
    }
}