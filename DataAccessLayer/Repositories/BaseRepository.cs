using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BaseRepository<T>  : IRepositoryBase<T> where T : class
    {
        protected WordMasterDbContext _context;

        public BaseRepository(WordMasterDbContext context)
        {
            _context = context;
        }
        public virtual T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual void Delete(int id)
        {
            var existing = GetById(id);
            _context.Set<T>().Remove(existing);
            _context.SaveChanges();
        }

        public virtual T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual List<T> List()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry<T>(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}
