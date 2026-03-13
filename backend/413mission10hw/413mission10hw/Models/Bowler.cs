using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _413mission10hw.Models
{
    // Map to existing SQLite table 'bowlers'
    [Table("bowlers")]
    public class Bowler
    {
        [Key]
        public int BowlerId { get; set; }

        [Required]
        public string BowlerFirstName { get; set; }

        // Can be NULL in the SQLite database
        public string? BowlerMiddleInit { get; set; }

        [Required]
        public string BowlerLastName { get; set; }

        public string BowlerAddress { get; set; }

        public string BowlerCity { get; set; }

        public string BowlerState { get; set; }

        public string BowlerZip { get; set; }

        public string BowlerPhoneNumber { get; set; }

        // Foreign Key
        public int TeamId { get; set; }

        // Navigation property
        [ForeignKey("TeamId")]
        public Team Team { get; set; }
    }
}