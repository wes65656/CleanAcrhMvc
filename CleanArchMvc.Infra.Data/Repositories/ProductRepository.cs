using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    private ApplicationDbContext _productContext = context;
    
    public async Task<Product> CreateAsync(Product product)
    {
        _productContext.Add(product);
        await _productContext.SaveChangesAsync();
        return product;
    }
    
    public async Task<Product> UpdateAsync(Product product)
    {
        _productContext.Attach(product);
        _productContext.Update(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> RemoveAsync(Product product)
    {
        _productContext.Remove(product);
        await _productContext.SaveChangesAsync();
        return product;
    }
    
    public async Task<Product> GetByIdAsync(int? id)
    {
        return await _productContext.Products
            .Include(c => c.Category)
            .AsTracking() // Garanta que o EF esteja rastreando a entidade filha da mãe
            .SingleOrDefaultAsync(p => p.Id == id);
    }
    
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _productContext.Products.ToListAsync();
    }
}
