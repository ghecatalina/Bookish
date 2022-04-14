using Domain;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        //public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<RegularUser> RegularUsers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<BookList> BookLists { get; set; }
    }
}
