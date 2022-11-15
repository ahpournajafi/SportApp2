using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportApp2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SportApp2.Pages.Batch
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
            ViewData["SubGroup"] = new SelectList(_context.Subgroups, "Id", "Name");
            ViewData["Period"] = new SelectList(_context.Periods, "Id", "Name");
        }

        public async Task<JsonResult> OnGetJson(int groupId, int subgroupId, int periodId)
        {
            var _batch = await _context.Batches.Where(a => a.GroupId == groupId && a.SubgroupId == subgroupId && a.PeriodId == periodId).Select(a => new BatchDto { Id = a.Id, Name = a.Name }).ToListAsync();
            return new JsonResult(new { data = _batch });
        }

        public async Task OnGetDelete(long id)
        {
            try
            {
                var _batch = await _context.Batches.FindAsync(id);
                if (_batch != null)
                {
                    _context.Batches.Remove(_batch);
                    await _context.SaveChangesAsync();
                }
            }
            catch (System.Exception)
            {

            }
            ViewData["Group"] = new SelectList(_context.Groups, "Id", "Name");
            ViewData["SubGroup"] = new SelectList(_context.Subgroups, "Id", "Name");
            ViewData["Period"] = new SelectList(_context.Periods, "Id", "Name");
        }

        public class BatchDto
        {
            public long Id { get; set; }
            public string Name { get; set; }
        }
    }
}
