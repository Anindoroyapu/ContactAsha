using Microsoft.EntityFrameworkCore;
using ContactFormApi.Models;

namespace ContactFormApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ContactMessage> ContactMessages { get; set; }
    }
}
