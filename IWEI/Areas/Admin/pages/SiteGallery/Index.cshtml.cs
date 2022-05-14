﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly IWEI.Data.ApplicationDbContext _context;

        public IndexModel(IWEI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Gallery> Gallery { get;set; }

        public async Task OnGetAsync()
        {
            Gallery = await _context.Gallery.ToListAsync();
        }
    }
}
