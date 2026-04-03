using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _413mission10hw.Models
{
    // maps to the bowlers table in sqlite
    [Table("bowlers")]
    public class Bowler
    {
        [Key]
        public int BowlerId { get; set; }

        [Required]
        public string BowlerFirstName { get; set; }

        // optional middle initial column may be null in the database
        public string? BowlerMiddleInit { get; set; }

        [Required]
        public string BowlerLastName { get; set; }

        public string BowlerAddress { get; set; }

        public string BowlerCity { get; set; }

        public string BowlerState { get; set; }

        public string BowlerZip { get; set; }

        public string BowlerPhoneNumber { get; set; }

        // links to teams teamid
        public int TeamId { get; set; }

        // loaded with include for queries that need the team name
        [ForeignKey("TeamId")]
        public Team Team { get; set; }
    }
}
