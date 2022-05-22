using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordApi.Entities;

namespace WordApi
{
    public class WordMasterDbContext : DbContext
    {
        public WordMasterDbContext(DbContextOptions<WordMasterDbContext> options) : base(options)
        {

        }

        public DbSet<WordDefinition> WordDefinitions { get; set; }
        //public DbSet<Language> Languages { get; set; }
        public DbSet<WordMeaning> WordMeanings { get; set; }

       

    }
}
