using API.Dotnet_7.Domain.Entities;
using API.Dotnet_7.Domain.Repositories;
using API.Dotnet_7.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace API.Dotnet_7.Infra.Data.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDbContext _context;

		public ProductRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Product> CreateAsync(Product product)
		{
			_context.Add(product);
			await _context.SaveChangesAsync();
			return product;
		}

		public async Task DeleteAsync(Product product)
		{
			_context.Remove(product);
			await _context.SaveChangesAsync();
		}

		public async Task<Product> GetByIdAsync(int id)
		{
			return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<int> GetIdByCodErpAsync(string codErp)
		{
			return (await _context.Products.FirstOrDefaultAsync(x => x.CodErp == codErp))?.Id ?? 0;
		}

		public async Task<ICollection<Product>> GetProductsAsync()
		{
			return await _context.Products.ToListAsync();
		}

		public async Task UpdateAsync(Product product)
		{
			_context.Update(product);
			await _context.SaveChangesAsync();
		}
	}
}
