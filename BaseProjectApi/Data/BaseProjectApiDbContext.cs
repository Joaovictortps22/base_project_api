using BaseProjectApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProjectApi.Data
{
    public class BaseProjectApiDbContext : DbContext
    {
        public BaseProjectApiDbContext(DbContextOptions<BaseProjectApiDbContext> options) 
            : base(options) 
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
