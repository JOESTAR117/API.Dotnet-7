using API.Dotnet_7.Domain.Entities;

namespace API.Dotnet_7.Domain.Repositories
{
	public interface IProductRepository
	{
		Task<Product> GetByIdAsync(int id);
		Task<ICollection<Product>> GetProductsAsync();
		Task<Product> CreateAsync(Product product);
		Task UpdateAsync(Product product);
		Task DeleteAsync(Product product);
		Task<int> GetIdByCodErpAsync(string codErp);
	}
}
