using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportApp2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportApp2.Pages.Person
{



    public class IndexModel : PageModel
    {

        SportDBContext _context;

        public IndexModel()
        {
            _context = new SportDBContext();
            _context.Database.EnsureCreated();
        }

        
        public List<Models.Person> people { get; set; }


        public async Task OnGet()
        {
            ViewData["Group"] = new SelectList(_context.Groups, "Id", "Name");
            ViewData["SubGroup"] = new SelectList(_context.Subgroups, "Id", "Name");
            ViewData["Batch"] = new SelectList(_context.Batches, "Id", "Name");
            ViewData["Period"] = new SelectList(_context.Periods, "Id", "Name");
        }

        public async Task<JsonResult> OnGetJson(int groupId, int subgroupId, int batchId, int periodId)
        {
            var _people = await _context.People.Where(a => a.GroupId==groupId && a.SubgroupId==subgroupId && a.BatcheId==batchId && a.PeriodId==periodId).Select(a => new PersonDto { Id = a.Id, Fname = a.Fname, Lname = a.Lname, NationCode = a.Uniquecode}).ToListAsync();
            return new JsonResult(new { data = _people });
        }

        public class PersonDto
        {
            public long Id { get; set; }
            public string Fname { get; set; }
            public string Lname { get; set; }
            public string NationCode { get; set; }
        }
    }
}
