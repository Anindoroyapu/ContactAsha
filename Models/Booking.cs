using AshaApi.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingFormApi.Models
{
    [Table("booking_form")]
    public class Booking
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; } = string.Empty;

        [Required, Column("email")]
        public string Email { get; set; } = string.Empty;

        [Required, Column("phone")]
        public string Phone { get; set; } = string.Empty;

        [Required, Column("subject")]
        public string Subject { get; set; } = string.Empty;

        [Column("booking_type")]
        public string BookingType { get; set; } = "portrait"; // default: portrait or wedding

        [Column("start_date")]
        public string StartDate { get; set; } = string.Empty;

        [Column("end_date")]
        public string EndDate { get; set; } = string.Empty;

        [Column("location")]
        public string Location { get; set; } = string.Empty;

        [Column("message")]
        public string? Message { get; set; }

        [Column("package")]
        public string? Package { get; set; }

        [Column("total_cost")]
        public int? TotalCost { get; set; }

        [Column("booking_cost")]
        public int? BookingCost { get; set; }

        [Column("payment_method")]
        public string? PaymentMethod { get; set; }

        [Column("status")]
        public string Status { get; set; } = "pending";

        [Column("payment_status")]
        public string PaymentStatus { get; set; } = "unpaid";

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // ✅ Static Methods (Optional Utilities)
        public static async Task<List<Booking>> GetListAsync(AppDbContext context)
        {
            try
            {
                return await context.Bookings.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching booking list: {ex.Message}");
            }
        }

        public static async Task<Booking?> FindAsync(AppDbContext context, int id)
        {
            try
            {
                return await context.Bookings.FirstOrDefaultAsync(b => b.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error finding booking: {ex.Message}");
            }
        }
    }
}
