using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportApp2.Models;
using System.Threading.Tasks;

namespace SportApp2.Pages.Group
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
        public Models.Group group { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("Create");
            }
            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();

            return RedirectToPage("Create");
        }
    }
}
