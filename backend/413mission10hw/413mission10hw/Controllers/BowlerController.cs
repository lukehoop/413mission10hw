using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _413mission10hw.Data;
using _413mission10hw.Models;

namespace _413mission10hw.Controllers
{
    // route template resolves to api bowler from the controller class name
    [Route("api/[controller]")]
    [ApiController]
    public class BowlerController : ControllerBase
    {
        private readonly BowlingDbContext _context;

        public BowlerController(BowlingDbContext context)
        {
            _context = context;
        }

        // returns json list of marlins and sharks bowlers with contact fields
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BowlerDto>>> GetBowlers()
        {
            var bowlers = await _context.Bowlers
                .Include(b => b.Team)
                .Where(b => b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")
                .Select(b => new BowlerDto
                {
                    BowlerFullName = b.BowlerFirstName +
                        (string.IsNullOrEmpty(b.BowlerMiddleInit) ? " " : $" {b.BowlerMiddleInit}. ") +
                        b.BowlerLastName,
                    TeamName = b.Team.TeamName,
                    Address = b.BowlerAddress,
                    City = b.BowlerCity,
                    State = b.BowlerState,
                    Zip = b.BowlerZip,
                    PhoneNumber = b.BowlerPhoneNumber
                })
                .ToListAsync();

            return Ok(bowlers);
        }
    }
}
