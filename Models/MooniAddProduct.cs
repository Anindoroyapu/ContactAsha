using AshaApi.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MooniAddProductApi.Models
{
    [Table("mooni_product_list")]
    public class MooniAddProduct
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("brand_sl")]
        public string BrandSl { get; set; } = string.Empty;

        [Required, Column("title")]
        public string Title { get; set; } = string.Empty;

        [Required, Column("sub_title")]
        public string SubTitle { get; set; } = string.Empty;

        [Required, Column("unit")]
        public string Unit { get; set; } = string.Empty;

        [Column("price_purchase")]
        public string PricePurchase { get; set; } = string.Empty; 

        [Column("price_sale")]
        public string PriceSale { get; set; } = string.Empty;

        [Column("price_sale_offer")]
        public string PriceSalOffer { get; set; } = string.Empty;

        [Column("product_description")]
        public string ProductDescription { get; set; } = string.Empty;

        [Column("default_image")]
        public string? DefaultImage { get; set; }

        [Column("category_title")]
        public string? CategoryTitle { get; set; }

        [Column("is_in_stock")]
        public string? IsInStock { get; set; } = string.Empty;

        [Column("delivery_amount")]
        public string DeliveryAmount { get; set; } = string.Empty;


        [Column("status")]
        public string Status { get; set; } = "pending";


        [Column("time_created")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("time_updated")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // ✅ Static Methods (Optional Utilities)
        public static async Task<List<MooniAddProduct>> GetListAsync(AppDbContext context)
        {
            try
            {
                return await context.MooniAddProducts.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching Product list: {ex.Message}");
            }
        }

        public static async Task<MooniAddProduct?> FindAsync(AppDbContext context, int id)
        {
            try
            {
                return await context.MooniAddProducts.FirstOrDefaultAsync(b => b.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error finding Product: {ex.Message}");
            }
        }
    }
}
