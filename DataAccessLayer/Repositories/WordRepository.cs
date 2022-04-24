using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class WordRepository : IRepositoryWord
    {
        WordMasterDbContext _context;
        public WordRepository(WordMasterDbContext context)
        {
            _context = context;
        }
        public WordDefinition Add(WordDefinition entity)
        {
            _context.Set<WordDefinition>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var existing = GetById(id);
            _context.Set<WordDefinition>().Remove(existing);
            _context.SaveChanges();
        }

        public WordDefinition GetById(int id)
        {
            return _context.Set<WordDefinition>().Find(id);
        }

        public List<WordDefinition> List()
        {
            return _context.Set<WordDefinition>().ToList();
        }

        public WordDefinition Update(WordDefinition entity)
        {
            _context.Set<WordDefinition>().Attach(entity);
            _context.Entry<WordDefinition>(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}
