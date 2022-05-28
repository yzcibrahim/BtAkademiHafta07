using AccountApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountApi
{
    public class WordMasterDbContext:DbContext
    {
        public WordMasterDbContext(DbContextOptions<WordMasterDbContext> options):base(options)
        {

        }

        public DbSet<UserAccount> UserAccounts{ get; set; }
    }
}
