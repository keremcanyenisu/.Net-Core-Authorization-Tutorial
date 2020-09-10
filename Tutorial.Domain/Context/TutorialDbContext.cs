using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tutorial.Domain.Entities;

namespace Tutorial.Domain.Context
{
    public class TutorialDbContext : DbContext
    {

        public TutorialDbContext(DbContextOptions<TutorialDbContext> options)
    : base(options)
        { }

        public DbSet<User> Users { get; set; }


    }
}
