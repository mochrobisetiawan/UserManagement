using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManagementContext _context;

        public UserController(UserManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Muser>>> GetMusers()
        {
            if (_context.Musers == null)
            {
                return NotFound();
            }           
                return await _context.Musers.ToListAsync();
        }


        // GET: api/User
        [HttpGet("paging")]
        public async Task<ActionResult<IEnumerable<Muser>>> GetMusers(int pagenum, int pagepos)
        {
            if (_context.Musers == null)
            {
                return NotFound();
            }

                return await _context.Musers.Skip(pagenum * (pagepos - 1)).Take(pagenum).ToListAsync();         
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Muser>> GetMuser(int id)
        {
            if (_context.Musers == null)
            {
                return NotFound();
            }
            var muser = await _context.Musers.FindAsync(id);

            if (muser == null)
            {
                return NotFound();
            }

            return muser;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMuser(int id, Muser muser)
        {
            if (id != muser.Id)
            {
                return BadRequest();
            }

            _context.Entry(muser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MuserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Muser>> PostMuser(Muser muser)
        {
            if (_context.Musers == null)
            {
                return Problem("Entity set 'UserManagementContext.Musers'  is null.");
            }
            _context.Musers.Add(muser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMuser", new { id = muser.Id }, muser);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMuser(int id)
        {
            if (_context.Musers == null)
            {
                return NotFound();
            }
            var muser = await _context.Musers.FindAsync(id);
            if (muser == null)
            {
                return NotFound();
            }

            _context.Musers.Remove(muser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MuserExists(int id)
        {
            return (_context.Musers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
