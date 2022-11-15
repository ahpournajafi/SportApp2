using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportApp2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SportApp2.Pages.ExamType
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
            var _examType = await _context.ExamTypes.Select(a => new BatchDto { Id = a.Id, Name = a.Name }).ToListAsync();
            return new JsonResult(new { data = _examType });
        }

        public async Task OnGetDelete(long id)
        {
            try
            {
                var _examType = await _context.ExamTypes.FindAsync(id);
                if (_examType != null)
                {
                    _context.ExamTypes.Remove(_examType);
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
