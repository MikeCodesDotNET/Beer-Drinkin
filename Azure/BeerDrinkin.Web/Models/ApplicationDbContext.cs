﻿using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using BeerDrinkin.DataObjects;

namespace BeerDrinkin.Web.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
                        
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<Beer> BeerItems { get; set; }
    }
}
