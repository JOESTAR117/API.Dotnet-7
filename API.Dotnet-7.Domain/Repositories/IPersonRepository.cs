using API.Dotnet_7.Domain.Entities;

namespace API.Dotnet_7.Domain.Repositories
{
	public interface IPersonRepository
	{
		Task<Person> GetByIdAsync(int id);
		Task<ICollection<Person>> GetPeopleAsync();
		Task<Person> CreateAsync(Person person);
		Task UpdateAsync(Person person);
		Task DeleteAsync(Person person);
		Task<int> GetIdByDocumentAsync(string document);
	}
}
