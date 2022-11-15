using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportApp2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SportApp2.Pages.Period
{
    public class IndexModel : PageModel
    {
        SportDBContext _context;

        public IndexModel()
        {
            _context = new SportDBContext();
            _context.Database.EnsureCreated();
        }

        public void OnGet()
        {
            ViewData["Group"] = new SelectList(_context.Groups, "Id", "Name");
        }

        public async Task<JsonResult> OnGetJson(int groupId)
        {
            var _period = await _context.Periods.Where(a => a.GroupId == groupId).Select(a => new BatchDto { Id = a.Id, Name = a.Name }).ToListAsync();
            return new JsonResult(new { data = _period });
        }

        public async Task OnGetDelete(long id)
        {
            try
            {
                var _period = await _context.Periods.FindAsync(id);
                if (_period != null)
                {
                    _context.Periods.Remove(_period);
                    await _context.SaveChangesAsync();
                }
            }
            catch (System.Exception)
            {

            }
            ViewData["Group"] = new SelectList(_context.Groups, "Id", "Name");

        }

        public class BatchDto
        {
            public long Id { get; set; }
            public string Name { get; set; }
        }
    }
}
