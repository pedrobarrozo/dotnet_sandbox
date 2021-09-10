using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoreItemsController : ControllerBase
    {
        private readonly ChoreContext _context;

        public ChoreItemsController(ChoreContext context)
        {
            _context = context;
        }

        // GET: api/ChoreItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChoreItem>>> GetChoreItems()
        {
            return await _context.ChoreItems.ToListAsync();
        }

        // GET: api/ChoreItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChoreItem>> GetChoreItem(long id)
        {
            var choreItem = await _context.ChoreItems.FindAsync(id);

            if (choreItem == null)
            {
                return NotFound();
            }

            return choreItem;
        }

        // PUT: api/ChoreItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChoreItem(long id, ChoreItem choreItem)
        {
            if (id != choreItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(choreItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChoreItemExists(id))
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

        // POST: api/ChoreItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChoreItem>> PostChoreItem(ChoreItem choreItem)
        {
            _context.ChoreItems.Add(choreItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetChoreItem", new { id = choreItem.Id }, choreItem);
            return CreatedAtAction(nameof(GetChoreItem), new { id = choreItem.Id }, choreItem);
        }

        // DELETE: api/ChoreItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChoreItem(long id)
        {
            var choreItem = await _context.ChoreItems.FindAsync(id);
            if (choreItem == null)
            {
                return NotFound();
            }

            _context.ChoreItems.Remove(choreItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChoreItemExists(long id)
        {
            return _context.ChoreItems.Any(e => e.Id == id);
        }
    }
}
