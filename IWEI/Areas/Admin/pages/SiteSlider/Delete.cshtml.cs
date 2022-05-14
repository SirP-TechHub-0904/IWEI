using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IWEI.Data;
using IWEI.Models;

namespace IWEI.Areas.Admin.pages.SiteSlider
{
    public class DeleteModel : PageModel
    {
        private readonly IWEI.Data.ApplicationDbContext _context;

        public DeleteModel(IWEI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Slider Slider { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Slider = await _context.Slider.FirstOrDefaultAsync(m => m.Id == id);

            if (Slider == null)
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

            Slider = await _context.Slider.FindAsync(id);

            if (Slider != null)
            {
                _context.Slider.Remove(Slider);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
