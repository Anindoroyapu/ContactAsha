using ContactFormApi.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactFormApi.Models
{
    [Table("booking_form")]
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("full_name")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Column("phone")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [Column("booking_type")]
        public string BookingType { get; set; } = "portrait"; // or wedding

        [Column("start_date")]
        public string StartDate { get; set; } = string.Empty;

        [Column("end_date")]
        public string EndDate { get; set; } = string.Empty;

        [Required]
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
        public string Status { get; set; } = "pending"; // pending, confirmed, etc.

        [Column("payment_status")]
        public string PaymentStatus { get; set; } = "unpaid"; // unpaid, paid, etc.

      
      


        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

       
        public static async Task<List<Booking>> GetListAsync( AppDbContext _context)
        {
            try
            {
                var bookingList = await _context.Booking.ToListAsync();

                return bookingList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<Booking?> FindAsync( AppDbContext _context, int id)
        {
            try
            {
                var booking = await _context.Booking.FirstOrDefaultAsync(b => b.Id == id);
                if (booking == null)
                {
                    return null;
                }

                return booking;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
