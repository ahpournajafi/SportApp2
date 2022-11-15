using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportApp2.Models;
using System.Threading.Tasks;

namespace SportApp2.Pages.ExamType
{
    public class CreateModel : PageModel
    {
        SportDBContext _context;

        public CreateModel()
        {
            _context = new SportDBContext();
            _context.Database.EnsureCreated();
        }

        [BindProperty]
        public Models.ExamType examType  { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("Create");
            }
            await _context.ExamTypes.AddAsync(examType);
            await _context.SaveChangesAsync();

            return RedirectToPage("Create");
        }
    }
}
