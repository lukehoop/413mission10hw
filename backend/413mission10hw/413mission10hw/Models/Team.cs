using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _413mission10hw.Models
{
    // maps to the teams table in sqlite
    [Table("teams")]
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string TeamName { get; set; }

        // collection used for navigation from bowler to team
        public ICollection<Bowler> Bowlers { get; set; }
    }
}
