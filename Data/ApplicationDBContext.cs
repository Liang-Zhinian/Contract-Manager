using Microsoft.EntityFrameworkCore;
using PublishingContractManager.Models;

namespace PublishingContractManager.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Representative> Representatives { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        

    }
}