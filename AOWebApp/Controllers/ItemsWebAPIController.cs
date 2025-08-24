using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AOWebApp.Data;
using AOWebApp.Models;

namespace AOWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsWebAPIController : ControllerBase
    {
        private readonly Data.AmazonOrdersContext _context;

        public ItemsWebAPIController(Data.AmazonOrdersContext context)
        {
            _context = context;
        }

        // GET: api/ItemsWebAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Items>>> GetItems(string? SearchText, int? CategoryID)
        {
            var query = _context.Items
                .OrderBy(i => i.ItemName)
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                query = query.Where(i => i.ItemName.Contains(SearchText));
            }
            if (CategoryID.HasValue)
            {
                query = query.Where(i => i.Category.ParentCategoryId == CategoryID);
            }
            return await _context.Items.ToListAsync();
        }

        // GET: api/ItemsWebAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Items>> GetItems(int id)
        {
            var items = await _context.Items.FindAsync(id);

            if (items == null)
            {
                return NotFound();
            }

            return items;
        }

        // PUT: api/ItemsWebAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItems(int id, Items items)
        {
            if (id != items.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(items).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemsExists(id))
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

        // POST: api/ItemsWebAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Items>> PostItems(Items items)
        {
            _context.Items.Add(items);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItems", new { id = items.ItemId }, items);
        }

        // DELETE: api/ItemsWebAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItems(int id)
        {
            var items = await _context.Items.FindAsync(id);
            if (items == null)
            {
                return NotFound();
            }

            _context.Items.Remove(items);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemsExists(int id)
        {
            return _context.Items.Any(e => e.ItemId == id);
        }
    }
}
