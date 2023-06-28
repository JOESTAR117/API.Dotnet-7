using API.Dotnet_7.Application.DTOs;
using API.Dotnet_7.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Dotnet_7.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonController : ControllerBase
	{
		private readonly IPersonService _personService;

		public PersonController(IPersonService personService)
		{
			_personService = personService;
		}

		[HttpPost]
		public async Task<ActionResult> Post(PersonDTO personDTO)
		{
			var result = await _personService.CreateAsync(personDTO);
			if (result.IsSuccess)
				return Ok(result);

			return BadRequest(result);
		}
	}
}

