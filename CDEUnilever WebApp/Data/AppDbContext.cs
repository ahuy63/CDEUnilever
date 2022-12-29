using CDEUnilever_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CDEUnilever_WebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<Area_Distributor> Areas_Distributors { get;set; }
        public DbSet<Area_User> Areas_Users { get; set; }
    }
}
