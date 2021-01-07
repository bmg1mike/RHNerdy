using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class NerdyContext : IdentityDbContext<NerdyUser>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Dispatcher> Dispatchers { get; set; }
        public DbSet<BookImage> BookImages { get; set; }
        public NerdyContext(DbContextOptions options):base(options)
        {

        }
    }
}
