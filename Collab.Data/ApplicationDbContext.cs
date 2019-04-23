using System;
using System.Collections.Generic;
using System.Text;
using Collab.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Collab.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
