﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IWEI.Data;
using IWEI.Models;

namespace IWEI.Areas.Admin.pages.SiteSlider
{
    public class CreateModel : PageModel
    {
        private readonly IWEI.Data.ApplicationDbContext _context;

        public CreateModel(IWEI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Slider Slider { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Slider.Add(Slider);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
