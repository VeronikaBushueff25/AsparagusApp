using AsparagusApp.Data;
using AsparagusApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AsparagusApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var existingUser = await _context.users.FirstOrDefaultAsync(u => u.email == user.email);

            if (existingUser != null)
            {
                existingUser.name = user.name;
                existingUser.asparaguscount++;
                existingUser.lastasparagusdate = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return Ok(existingUser);
            }

            user.asparaguscount = 1;
            user.lastasparagusdate = DateTime.UtcNow;
            _context.users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.id }, user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.users.OrderByDescending(u => u.lastasparagusdate).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
    }
}