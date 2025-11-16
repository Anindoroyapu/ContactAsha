using AshaApi.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactFormApi.Models
{
    [Table("contact_form")]
    public class Contact
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

        [Required, Column("subject")]
        public string Subject { get; set; } = string.Empty;

        [Column("message")]
        public string? Message { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


        // ✅ Static utility methods
        public static async Task<List<Contact>> GetListAsync(AppDbContext context)
        {
            try
            {
                return await context.Contacts.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching contact list: {ex.Message}");
            }
        }

        public static async Task<Contact?> FindAsync(AppDbContext context, int id)
        {
            try
            {
                return await context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error finding contact: {ex.Message}");
            }
        }
    }
}
