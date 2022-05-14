using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IWEI.Data;
using IWEI.Models;

namespace IWEI.Areas.Admin.pages.SiteGallery
{
    public class DetailsModel : PageModel
    {
        private readonly IWEI.Data.ApplicationDbContext _context;

        public DetailsModel(IWEI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Gallery Gallery { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Gallery = await _context.Gallery.FirstOrDefaultAsync(m => m.Id == id);

            if (Gallery == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
