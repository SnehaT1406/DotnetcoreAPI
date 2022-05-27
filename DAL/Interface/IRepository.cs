using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepository<T>
    {
        public Task<T> Create(T _object);

        public IEnumerable<T> GetAll();

        public T GetById(int Id);

    }
}