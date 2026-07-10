using Complements.DB;
using Complements.Entities;
using Complements.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Complements.Repository;

public class BrandRepository : IRepository<Brand>
{
    private readonly AppBrandDbContext _context;

    public BrandRepository(AppBrandDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Brand entity)
    {
        var brandModel = new BrandModel()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description
        };

        await _context.AddAsync(brandModel);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Brand>> GetAllAsync() => await _context.Brands.Select(brandEntity => new Brand
    {
        Id = brandEntity.Id,
        Name = brandEntity.Name,
        Description = brandEntity.Description
    }).ToListAsync();

    public async Task<Brand> GetByIdAsync(int id)
    {
        var brandModel = await _context.Brands.FindAsync(id);
        if (brandModel == null) return null;

        return new Brand
        {
            Id = brandModel.Id,
            Name = brandModel.Name,
            Description = brandModel.Description
        };
    }
}
