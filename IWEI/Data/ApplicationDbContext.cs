using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using IWEI.Models;

namespace IWEI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<IWEI.Models.Slider> Slider { get; set; }
        public DbSet<IWEI.Models.Gallery> Gallery { get; set; }
        public DbSet<IWEI.Models.Image> Image { get; set; }
        public DbSet<IWEI.Models.News> News { get; set; }
        public DbSet<IWEI.Models.WebsitePage> Page { get; set; }
    }
}
