using FluentValidation;

namespace API.Dotnet_7.Application.DTOs.Validations
{
	public class PersonDTOValidator : AbstractValidator<PersonDTO>
	{
		public PersonDTOValidator()
		{
			RuleFor(x => x.Document)
				.NotEmpty()
				.NotNull()
				.WithMessage("Document must be informed");

			RuleFor(x => x.Name)
				.NotEmpty()
				.NotNull()
				.WithMessage("Name must be informed");

			RuleFor(x => x.Phone)
				.NotEmpty()
				.NotNull()
				.WithMessage("Phone must be informed");
		}
	}
}
