using API.Dotnet_7.Domain.Entities;
using API.Dotnet_7.Domain.Repositories;
using API.Dotnet_7.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace API.Dotnet_7.Infra.Data.Repositories
{
	public class PurchaseRepository : IPurchaseRepository
	{
		private readonly ApplicationDbContext _context;

		public PurchaseRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Purchase> CreateAsync(Purchase purchase)
		{
			_context.Add(purchase);
			await _context.SaveChangesAsync();
			return purchase;
		}

		public async Task DeleteAsync(Purchase purchase)
		{
			_context.Remove(purchase);
			await _context.SaveChangesAsync();
		}

		public async Task<ICollection<Purchase>> GetAllAsync()
		{
			return await _context.Purchases
													 .Include(x => x.Product)
													 .Include(x => x.Person)
													 .ToListAsync();
		}

		public async Task<Purchase> GetByIdAsync(int id)
		{
			var purchase = await _context.Purchases
														.Include(x => x.Product)
														.Include(x => x.Person)
														.FirstOrDefaultAsync(x => x.Id == id);

			return purchase;
		}

		public async Task<ICollection<Purchase>> GetByPersonIdAsync(int personId)
		{
			var purchase = await _context.Purchases
														.Include(x => x.Product)
														.Include(x => x.Person)
														.Where(x => x.PersonId == personId).ToListAsync();
			return purchase;

		}

		public async Task<ICollection<Purchase>> GetByProductIdAsync(int productId)
		{
			var purchase = await _context.Purchases
														.Include(x => x.Product)
														.Include(x => x.Person)
														.Where(x => x.ProductId == productId).ToListAsync();
			return purchase;
		}

		public Task UpdateAsync(Purchase purchase)
		{
			throw new NotImplementedException();
		}
	}
}
