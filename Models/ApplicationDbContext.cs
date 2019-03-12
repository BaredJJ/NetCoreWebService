using Microsoft.EntityFrameworkCore;

namespace WebService.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {}

        public DbSet<CurrentCurrency> CurrentCurrency { get; set; }
    }
}
