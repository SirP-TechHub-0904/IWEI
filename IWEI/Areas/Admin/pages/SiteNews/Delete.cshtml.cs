using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IWEI.Data;
using IWEI.Models;

namespace IWEI.Areas.Admin.pages.SiteNews
{
    public class DeleteModel : PageModel
    {
        private readonly IWEI.Data.ApplicationDbContext _context;

        public DeleteModel(IWEI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public News News { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            News = await _context.News.FirstOrDefaultAsync(m => m.Id == id);

            if (News == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            News = await _context.News.FindAsync(id);

            if (News != null)
            {
                _context.News.Remove(News);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
