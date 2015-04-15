using System;
using System.ComponentModel.DataAnnotations;

namespace NutriManager.Services.Models
{
    public class PacientModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Email { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime BornDate { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}
