using API.Dotnet_7.Application.DTOs;
using API.Dotnet_7.Domain.Entities;
using AutoMapper;

namespace API.Dotnet_7.Application.Mappings
{
	public class DtoToDomainMappings : Profile
	{
		public DtoToDomainMappings()
		{
			CreateMap<PersonDTO, Person>();
		}
	}
}
