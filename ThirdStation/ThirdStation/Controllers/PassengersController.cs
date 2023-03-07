using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ThirdStation
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassengersController : ControllerBase
    {
        private readonly ThirdStationContext _context;

        public PassengersController(ThirdStationContext context)
        {
            _context = context;

        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passenger>>> GetPassengers()
        {
            if (_context.Passengers == null)
            {
                return NotFound();
            }
            return await _context.Passengers.ToListAsync();
        }

    };


}