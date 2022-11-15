using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportApp2.Models;
using System.Threading.Tasks;

namespace SportApp2.Pages.Subgroup
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
        public Models.Subgroup subgroup { get; set; }

        public void OnGet()
        {
            ViewData["Group"] = new SelectList(_context.Groups, "Id", "Name");
            ViewData["Period"] = new SelectList(_context.Periods, "Id", "Name");
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("Create");
            }
            await _context.Subgroups.AddAsync(subgroup);
            await _context.SaveChangesAsync();

            return RedirectToPage("Create");
        }
    }
}
