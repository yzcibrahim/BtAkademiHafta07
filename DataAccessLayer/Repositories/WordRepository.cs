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
    public class WordRepository : BaseRepository<WordDefinition>, IRepositoryWord
    {
        public WordRepository(WordMasterDbContext context):base(context)
        {
            
        }

        public override List<WordDefinition> List()
        {
            return _context.Set<WordDefinition>().Include(c=>c.Meanings).ThenInclude(c=>c.Lang).ToList();
        }
    }

    
   
}
