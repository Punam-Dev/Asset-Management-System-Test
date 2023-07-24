using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asset_Management_System.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Assets> Assets { get; set; }
        public DbSet<Hardware> Hardware { get; set; }
        public DbSet<Vendors> Vendors { get; set; }
    }
}
