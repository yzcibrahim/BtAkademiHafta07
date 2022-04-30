using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepositoryBase<T>
    {
        List<T> List();
        T GetById(int id);
        void Delete(int id);
        T Add(T entity);
        T Update(T entity);
    }
}
