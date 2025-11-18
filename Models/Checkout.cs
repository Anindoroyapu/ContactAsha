using AshaApi.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckoutFormApi.Models
{
    [Table("checkout_list")]
    public class Checkout
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, Column("full_name")]
        public string FullName { get; set; } = string.Empty;

        [Required, Column("email")]
        public string Email { get; set; } = string.Empty;

        [Required, Column("phone")]
        public string Phone { get; set; } = string.Empty;

        [Required, Column("size")]
        public string Size { get; set; } = string.Empty;
        
        [Required, Column("address")]
        public string Address { get; set; } = string.Empty;

        [Column("sub_total")]
        public string? SubTotal { get; set; }
        
        [Column("total")]
        public string? Total { get; set; }
        
        [Column("shipping")]
        public string? Shipping { get; set; }
        
        [Column("quantity")]
        public string? Quantity { get; set; }
        
        [Column("product_name")]
        public string? ProductName { get; set; }
        
        [Column("product_id")]
        public string? ProductId { get; set; }
        
        [Column("product_sku")]
        public string? ProductSku { get; set; }







        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


        // ✅ Static utility methods
        public static async Task<List<Checkout>> GetListAsync(AppDbContext context)
        {
            try
            {
                return await context.Checkouts.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching Checkout list: {ex.Message}");
            }
        }

        public static async Task<Checkout?> FindAsync(AppDbContext context, int id)
        {
            try
            {
                return await context.Checkouts.FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error finding Checkout: {ex.Message}");
            }
        }
    }
}
