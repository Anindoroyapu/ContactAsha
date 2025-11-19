using AshaApi.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectionFormApi.Models
{
    [Table("collection_form")]
    public class Collection
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; } = string.Empty;

        [Required, Column("title")]
        public string Title { get; set; } = string.Empty;

        [Required, Column("details")]
        public string Details { get; set; } = string.Empty;


        [Column("note")]
        public string Note { get; set; }= string.Empty;


        [Column("method")]
        public string Method { get; set; } = string.Empty;

        [Column("amount")]
        public int? Amount { get; set; }

        [Column("status")]
        public string? Stastus { get; set; } = string.Empty;



        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // ✅ Static Methods (Optional Utilities)
        public static async Task<List<Collection>> GetListAsync(AppDbContext context)
        {
            try
            {
                return await context.Collections.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching Collection list: {ex.Message}");
            }
        }

        public static async Task<Collection?> FindAsync(AppDbContext context, int id)
        {
            try
            {
                return await context.Collections.FirstOrDefaultAsync(b => b.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error finding Collection: {ex.Message}");
            }
        }
    }
}

