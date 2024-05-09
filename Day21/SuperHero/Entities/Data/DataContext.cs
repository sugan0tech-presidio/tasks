using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHero.Entities.Data
{
    internal class DataContext: DbContext
    {
        // should be name of the table
        public DbSet<SuperHero> SuperHeroes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=B4RBBX3\SQLEXPRESS;Integrated Security=true;Initial Catalog=SuperHero;Encrypt=false");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
