using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IWEI.Data;
using IWEI.Models;

namespace IWEI.Areas.Admin.pages.SitePage
{
    public class EditModel : PageModel
    {
        private readonly IWEI.Data.ApplicationDbContext _context;

        public EditModel(IWEI.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WebsitePage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebsitePageExists(WebsitePage.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WebsitePageExists(int id)
        {
            return _context.Page.Any(e => e.Id == id);
        }
    }
}
