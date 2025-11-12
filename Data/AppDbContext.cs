using Microsoft.EntityFrameworkCore;
using ContactFormApi.Models;
using BookingFormApi.Models;
using AddProductApi.Models;
using ExpenditureFormApi.Models;

namespace AshaApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }  
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<AddProduct> AddProducts { get; set; }

        public DbSet<Expenditure> Expenditures { get; set; }


    }
}