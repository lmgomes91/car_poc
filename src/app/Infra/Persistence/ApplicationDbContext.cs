using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using poc.src.appDomain.Entities;

namespace poc.src.app.Infra.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Vehicle> Vehicle {get; set;}
    }
}