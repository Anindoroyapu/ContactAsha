using System.ComponentModel.DataAnnotations;

namespace ContactFormApi.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public string BookingType { get; set; } = "portrait"; // or wedding

        [Required]
        public DateTime PreferredDate { get; set; }

        public string? StartTime { get; set; }
        public string? EndTime { get; set; }

        public string Location { get; set; } = string.Empty;
        public string? District { get; set; }
        public int? NumberOfPeople { get; set; }

        public string? Message { get; set; }

        public string? PackageName { get; set; }
        public string? PackageDescription { get; set; }
        public int? PackagePrice { get; set; }

        public int? Budget { get; set; }

        public string? PaymentMethod { get; set; }
        public string Status { get; set; } = "pending"; // pending, confirmed, etc.
        public string PaymentStatus { get; set; } = "unpaid"; // unpaid, paid, etc.
        public DateTime? PaymentReceivedAt { get; set; }

        public string? ReferencePhotos { get; set; }
        public string? LeadSource { get; set; }

        public bool ConsentTerms { get; set; } = false;
        public bool CanUseForPortfolio { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
