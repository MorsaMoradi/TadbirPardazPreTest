using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TadbirPardazPreTest.Domain;

namespace TadbirPardazPreTest.Persistance
{
    public class TadbirDbContext: DbContext
    {
        public TadbirDbContext(DbContextOptions<TadbirDbContext> options):base(options)
        {

        }
        public DbSet<User>  Users { get; set; }
    }
}
