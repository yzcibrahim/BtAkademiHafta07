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
            return _context.Set<WordDefinition>().Include(c=>c.Lang).Include(c=>c.Meanings).ThenInclude(c=>c.Lang).ToList();
        }

        public List<WordDefinition>List(string searchKeyword,int selectedLangId)
        {
            var result = new List<WordDefinition>();
            var query= _context.Set<WordDefinition>().Include(c => c.Lang).Include(c => c.Meanings).ThenInclude(c => c.Lang).Where(c=>true);

            if (!string.IsNullOrWhiteSpace(searchKeyword))
            {
                //query = query.Where(c => c.Word == searchKeyword);
                query = query.Where(c => c.Word.ToUpper().Contains(searchKeyword.ToUpper()));
            }
            if(selectedLangId>0)
            {
                query = query.Where(c => c.LanguageId == selectedLangId);
            }
            
            result = query.ToList();

            return result;
        }


    }

    
   
}
