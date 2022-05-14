using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IWEI.Data;
using IWEI.Models;

namespace IWEI.Areas.Admin.pages.SitePage
{
    public class DeleteModel : PageModel
    {
        private readonly IWEI.Data.ApplicationDbContext _context;

        public DeleteModel(IWEI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WebsitePage WebsitePage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WebsitePage = await _context.Page.FirstOrDefaultAsync(m => m.Id == id);

            if (WebsitePage == null)
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

            WebsitePage = await _context.Page.FindAsync(id);

            if (WebsitePage != null)
            {
                _context.Page.Remove(WebsitePage);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
