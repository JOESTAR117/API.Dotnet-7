using API.Dotnet_7.Application.DTOs;
using API.Dotnet_7.Application.DTOs.Validations;
using API.Dotnet_7.Application.Services.Interface;
using API.Dotnet_7.Domain.Entities;
using API.Dotnet_7.Domain.Repositories;
using AutoMapper;

namespace API.Dotnet_7.Application.Services
{
	public class PersonService : IPersonService
	{
		private readonly IPersonRepository _personRepository;
		private readonly IMapper _mapper;

		public PersonService(IPersonRepository personRepository, IMapper mapper)
		{
			_personRepository = personRepository;
			_mapper = mapper;
		}

		public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
		{
			if (personDTO == null)
				return ResultService.Fail<PersonDTO>("object must be informed");

			var result = new PersonDTOValidator().Validate(personDTO);
			if (!result.IsValid)
				return ResultService.RequestError<PersonDTO>("validity issues", result);

			var person = _mapper.Map<Person>(personDTO);
			var data = await _personRepository.CreateAsync(person);
			return ResultService.Ok(_mapper.Map<PersonDTO>(data));
		}

		public async Task<ResultService> DeleteAsync(int id)
		{
			var people = await _personRepository.GetByIdAsync(id);
			if (people == null)
				return ResultService.Fail<PersonDTO>("Person not found");
			await _personRepository.DeleteAsync(people);
			return ResultService.Ok("Person removed successfully");
		}

		public async Task<ResultService<ICollection<PersonDTO>>> getAllAsync()
		{
			var peoples = await _personRepository.GetPeopleAsync();
			return ResultService.Ok(_mapper.Map<ICollection<PersonDTO>>(peoples));
		}

		public async Task<ResultService<PersonDTO>> GetByIdAsync(int id)
		{
			var people = await _personRepository.GetByIdAsync(id);
			if (people == null)
				return ResultService.Fail<PersonDTO>("Person not found");
			return ResultService.Ok(_mapper.Map<PersonDTO>(people));
		}

		public async Task<ResultService> UpdateAsync(PersonDTO personDTO)
		{
			if (personDTO == null)
				return ResultService.Fail("object must be informed");

			var validation = new PersonDTOValidator().Validate(personDTO);
			if (!validation.IsValid)
				return ResultService.RequestError("Problem with field validation", validation);

			var person = await _personRepository.GetByIdAsync(personDTO.Id);
			if (person == null)
				return ResultService.Fail("Person not found");

			person = _mapper.Map(personDTO, person);
			await _personRepository.UpdateAsync(person);
			return ResultService.Ok("successfully edited person");
		}
	}
}
