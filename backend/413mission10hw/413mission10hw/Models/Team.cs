using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _413mission10hw.Models
{
    // Map to existing SQLite table 'teams'
    [Table("teams")]
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string TeamName { get; set; }

        // Navigation property
        public ICollection<Bowler> Bowlers { get; set; }
    }
}