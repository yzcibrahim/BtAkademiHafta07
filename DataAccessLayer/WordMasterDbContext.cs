using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class WordMasterDbContext:DbContext
    {
        public WordMasterDbContext(DbContextOptions<WordMasterDbContext> options):base(options)
        {

        }

        public DbSet<WordDefinition> WordDefinitions { get; set; }

    }
}
