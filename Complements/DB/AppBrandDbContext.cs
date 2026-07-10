using Complements.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Complements.DB;

public class AppBrandDbContext : DbContext
{
    public AppBrandDbContext(DbContextOptions<AppBrandDbContext> options) : base(options) { }

    public DbSet<BrandModel> Brands { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<BrandModel>().ToTable("Brand");
    }
}
