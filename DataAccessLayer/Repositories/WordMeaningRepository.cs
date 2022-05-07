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
    public class WordMeaningRepository : BaseRepository<WordMeaning>, IRepositoryMeaning
    {
        public WordMeaningRepository(WordMasterDbContext context):base(context)
        {            
        }

        public override List<WordMeaning> List()
        {
            return _context.Set<WordMeaning>().Include(c => c.Lang).Include(c => c.WordDef).ToList();
        }

        public List<WordMeaning> ListByDefId(int defId)
        {
            return _context.Set<WordMeaning>().Include(c => c.Lang).Where(c => c.WordDefinitionId == defId).ToList();
        }

    }

    
   
}
