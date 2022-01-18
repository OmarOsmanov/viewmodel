using booot.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace booot.Data
{
    public class AppDbContext:IdentityDbContext
    {

        public AppDbContext(DbContextOptions options):base(options)
        {

        }


        public DbSet<Product> Products  { get; set; }
        public DbSet<Setting> Settings { get; set; }
        //public DbSet<CustomUser> Users { get; set; }

    }
}
