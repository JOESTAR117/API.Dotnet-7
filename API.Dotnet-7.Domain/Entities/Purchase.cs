using API.Dotnet_7.Domain.Validations;

namespace API.Dotnet_7.Domain.Entities
{
	public sealed class Purchase
	{
		public Purchase(int productId, int personId, DateTime? date)
		{
			Validation(productId, personId, date);
		}

		public Purchase(int id, int productId, int personId, DateTime? date)
		{
			DomainValidationException.When(id < 0, "the id must be informed");
			Id = id;
			Validation(productId, personId, date);
		}

		public int Id { get; private set; }
		public int ProductId { get; private set; }
		public int PersonId { get; private set; }
		public DateTime Date { get; private set; }
		public Person Person { get; set; }
		public Product Product { get; set; }


		private void Validation(int productId, int personId, DateTime? date)
		{
			DomainValidationException.When(productId < 0, "the id must be informed");
			DomainValidationException.When(personId < 0, "the id must be informed");
			DomainValidationException.When(!date.HasValue, "the date must be informed");

			ProductId = productId;
			PersonId = personId;
			Date = date.Value;

		}

	}

}
