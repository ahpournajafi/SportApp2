using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportApp2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SportApp2.Pages.Group
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

        }

        public async Task<JsonResult> OnGetJson()
        {
            var _group = await _context.Groups.Select(a => new BatchDto { Id = a.Id, Name = a.Name }).ToListAsync();
            return new JsonResult(new { data = _group });
        }

        public async Task OnGetDelete(long id)
        {
            try
            {
                var _group = await _context.Groups.FindAsync(id);
                if (_group != null)
                {
                    _context.Groups.Remove(_group);
                    await _context.SaveChangesAsync();
                }
            }
            catch (System.Exception)
            {

            }
        }

        public class BatchDto
        {
            public long Id { get; set; }
            public string Name { get; set; }
        }
    }
}
