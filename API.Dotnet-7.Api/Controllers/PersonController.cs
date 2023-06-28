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
		public async Task<ActionResult> PostAsync(PersonDTO personDTO)
		{
			var result = await _personService.CreateAsync(personDTO);
			if (result.IsSuccess)
				return Ok(result);

			return BadRequest(result);
		}

		[HttpGet]
		public async Task<ActionResult> GetAllAsync()
		{
			var result = await _personService.getAllAsync();
			if (result.IsSuccess)
				return Ok(result);

			return BadRequest(result);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult> GetByIdAsync(int id)
		{
			var result = await _personService.GetByIdAsync(id);
			if (result.IsSuccess)
				return Ok(result);

			return BadRequest(result);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateAsync(PersonDTO personDTO)
		{
			var result = await _personService.UpdateAsync(personDTO);
			if (result.IsSuccess)
				return Ok(result);

			return BadRequest(result);
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<ActionResult> DeleteAsync(int id)
		{
			var result = await _personService.DeleteAsync(id);
			if (result.IsSuccess)
				return Ok(result);

			return BadRequest(result);
		}
	}
}

