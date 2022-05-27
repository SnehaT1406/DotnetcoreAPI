using DAL.Data;
using DAL.Interface;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RepositoryEmployee : IRepository<Employee>
    {
        ApplicationDbContext _dbContext;
        public RepositoryEmployee(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Employee> Create(Employee _object)
        {
            var obj = await _dbContext.Employees.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public IEnumerable<Employee> GetAll()
        {
            try
            {
                return _dbContext.Employees.Where(x => x.IsDeleted == false).ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public Employee GetById(int Id)
        {
            return _dbContext.Employees.Where(x => x.IsDeleted == false && x.Id == Id).FirstOrDefault();
        }

        
    }
}
