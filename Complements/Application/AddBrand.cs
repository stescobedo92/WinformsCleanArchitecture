using Complements.Entities;
using Complements.Repository;

namespace Complements.Application;

public class AddBrand
{
    private readonly IRepository<Brand> _repository;

    public AddBrand(IRepository<Brand> repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Brand brand) 
    {
        if(string.IsNullOrWhiteSpace(brand.Name))
        {
            throw new ArgumentException("Brand name cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(brand.Description))
        {
            throw new ArgumentException("Brand description cannot be empty.");
        }

        await _repository.AddAsync(brand);
    }
}
