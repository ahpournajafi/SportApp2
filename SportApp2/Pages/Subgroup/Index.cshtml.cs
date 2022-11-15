using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportApp2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SportApp2.Pages.Subgroup
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
            ViewData["Period"] = new SelectList(_context.Periods, "Id", "Name");
        }

        public async Task<JsonResult> OnGetJson(int groupId, int periodId)
        {
            var _sub = await _context.Subgroups.Where(a => a.GroupId == groupId &&  a.PeriodId == periodId).Select(a => new BatchDto { Id = a.Id, Name = a.Name }).ToListAsync();
            return new JsonResult(new { data = _sub });
        }

        public async Task OnGetDelete(long id)
        {
            try
            {
                var _sub = await _context.Subgroups.FindAsync(id);
                if (_sub != null)
                {
                    _context.Subgroups.Remove(_sub);
                    await _context.SaveChangesAsync();
                }
            }
            catch (System.Exception)
            {

            }
            ViewData["Group"] = new SelectList(_context.Groups, "Id", "Name");
            ViewData["Period"] = new SelectList(_context.Periods, "Id", "Name");
        }

        public class BatchDto
        {
            public long Id { get; set; }
            public string Name { get; set; }
        }
    }
}
