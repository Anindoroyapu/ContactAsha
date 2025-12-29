using Microsoft.EntityFrameworkCore;
using ContactFormApi.Models;
using BookingFormApi.Models;
using AddProductApi.Models;
using ExpenditureFormApi.Models;
using CollectionFormApi.Models;
using CheckoutFormApi.Models;
using AshaContactFormApi.Models;
using AshaCollectionFormApi.Models;
using AshaExpenditureFormApi.Models;


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
        public DbSet<AshaExpenditure> AshaExpenditures { get; set; }
        public DbSet<Collection> Collections { get; set; }
         public DbSet<Checkout> Checkouts { get; set; }
         public DbSet<AshaContact> AshaContacts { get; set; }
        public DbSet<AshaCollection> AshaCollections { get; set; }
        public DbSet<Checkout> Checkout { get; set; }


    }
}