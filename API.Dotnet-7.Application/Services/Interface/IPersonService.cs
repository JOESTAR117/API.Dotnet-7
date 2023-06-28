using API.Dotnet_7.Application.DTOs;

namespace API.Dotnet_7.Application.Services.Interface
{
	public interface IPersonService
	{
		Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
		Task<ResultService<ICollection<PersonDTO>>> getAllAsync();
		Task<ResultService<PersonDTO>> GetByIdAsync(int id);
	}
}
