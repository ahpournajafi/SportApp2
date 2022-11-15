using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportApp2.Models;
using System.Threading.Tasks;

namespace SportApp2.Pages.Person
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
        public Models.Person person { get; set; }

        public async Task OnGet()
        {
            ViewData["Group"] = new SelectList(_context.Groups, "Id", "Name");
            ViewData["Batch"] = new SelectList(_context.Batches, "Id", "Name");
            ViewData["Period"] = new SelectList(_context.Periods, "Id", "Name");
            ViewData["SubGroup"] = new SelectList(_context.Subgroups, "Id", "Name");
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("Create");
            }
            await _context.People.AddAsync(person);
            await _context.SaveChangesAsync();

            return RedirectToPage("Create");
        }
    }
}
