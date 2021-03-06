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
    public class LanguageRepository :BaseRepository<Language>, IRepositoryLanguage
    {
        public LanguageRepository(WordMasterDbContext context):base(context)
        {
            _context = context;
        }
      
    }
}
